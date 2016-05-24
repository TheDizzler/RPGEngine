using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakerEngine {
	public partial class ImageViewer : Form {
		public ImageViewer() {
			InitializeComponent();
		}


		protected override void OnFormClosing(FormClosingEventArgs e) {
			base.OnFormClosing(e);

			if (e.CloseReason == CloseReason.WindowsShutDown)
				return;

			this.Visible = false;
			e.Cancel = true;

		}
	}
}
