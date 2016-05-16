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

			loadGameXmlFiles();

		}

		

		private void loadGameXmlFiles() {

			docDialogText = new XmlDocument();
			docDialogText.Load(gameDirectory + dialogText);
			XmlNode root = docDialogText.GetElementsByTagName("root")[0];

			this.Text = "Maker Engine - " + root.Attributes["game"].InnerText;

			//build tree view from dialog text
			List<TreeXMLNode> treeNodeList;

			foreach (XmlNode node in root.ChildNodes) {
				//string eventType = node.Attributes["type"].InnerText;

				treeNodeList = new List<TreeXMLNode>();

				foreach (XmlNode child in node.ChildNodes) {

					if (child.Name == "zone") {
						List<TreeXMLNode> subNodeList = new List<TreeXMLNode>();

						foreach (XmlNode sub in child.ChildNodes)
							subNodeList.Add(new TreeXMLNode(sub));

						treeNodeList.Add(new TreeXMLNode(child, subNodeList.ToArray()));

					} else

						treeNodeList.Add(new TreeXMLNode(child));

				}
				treeView_Dialog.Nodes.Add(new TreeXMLNode(node, treeNodeList.ToArray()));
			}



		}

		private void save() {

			XmlWriter writer = XmlWriter.Create(gameDirectory + dialogText);
			docDialogText.Save(writer);

		}


		public void createNewDialogText(XmlNode prevNode, String fromAttribute) {

			String dt = "<dialogText from=\"" + fromAttribute + "\"></dialogText>";
			XmlDocument newXml = new XmlDocument();
			newXml.Load(new StringReader(dt));

			XmlNode newNode = newXml.DocumentElement;
			newNode.InnerText = "Testing";
			XmlNode importNode = docDialogText.ImportNode(newNode, true);
			//XmlNodeList nodeList = docDialogText.GetElementsByTagName(prevNode.Name);
			prevNode.ParentNode.AppendChild(importNode);

			save();

			createDialogTextControl(importNode);
		}


		private void createDialogTextControl(XmlNode node) {

			AccordionDialogTextControl adt = new AccordionDialogTextControl(this, node);

			CheckBox ckboxDialog = accordion_Dialog.Add(adt, adt.getLabel(),
				"A text block", 1, false, contentBackColor: Color.Transparent);
		}

		private void createQueryTextControl(XmlNode node, Accordion queryAcc, int num) {

			AccordionQueryControl aqc = new AccordionQueryControl(this, node);
			queryAcc.Add(aqc, "Option " + num, "Configure Player Choice", 1,
				true, contentBackColor: Color.Transparent);
		}


		private void treeView_Dialog_MouseDoubleClick(Object sender, MouseEventArgs e) {

			TreeXMLNode selected = (TreeXMLNode)treeView_Dialog.SelectedNode;
			if (selected == null)
				return;

			XmlNode selectedNode = selected.node;

			groupBox_AccordionHolder.Controls.Remove(accordion_Dialog);
			accordion_Dialog.Dispose();

			rebuildAccordion();

			if (selectedNode.Attributes["speaker"] != null) {

				textBox_Speaker.Text = selected.Text;

				foreach (XmlNode child in selectedNode.ChildNodes) {

					switch (child.Name) {

						case "dialogText":

							createDialogTextControl(child);
							break;

						case "query":

							Accordion queryAcc = createAccordion();

							int i = child.ChildNodes.Count - 1;
							foreach (XmlNode answer in child.ChildNodes) {

								createQueryTextControl(answer, queryAcc, i++);

							}
							CheckBox ckboxQuery = accordion_Dialog.Add(queryAcc, child.Name,
								"Player text choices", 1, false, contentBackColor: Color.Transparent);
							break;

						case "alphaInput":

							TableLayoutPanel tlp = new TableLayoutPanel {
								Dock = DockStyle.Fill,
								//Padding = new Padding(5)
							};

							Label label = new Label();
							label.Text = "Default Input";
							label.TextAlign = ContentAlignment.MiddleCenter;
							tlp.Controls.Add(label);


							TextBox tb = new TextBox();
							tb.MaxLength = 10;
							tb.Text = child.Attributes["default"].InnerText;
							tlp.Controls.Add(tb);


							accordion_Dialog.Add(tlp, child.Name, 
								"Player keyboard input", 1, false, contentBackColor: Color.Transparent);

							break;
					}
				}

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



		private void rebuildAccordion() {

			this.accordion_Dialog = new Opulos.Core.UI.Accordion();
			this.accordion_Dialog.AddResizeBars = true;
			this.accordion_Dialog.AllowMouseResize = true;
			this.accordion_Dialog.AnimateCloseEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalNegative | Opulos.Core.UI.AnimateWindowFlags.Hide)
			| Opulos.Core.UI.AnimateWindowFlags.Slide)));
			this.accordion_Dialog.AnimateCloseMillis = 150;
			this.accordion_Dialog.AnimateOpenEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalPositive | Opulos.Core.UI.AnimateWindowFlags.Show)
			| Opulos.Core.UI.AnimateWindowFlags.Slide)));
			this.accordion_Dialog.AnimateOpenMillis = 150;
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
			this.accordion_Dialog.FillHeight = false;
			this.accordion_Dialog.FillLastOpened = false;
			this.accordion_Dialog.FillModeGrowOnly = false;
			this.accordion_Dialog.FillResetOnCollapse = false;
			this.accordion_Dialog.FillWidth = true;
			this.accordion_Dialog.GrabCursor = System.Windows.Forms.Cursors.SizeNS;
			this.accordion_Dialog.GrabRequiresPositiveFillWeight = true;
			this.accordion_Dialog.GrabWidth = 6;
			this.accordion_Dialog.GrowAndShrink = true;
			this.accordion_Dialog.Insets = new System.Windows.Forms.Padding(0);
			this.accordion_Dialog.Location = new System.Drawing.Point(3, 16);
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
			this.accordion_Dialog.Size = new System.Drawing.Size(419, 432);
			this.accordion_Dialog.TabIndex = 0;
			this.accordion_Dialog.UpArrow = null;


			this.groupBox_AccordionHolder.Controls.Add(this.accordion_Dialog);

			accordion_Dialog.CheckBoxMargin = new Padding(2);
			accordion_Dialog.ContentMargin = new Padding(15, 5, 15, 5);
			accordion_Dialog.ContentPadding = new Padding(1);
			accordion_Dialog.Insets = new Padding(5);
			accordion_Dialog.ControlBackColor = Color.White;
			accordion_Dialog.ContentBackColor = Color.CadetBlue;

		}


		private Accordion createAccordion() {

			Accordion acc = new Accordion();
			acc.AddResizeBars = false;
			acc.AllowMouseResize = false;
			acc.AnimateCloseEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalNegative | Opulos.Core.UI.AnimateWindowFlags.Hide)
			| Opulos.Core.UI.AnimateWindowFlags.Slide)));
			acc.AnimateCloseMillis = 150;
			acc.AnimateOpenEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalPositive | Opulos.Core.UI.AnimateWindowFlags.Show)
			| Opulos.Core.UI.AnimateWindowFlags.Slide)));
			acc.AnimateOpenMillis = 150;
			acc.AutoFixDockStyle = true;
			acc.AutoScroll = true;
			acc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			acc.CheckBoxFactory = null;
			acc.CheckBoxMargin = new System.Windows.Forms.Padding(0);
			acc.ContentBackColor = null;
			acc.ContentMargin = null;
			acc.ContentPadding = new System.Windows.Forms.Padding(5);
			acc.ControlBackColor = null;
			acc.ControlMinimumHeightIsItsPreferredHeight = true;
			acc.ControlMinimumWidthIsItsPreferredWidth = true;
			acc.Dock = System.Windows.Forms.DockStyle.Fill;
			acc.DownArrow = null;
			acc.FillHeight = false;
			acc.FillLastOpened = false;
			acc.FillModeGrowOnly = false;
			acc.FillResetOnCollapse = false;
			acc.FillWidth = true;
			acc.GrabCursor = System.Windows.Forms.Cursors.SizeNS;
			acc.GrabRequiresPositiveFillWeight = true;
			acc.GrabWidth = 0;
			acc.GrowAndShrink = true;
			acc.Insets = new System.Windows.Forms.Padding(0);
			acc.Location = new System.Drawing.Point(3, 16);
			acc.Name = "accordion_Dialog";
			acc.OpenOnAdd = false;
			acc.OpenOneOnly = false;
			acc.ResizeBarFactory = null;
			acc.ResizeBarsAlign = 0.5D;
			acc.ResizeBarsArrowKeyDelta = 10;
			acc.ResizeBarsFadeInMillis = 800;
			acc.ResizeBarsFadeOutMillis = 800;
			acc.ResizeBarsFadeProximity = 24;
			acc.ResizeBarsFill = 1D;
			acc.ResizeBarsKeepFocusAfterMouseDrag = false;
			acc.ResizeBarsKeepFocusIfControlOutOfView = true;
			acc.ResizeBarsKeepFocusOnClick = true;
			acc.ResizeBarsMargin = null;
			acc.ResizeBarsMinimumLength = 50;
			acc.ResizeBarsStayInViewOnArrowKey = true;
			acc.ResizeBarsStayInViewOnMouseDrag = true;
			acc.ResizeBarsStayVisibleIfFocused = true;
			acc.ResizeBarsTabStop = true;
			acc.ShowPartiallyVisibleResizeBars = false;
			acc.ShowToolMenu = true;
			acc.ShowToolMenuOnHoverWhenClosed = false;
			acc.ShowToolMenuOnRightClick = true;
			acc.ShowToolMenuRequiresPositiveFillWeight = false;
			acc.Size = new System.Drawing.Size(419, 432);
			acc.TabIndex = 0;
			acc.UpArrow = null;


			acc.CheckBoxMargin = new Padding(2);
			acc.ContentMargin = new Padding(15, 5, 15, 5);
			acc.ContentPadding = new Padding(1);
			acc.Insets = new Padding(5);
			acc.ControlBackColor = Color.White;
			acc.ContentBackColor = Color.CadetBlue;

			return acc;
		}

	}
}
