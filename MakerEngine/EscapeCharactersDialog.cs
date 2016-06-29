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
	public partial class EscapeCharactersDialog : Form {

		public bool hidden = true;


		public EscapeCharactersDialog() {
			InitializeComponent();
		}

		public void display() {

			if (hidden) {
				hidden = false;
				Show();
			}  else {
				Hide();
				hidden = true;
			}


		}


		protected override void OnFormClosing(FormClosingEventArgs e) {

			this.Hide();
			e.Cancel = true;
			hidden = true;

		}

		private void richTextBox_EscapeCharacters_TextChanged(Object sender, EventArgs e) {

		}
	}
}
