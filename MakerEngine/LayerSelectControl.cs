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
	public partial class LayerSelectControl : Form {


		private MakerEngineForm mainForm;

		public List<CheckBox> checkBoxes;

		public LayerSelectControl(MakerEngineForm makerEngineForm) {
			InitializeComponent();
			mainForm = makerEngineForm;

			checkBoxes = new List<CheckBox>();
		}

	}
}
