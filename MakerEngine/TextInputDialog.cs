﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakerEngine
{
    public partial class TextInputDialog: Form
    {
        public TextInputDialog()
        {
            InitializeComponent();
        }

		private void button_Accept_Click(Object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
	}
}
