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
	public partial class AccordionQueryControl : UserControl, AccordionControl {

		XmlNode node;
		MakerEngineForm mainForm;


		public AccordionQueryControl(MakerEngineForm main, XmlNode queryNode) {
			InitializeComponent();

			mainForm = main;
			node = queryNode;

			if (node.Attributes["from"] != null)
				textBox_From.Text = node.Attributes["from"].InnerText;
		}

		public Boolean changesMade() {
			throw new NotImplementedException();
		}

		public void saveChanges() {

			node.Attributes["from"].InnerText = textBox_From.Text;
		}

		private void button_NewChoice_Click(Object sender, EventArgs e) {

		}

		internal String getLabel() {

			String label = node.Name;
			if (node.Attributes["from"] != null)
				label += "    FROM: " + node.Attributes["from"].InnerText;

			return label;
		}
	}
}
