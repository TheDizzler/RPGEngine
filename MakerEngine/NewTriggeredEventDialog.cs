﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakerEngine {
	public partial class NewTriggeredEventDialog : Form {
		public NewTriggeredEventDialog() {
			InitializeComponent();
		}

		private void button_Accept_Click(Object sender, EventArgs e) {

			if (textBox_NewEvent.Text.Length >= 1)
				DialogResult = DialogResult.OK;
		}
	}
}
