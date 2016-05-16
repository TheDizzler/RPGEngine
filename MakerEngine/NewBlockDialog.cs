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
	public partial class NewBlockDialog : Form {

		public enum NewBlockDialogResult  {
			Cancel, DialogText, Query, AlphaInput
		};

		public NewBlockDialogResult blockDialogResult = NewBlockDialogResult.Cancel;


		public NewBlockDialog() {
			InitializeComponent();
		}

		private void button_NewDialogText_Click(Object sender, EventArgs e) {
			blockDialogResult = NewBlockDialogResult.DialogText;
			DialogResult = DialogResult.OK;

		}

		private void button_NewQuery_Click(Object sender, EventArgs e) {
			blockDialogResult = NewBlockDialogResult.Query;
			DialogResult = DialogResult.OK;
		}

		private void button_NewAlphaInput_Click(Object sender, EventArgs e) {
			blockDialogResult = NewBlockDialogResult.AlphaInput;
			DialogResult = DialogResult.OK;
		}
	}
}
