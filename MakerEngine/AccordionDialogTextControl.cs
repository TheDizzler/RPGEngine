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
	public partial class AccordionDialogTextControl : UserControl {

		XmlNode node;

		public AccordionDialogTextControl(XmlNode dialogTextNode) {
			InitializeComponent();


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
	}
}
