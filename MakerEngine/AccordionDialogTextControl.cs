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
	public partial class AccordionDialogTextControl : UserControl, AccordionControl {

		XmlNode node;
		MakerEngineForm mainForm;

		private bool changed = false;
		private bool loading = true;


		public AccordionDialogTextControl(MakerEngineForm main, XmlNode dialogTextNode) {
			InitializeComponent();

			mainForm = main;
			node = dialogTextNode;

			if (node.Attributes["from"] != null)
				textBox_from.Text = node.Attributes["from"].InnerText;
			else
				textBox_from.Text = "";

			if (node.Attributes["to"] != null)
				textBox_JumpTo.Text = node.Attributes["to"].InnerText;
			else
				textBox_JumpTo.Text = "";

			richTextBox_dialogText.Text = node.InnerText;
			richTextBox_dialogText.ScrollBars = ScrollBars.Vertical;
			loading = false;
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

						mainForm.createNewDialogText(node, textBox_JumpTo.Text);

						break;
					case NewBlockDialog.NewBlockDialogResult.Query:


						break;
					case NewBlockDialog.NewBlockDialogResult.AlphaInput:

						mainForm.createNewInputText(node);
						break;

				}

			}


		}

		private void textChanged(Object sender, EventArgs e) {

			if (!loading) {
				changed = true;
				mainForm.needSave(true);
			}
		}

		public Boolean changesMade() {

			return changed;
		}


		public void saveChanges() {

			if (textBox_from.Text.Length > 0) {
				if (node.Attributes["from"] == null)
					node.Attributes.SetNamedItem(node.OwnerDocument.CreateAttribute("from"));
				node.Attributes["from"].InnerText = textBox_from.Text;
			}

			if (textBox_JumpTo.Text.Length > 0) {
			if (node.Attributes["to"] == null)
				node.Attributes.SetNamedItem(node.OwnerDocument.CreateAttribute("to"));

			node.Attributes["to"].InnerText = textBox_JumpTo.Text;
		}


		node.InnerText = richTextBox_dialogText.Text;

		}
}
}
