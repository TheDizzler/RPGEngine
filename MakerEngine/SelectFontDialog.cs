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
	/// <summary>
	/// Code borrowed (ruthlessly stolen) from
	/// http://stackoverflow.com/questions/8644007/designing-a-custom-font-dialog-selector-for-c-sharp-that-filters-out-non-true-ty
	/// </summary>
	public partial class SelectFontDialog : Form {


		List<Font> fonts = new List<Font>();


		public SelectFontDialog() {
			InitializeComponent();

			foreach (FontFamily ff in FontFamily.Families) {

				// determine the first available style, as all fonts don't support all styles
				FontStyle? availableStyle = null;
				foreach (FontStyle style in Enum.GetValues(typeof(FontStyle))) {
					if (ff.IsStyleAvailable(style)) {
						availableStyle = style;
						break;
					}
				}

				if (availableStyle.HasValue) {
					Font font = null;
					try {
						// do your own Font initialization here
						// discard the one you don't like :-)
						font = new Font(ff, 12, availableStyle.Value);
					} catch {
					}
					if (font != null) {
						listBox_FontList.Items.Add(font);
						fonts.Add(font);
					}
				}
			}

		}


		private void button_Accept_Click(Object sender, EventArgs e) {

			if (listBox_FontList.SelectedItem != null) {
				if (textBox_FontName.Text.Length <= 0)
					textBox_FontName.BackColor = Color.Red;
				else
					DialogResult = DialogResult.OK;
			}
		}

		private void textBox_FontName_TextChanged(Object sender, EventArgs e) {

			textBox_FontName.BackColor = Color.White;
		}
	}
}
