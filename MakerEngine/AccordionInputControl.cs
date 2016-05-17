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
	public partial class AccordionInputControl : UserControl, AccordionControl {

		XmlNode node;
		MakerEngineForm mainForm;

		private bool changed = false;
		private bool loading = true;


		public AccordionInputControl(MakerEngineForm main, XmlNode alphaNode) {
			InitializeComponent();

			mainForm = main;
			node = alphaNode;

			textBox_DefaultInput.Text = node.Attributes["default"].InnerText;
			textBox_saveTo.Text = node.Attributes["saveTo"].InnerText;

			loading = false;

		}

		public Boolean changesMade() {
			
			return changed;
		}

		private void textChanged(Object sender, EventArgs e) {
			if (!loading) {
				changed = true;
				mainForm.needSave(true);
			}
		}
	}
}
