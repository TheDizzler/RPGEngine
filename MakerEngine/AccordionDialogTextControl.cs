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
using System.IO;

namespace MakerEngine {
	public partial class AccordionDialogTextControl : UserControl {

		XmlNode node;
		MakerEngineForm mainForm;

		public AccordionDialogTextControl(MakerEngineForm main, XmlNode dialogTextNode) {
			InitializeComponent();

			mainForm = main;
			node = dialogTextNode;

			if (node.Attributes["from"] != null)
				textBox_from.Text = node.Attributes["from"].InnerText;
			else
				textBox_from.Text = "";

			if (node.Attributes["to"] != null)
				textBox_jumpTo.Text = node.Attributes["to"].InnerText;
			else
				textBox_jumpTo.Text = "";

			richTextBox_dialogText.Text = node.InnerText;
		}


		public String getLabel() {

			String label = node.Name;
			if (node.Attributes["from"] != null)
				label += "    FROM: " + node.Attributes["from"].InnerText;

			if (node.Attributes["to"] != null)
				label += "    TO: " + node.Attributes["to"].InnerText;

			return label;
		}


		private void button_CreateNewBlock_Click(Object sender, EventArgs e) {

			using (NewBlockDialog dialog = new NewBlockDialog()) {

				DialogResult result = dialog.ShowDialog();
				
				switch (dialog.blockDialogResult) {

					case NewBlockDialog.NewBlockDialogResult.Cancel:
						//dialog.Close();
						break;

					case NewBlockDialog.NewBlockDialogResult.DialogText:
						
						mainForm.createNewDialogText(node, textBox_jumpTo.Text);
						//dialog.Close();
						break;
					case NewBlockDialog.NewBlockDialogResult.Query:

						break;
					case NewBlockDialog.NewBlockDialogResult.AlphaInput:

						break;

				}

			}


		}
	}
}
