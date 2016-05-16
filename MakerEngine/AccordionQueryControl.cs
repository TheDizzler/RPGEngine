using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MakerEngine {
	public partial class AccordionQueryControl : UserControl {

		XmlNode node;
		MakerEngineForm mainForm;

		public bool changed = false;


		public AccordionQueryControl(MakerEngineForm main, XmlNode answerNode) {
			InitializeComponent();

			mainForm = main;
			node = answerNode;

			richTextBox_Choice.Text = node.InnerText;
			textBox_JumpTo.Text = node.Attributes["to"].InnerText;

		}


		private void textChanged(Object sender, EventArgs e) {

			changed = true;
		}

		private void button_JumpTo_Click(Object sender, EventArgs e) {

			if (textBox_JumpTo.TextLength <= 0) {
				textBox_JumpTo.BackColor = Color.Red;
				return;

			}
			textBox_JumpTo.BackColor = Color.White;
			mainForm.createNewDialogText(node, textBox_JumpTo.Text);


		}
	}
}
