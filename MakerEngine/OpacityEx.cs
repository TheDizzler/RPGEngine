﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Opulos.Core.UI {
	public static class OpacityEx {

		private static Hashtable ht = new Hashtable();
		private class Data {
			PictureBox pbox = new PictureBox { BorderStyle = BorderStyle.None };
			Timer fadeTimer = new Timer();
			Control control;
			Bitmap bmpBack, bmpFore;
			float blend = 1;
			int blendDir = 1;
			float step = 0.02f;

			public Data(Control control) {
				this.control = control;
				fadeTimer.Interval = 20;
				fadeTimer.Tick += opacityTimer_Tick;
				pbox.Paint += pbox_Paint;
				blend = control.Visible ? 1 : 0;
			}

			public void Dispose() {
				if (bmpBack != null)
					bmpBack.Dispose();
				if (bmpFore != null)
					bmpFore.Dispose();
				if (pbox != null)
					pbox.Dispose();
				if (fadeTimer != null)
					fadeTimer.Dispose();

				bmpBack = null;
				bmpFore = null;
				pbox = null;
				fadeTimer = null;
			}

			void pbox_Paint(object sender, PaintEventArgs e) {
				if (bmpFore == null || bmpBack == null)
					return;

				Rectangle rc = new Rectangle(Point.Empty, control.Size);
				ColorMatrix cm = new ColorMatrix();
				ImageAttributes ia = new ImageAttributes();
				cm.Matrix33 = blend;
				ia.SetColorMatrix(cm);
				e.Graphics.DrawImage(bmpFore, rc, 0, 0, bmpFore.Width, bmpFore.Height, GraphicsUnit.Pixel, ia);
				cm.Matrix33 = 1f - blend;
				ia.SetColorMatrix(cm);
				e.Graphics.DrawImage(bmpBack, rc, 0, 0, bmpBack.Width, bmpBack.Height, GraphicsUnit.Pixel, ia);
				ia.Dispose();
			}

			public void FadeIn(int millis) {
				if (millis <= 0) {
					blend = 1;
					stopFade();
					return;
				}

				if (blend == 1)
					return;

				if (!fadeTimer.Enabled)
					createBitmaps();

				step = 1f / (millis / 30f);
				startFade(1);
			}

			public void FadeOut(int millis) {
				if (millis <= 0) {
					blend = 0;
					stopFade(); // disabled timer
					return;
				}

				if (blend == 0)
					return;

				if (!fadeTimer.Enabled) {
					createBitmaps();
					// fading out sets the control Visible to false
					// which will cause a flicker if paint is not called
					pbox.Refresh(); // immediately calls pbox_Paint
									//pbox.Invalidate();
				}

				step = 1f / (millis / 30f);
				startFade(-1);
			}

			private void startFade(int dir) {
				blendDir = dir;
				fadeTimer.Enabled = true;
			}

			private void createBitmaps() {
				if (bmpBack != null)
					bmpBack.Dispose();
				if (bmpFore != null)
					bmpFore.Dispose();

				var r = control.Bounds;
				var r2 = r;
				r.Location = Point.Empty;
				bmpBack = CreateScreenCapture(control.Parent, r2);
				bmpFore = new Bitmap(r.Width, r.Height);
				control.DrawToBitmap(bmpFore, r);

				if (control.Visible)
					control.Visible = false;

				
				pbox.Size = r.Size;
				control.Controls.Add(pbox);
				control.Controls.SetChildIndex(pbox, 0);
				control.Visible = true; // must set to visible when fading in from invisible, otherwise the pbox repaint isn't called
			}

			[DllImport("user32.dll")]
			public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
			private const int WM_SETREDRAW = 11;

			[DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
			private static extern bool BitBlt(IntPtr pHdc, int iX, int iY, int iWidth, int iHeight, IntPtr pHdcSource, int iXSource, int iYSource, System.Int32 dw);
			private const int SRC = 0xCC0020;

			private static Bitmap CreateScreenCapture(Control c, Rectangle r) {
				Bitmap bmp = null;
				using (var g = c.CreateGraphics()) {
					bmp = new Bitmap(r.Width, r.Height, g);
					Graphics g2 = Graphics.FromImage(bmp);
					IntPtr g2_hdc = g2.GetHdc();
					IntPtr g_hdc = g.GetHdc();
					BitBlt(g2_hdc, 0, 0, r.Width, r.Height, g_hdc, r.X, r.Y, SRC);
					g.ReleaseHdc(g_hdc);
					g2.ReleaseHdc(g2_hdc);
					g2.Dispose();
				}
				return bmp;
			}

			void opacityTimer_Tick(object sender, EventArgs e) {
				blend += blendDir * step;
				bool done = false;
				if (blend < 0) { done = true; blend = 0; }
				if (blend > 1) { done = true; blend = 1; }
				if (done)
					stopFade();
				else
					pbox.Invalidate();
			}

			private void stopFade() {
				fadeTimer.Enabled = false;
				control.Visible = (blend == 1);
				// timing issue. As a resize bar finishes fading out,
				// other control may already have been clicked. However,
				// when the pbox is removed, it causes the focus to change
				// to the first child control. So if a user clicked on
				// one resize bar, and then click on another resize bar
				// before the first one faded out, then the focus would
				// change to some other control, and the resize bar that
				// was just clicked is no longer the focused control.
				// So the focus is put back to the original window with
				// the focus.
				IntPtr hWnd = GetFocus();
				control.Controls.Remove(pbox);
				SetFocus(hWnd);
			}
		}

		private static Data GetData(Control control) {
			Data d = (Data)ht[control];
			if (d == null) {
				d = new Data(control);
				ht[control] = d;
				control.Disposed += delegate {
					ht.Remove(control);
					d.Dispose();
				};
			}
			return d;
		}

		public static void FadeIn(this Control control, int millis) {
			Data d = GetData(control);
			d.FadeIn(millis);
		}

		public static void FadeOut(this Control control, int millis) {
			Data d = GetData(control);
			d.FadeOut(millis);
		}

		[DllImport("user32.dll")]
		private static extern IntPtr GetFocus(); // returns the window handle with the active focus

		[DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);
	}

}