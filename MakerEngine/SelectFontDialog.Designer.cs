﻿namespace MakerEngine {
	partial class SelectFontDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel = new System.Windows.Forms.Panel();
			this.textBox_FontName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown_FontSize = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.listBox_FontList = new System.Windows.Forms.ListBox();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_Accept = new System.Windows.Forms.Button();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FontSize)).BeginInit();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.AutoSize = true;
			this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel.Controls.Add(this.textBox_FontName);
			this.panel.Controls.Add(this.label2);
			this.panel.Controls.Add(this.numericUpDown_FontSize);
			this.panel.Controls.Add(this.label1);
			this.panel.Controls.Add(this.listBox_FontList);
			this.panel.Controls.Add(this.button_Cancel);
			this.panel.Controls.Add(this.button_Accept);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(322, 251);
			this.panel.TabIndex = 0;
			// 
			// textBox_FontName
			// 
			this.textBox_FontName.Location = new System.Drawing.Point(95, 190);
			this.textBox_FontName.Name = "textBox_FontName";
			this.textBox_FontName.Size = new System.Drawing.Size(220, 20);
			this.textBox_FontName.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(92, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Font Name";
			// 
			// numericUpDown_FontSize
			// 
			this.numericUpDown_FontSize.Location = new System.Drawing.Point(12, 190);
			this.numericUpDown_FontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.numericUpDown_FontSize.Name = "numericUpDown_FontSize";
			this.numericUpDown_FontSize.Size = new System.Drawing.Size(64, 20);
			this.numericUpDown_FontSize.TabIndex = 4;
			this.numericUpDown_FontSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 174);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Font Size";
			// 
			// listBox_FontList
			// 
			this.listBox_FontList.FormattingEnabled = true;
			this.listBox_FontList.Location = new System.Drawing.Point(13, 13);
			this.listBox_FontList.Name = "listBox_FontList";
			this.listBox_FontList.Size = new System.Drawing.Size(302, 160);
			this.listBox_FontList.TabIndex = 2;
			// 
			// button_Cancel
			// 
			this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(235, 216);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 1;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// button_Accept
			// 
			this.button_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_Accept.Location = new System.Drawing.Point(13, 216);
			this.button_Accept.Name = "button_Accept";
			this.button_Accept.Size = new System.Drawing.Size(75, 23);
			this.button_Accept.TabIndex = 0;
			this.button_Accept.Text = "Accept";
			this.button_Accept.UseVisualStyleBackColor = true;
			this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
			// 
			// SelectFontDialog
			// 
			this.AcceptButton = this.button_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(322, 251);
			this.ControlBox = false;
			this.Controls.Add(this.panel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectFontDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Select Font";
			this.TopMost = true;
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FontSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_Accept;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ListBox listBox_FontList;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox textBox_FontName;
		public System.Windows.Forms.NumericUpDown numericUpDown_FontSize;
	}
}