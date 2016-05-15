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

		public AccordionQueryControl(XmlNode answerNode) {
			InitializeComponent();

			node = answerNode;

			richTextBox_Choice.Text = node.InnerText;
			textBox_JumpTo.Text = node.Attributes["to"].InnerText;

		}
	}
}
