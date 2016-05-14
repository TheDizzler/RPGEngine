using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Opulos.Core.UI;

namespace MakerEngine {
	public partial class MakerEngineForm : Form {

		public DirectoryInfo workingDirectory;


		public String gameDirectory = "D:/github projects/RPGEngine/";
		public String dialogText = "assets/text/GameText.xml";

		XmlDocument docDialogText;


		public MakerEngineForm() {
			InitializeComponent();

			accordion_Dialog.CheckBoxMargin = new Padding(2);
			accordion_Dialog.ContentMargin = new Padding(15, 5, 15, 5);
			accordion_Dialog.ContentPadding = new Padding(1);
			accordion_Dialog.Insets = new Padding(5);
			accordion_Dialog.ControlBackColor = Color.White;
			accordion_Dialog.ContentBackColor = Color.CadetBlue;

			//TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
			//tlp.TabStop = true;
			//tlp.Controls.Add(new Label { Text = "First Name", TextAlign = ContentAlignment.BottomLeft }, 0, 0);
			//tlp.Controls.Add(new TextBox(), 1, 0);
			//tlp.Controls.Add(new Label { Text = "Last Name", TextAlign = ContentAlignment.BottomLeft }, 0, 1);
			//tlp.Controls.Add(new TextBox(), 1, 1);

			//accordion_Dialog.Add(tlp, "Contact Info", "Enter the client's information.", 0, true);
			//accordion_Dialog.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true, BackColor = Color.White }, "Memo", "Additional Client Info", 1, true, contentBackColor: Color.Transparent);
			//accordion_Dialog.Add(new Control(), "Other Info", "Miscellaneous information.");
			loadGameXmlFiles();

		}

		private void loadGameXmlFiles() {


			docDialogText = new XmlDocument();
			docDialogText.Load(gameDirectory + dialogText);
			XmlNode root = docDialogText.FirstChild;

			this.Text = "Maker Engine - " + root.Attributes["game"].InnerText;

			//build tree view from dialog text
			List<TreeXMLNode> treeNodeList;

			foreach (XmlNode node in root.ChildNodes) {
				//string eventType = node.Attributes["type"].InnerText;

				treeNodeList = new List<TreeXMLNode>();

				foreach (XmlNode child in node.ChildNodes) {
					//string speaker = child.Attributes["speaker"].InnerText;
					treeNodeList.Add(new TreeXMLNode(child));
				}
				treeView_Dialog.Nodes.Add(new TreeXMLNode(node, treeNodeList.ToArray()));
			}



		}

		private void loadToolStripMenuItem_Click(Object sender, EventArgs e) {

		}

		private void newGameToolStripMenuItem_Click(Object sender, EventArgs e) {

			if (newGameFileDialog.ShowDialog() == DialogResult.OK) {

			}
		}

		private void newGameFileDialog_FileOk(Object sender, CancelEventArgs e) {

			String path = newGameFileDialog.InitialDirectory + newGameFileDialog.FileName;
			workingDirectory = Directory.CreateDirectory(path);

		}

		private void saveToolStripMenuItem_Click(Object sender, EventArgs e) {

		}

		private void treeView_Dialog_MouseClick(Object sender, MouseEventArgs e) {



		}

		private void treeView_Dialog_MouseDoubleClick(Object sender, MouseEventArgs e) {

			TreeXMLNode selected = (TreeXMLNode)treeView_Dialog.SelectedNode;
			XmlNode selectedNode = selected.node;

			panel1.Controls.Remove(accordion_Dialog);
			accordion_Dialog.Dispose();

			rebuildAccordion();

			if (selectedNode.Attributes["speaker"] != null) {

				textBox_Speaker.Text = selected.Text;
				//rich_DialogText.Text = selected.node.FirstChild.InnerText;

				foreach (XmlNode child in selectedNode.ChildNodes) {

					switch (child.Name) {
						case "dialogText":
							RichTextBox textBox = new RichTextBox { Dock = DockStyle.Fill, Multiline = true, BackColor = Color.White };
							textBox.Text = child.InnerText;

							CheckBox ckboxDialog = accordion_Dialog.Add(textBox, child.Name, "Additional Client Info", 1, true, contentBackColor: Color.Transparent);
							break;

						case "query":
							TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
							tlp.TabStop = true;
							int i = child.ChildNodes.Count - 1;
							foreach (XmlNode answer in child.ChildNodes) {
								tlp.Controls.Add(new Label { Text = "Option " + i, TextAlign = ContentAlignment.BottomLeft }, 0, 0);
								TextBox answerBox = new TextBox();
								answerBox.Text = answer.InnerText;
								tlp.Controls.Add(answerBox, 1, 0);
								i++;
							}
							CheckBox ckboxQuery = accordion_Dialog.Add(tlp, child.Name, "Additional Client Info", 1, true, contentBackColor: Color.Transparent);
							break;

						case "alphaInput":

							break;
					}
				}

			}
		}


		private void rebuildAccordion() {

			this.accordion_Dialog = new Opulos.Core.UI.Accordion();
			this.accordion_Dialog.AddResizeBars = true;
			this.accordion_Dialog.AllowMouseResize = true;
			this.accordion_Dialog.AnimateCloseEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalNegative | Opulos.Core.UI.AnimateWindowFlags.Hide)
			| Opulos.Core.UI.AnimateWindowFlags.Slide)));
			this.accordion_Dialog.AnimateCloseMillis = 300;
			this.accordion_Dialog.AnimateOpenEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalPositive | Opulos.Core.UI.AnimateWindowFlags.Show)
			| Opulos.Core.UI.AnimateWindowFlags.Slide)));
			this.accordion_Dialog.AnimateOpenMillis = 300;
			this.accordion_Dialog.AutoFixDockStyle = true;
			this.accordion_Dialog.AutoScroll = true;
			this.accordion_Dialog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.accordion_Dialog.CheckBoxFactory = null;
			this.accordion_Dialog.CheckBoxMargin = new System.Windows.Forms.Padding(0);
			this.accordion_Dialog.ContentBackColor = null;
			this.accordion_Dialog.ContentMargin = null;
			this.accordion_Dialog.ContentPadding = new System.Windows.Forms.Padding(5);
			this.accordion_Dialog.ControlBackColor = null;
			this.accordion_Dialog.ControlMinimumHeightIsItsPreferredHeight = true;
			this.accordion_Dialog.ControlMinimumWidthIsItsPreferredWidth = true;
			this.accordion_Dialog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.accordion_Dialog.DownArrow = null;
			this.accordion_Dialog.FillHeight = true;
			this.accordion_Dialog.FillLastOpened = false;
			this.accordion_Dialog.FillModeGrowOnly = false;
			this.accordion_Dialog.FillResetOnCollapse = false;
			this.accordion_Dialog.FillWidth = true;
			this.accordion_Dialog.GrabCursor = System.Windows.Forms.Cursors.SizeNS;
			this.accordion_Dialog.GrabRequiresPositiveFillWeight = true;
			this.accordion_Dialog.GrabWidth = 6;
			this.accordion_Dialog.GrowAndShrink = true;
			this.accordion_Dialog.Insets = new System.Windows.Forms.Padding(0);
			this.accordion_Dialog.Location = new System.Drawing.Point(0, 0);
			this.accordion_Dialog.Name = "accordion_Dialog";
			this.accordion_Dialog.OpenOnAdd = false;
			this.accordion_Dialog.OpenOneOnly = false;
			this.accordion_Dialog.ResizeBarFactory = null;
			this.accordion_Dialog.ResizeBarsAlign = 0.5D;
			this.accordion_Dialog.ResizeBarsArrowKeyDelta = 10;
			this.accordion_Dialog.ResizeBarsFadeInMillis = 800;
			this.accordion_Dialog.ResizeBarsFadeOutMillis = 800;
			this.accordion_Dialog.ResizeBarsFadeProximity = 24;
			this.accordion_Dialog.ResizeBarsFill = 1D;
			this.accordion_Dialog.ResizeBarsKeepFocusAfterMouseDrag = false;
			this.accordion_Dialog.ResizeBarsKeepFocusIfControlOutOfView = true;
			this.accordion_Dialog.ResizeBarsKeepFocusOnClick = true;
			this.accordion_Dialog.ResizeBarsMargin = null;
			this.accordion_Dialog.ResizeBarsMinimumLength = 50;
			this.accordion_Dialog.ResizeBarsStayInViewOnArrowKey = true;
			this.accordion_Dialog.ResizeBarsStayInViewOnMouseDrag = true;
			this.accordion_Dialog.ResizeBarsStayVisibleIfFocused = true;
			this.accordion_Dialog.ResizeBarsTabStop = true;
			this.accordion_Dialog.ShowPartiallyVisibleResizeBars = false;
			this.accordion_Dialog.ShowToolMenu = true;
			this.accordion_Dialog.ShowToolMenuOnHoverWhenClosed = false;
			this.accordion_Dialog.ShowToolMenuOnRightClick = true;
			this.accordion_Dialog.ShowToolMenuRequiresPositiveFillWeight = false;
			this.accordion_Dialog.Size = new System.Drawing.Size(606, 253);
			this.accordion_Dialog.TabIndex = 0;
			this.accordion_Dialog.UpArrow = null;


			this.panel1.Controls.Add(this.accordion_Dialog);

			accordion_Dialog.CheckBoxMargin = new Padding(2);
			accordion_Dialog.ContentMargin = new Padding(15, 5, 15, 5);
			accordion_Dialog.ContentPadding = new Padding(1);
			accordion_Dialog.Insets = new Padding(5);
			accordion_Dialog.ControlBackColor = Color.White;
			accordion_Dialog.ContentBackColor = Color.CadetBlue;

		}
	}
}
