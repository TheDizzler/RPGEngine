using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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


		//public String gameDirectory = "D:/github projects/RPGEngine/";
		public String gameDirectory = AppDomain.CurrentDomain.BaseDirectory + "../../../";

		public String fontDir = "assets/fonts/";
		public String gfxDir = "assets/gfx/";
		public String mapDir = "assets/text/maps/";

		public String dialogText = "assets/text/GameText.xml";
		public String spriteText = "assets/text/SpriteFiles.xml";
		public String mapText = "assets/text/MapLegend.xml";


		XmlDocument docDialogText;
		XmlNode selectedTextNode;
		TreeXMLNode selectedTextTreeNode;

		XmlDocument docSpriteFiles;
		XmlNode selectedSpriteNode;
		TreeXMLNode selectedSpriteTreeNode;

		XmlDocument docMapLegend;
		XmlNode selectedMapNode;
		TMXFile mapTMX;


		public List<CheckBox> checkBoxes;


		List<AccordionControl> accordionControlsList = new List<AccordionControl>();

		private bool changesNeedSaving = false;
		private bool loading = true;


		public MakerEngineForm() {
			InitializeComponent();

			accordion_Dialog.CheckBoxMargin = new Padding(2);
			accordion_Dialog.ContentMargin = new Padding(15, 5, 15, 5);
			accordion_Dialog.ContentPadding = new Padding(1);
			accordion_Dialog.Insets = new Padding(5);
			accordion_Dialog.ControlBackColor = Color.White;
			accordion_Dialog.ContentBackColor = Color.CadetBlue;


			checkBoxes = new List<CheckBox>();


			loadSpriteFilesXml();
			loadMapFiles();
			loadGameTextXml();


		}


		private void loadMapFiles() {

			docMapLegend = new XmlDocument();
			docMapLegend.Load(gameDirectory + mapText);
			XmlNode root = docMapLegend.GetElementsByTagName("root")[0];

			List<TreeMapXMLNode> treeNodeList;

			foreach (XmlNode node in root.ChildNodes) {

				treeNodeList = new List<TreeMapXMLNode>();
				treeView_MapLegend.Nodes.Add(
					new TreeMapXMLNode(node.Attributes["name"].InnerText, node));
			}
		}

		private void loadSpriteFilesXml() {

			treeView_Sprites.Nodes.Clear();

			docSpriteFiles = new XmlDocument();
			docSpriteFiles.Load(gameDirectory + spriteText);
			XmlNode root = docSpriteFiles.GetElementsByTagName("root")[0];

			List<TreeXMLNode> treeNodeList;

			foreach (XmlNode node in root.ChildNodes) {

				treeNodeList = new List<TreeXMLNode>();
				List<TreeXMLNode> subNodeList = new List<TreeXMLNode>();

				switch (node.Name) {
					case "spriteFonts":
						foreach (XmlNode guiNode in node.ChildNodes)
							subNodeList.Add(new TreeXMLNode(guiNode.Attributes["name"].InnerText, guiNode));
						treeView_Sprites.Nodes.Add(new TreeXMLNode("Sprite Fonts", subNodeList.ToArray()));
						break;

					case "gui":
						foreach (XmlNode guiNode in node.ChildNodes)
							subNodeList.Add(new TreeXMLNode(guiNode.Attributes["name"].InnerText, guiNode));
						treeView_Sprites.Nodes.Add(new TreeXMLNode("GUI Sprites", subNodeList.ToArray()));
						break;

					case "map":

						foreach (XmlNode mapNode in node.ChildNodes)
							subNodeList.Add(new TreeXMLNode(mapNode.Attributes["name"].InnerText, mapNode));
						treeView_Sprites.Nodes.Add(new TreeXMLNode("Map Sprites", subNodeList.ToArray()));
						break;

					case "actors":

						foreach (XmlNode actorNode in node.ChildNodes)
							subNodeList.Add(new TreeXMLNode(actorNode.Attributes["name"].InnerText, actorNode));
						treeView_Sprites.Nodes.Add(new TreeXMLNode("Actor Sprites", subNodeList.ToArray()));
						break;

					case "tmx":
						foreach (XmlNode actorNode in node.ChildNodes)
							subNodeList.Add(new TreeXMLNode(actorNode.Attributes["name"].InnerText, actorNode));
						treeView_Sprites.Nodes.Add(new TreeXMLNode("TMX Imports", subNodeList.ToArray()));
						break;
				}
			}
		}

		private void loadGameTextXml() {

			docDialogText = new XmlDocument();
			docDialogText.Load(gameDirectory + dialogText);
			XmlNode root = docDialogText.GetElementsByTagName("root")[0];

			this.Text = "Maker Engine - " + root.Attributes["game"].InnerText;

			// build tree view from dialog text
			List<TreeXMLNode> treeNodeList;

			foreach (XmlNode node in root.ChildNodes) {

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

			if (selectedTextNode != null) {
				if (selectedTextNode.Attributes["speaker"] == null) {

					MessageBox.Show("Speaker must not be null");

				} else {
					selectedTextNode.Attributes["speaker"].InnerText = textBox_Speaker.Text;
					foreach (AccordionControl control in accordionControlsList) {

						control.saveChanges();

					}
				}


			}

			using (XmlWriter writer = XmlWriter.Create(gameDirectory + dialogText))
				docDialogText.Save(writer);

			using (XmlWriter writer = XmlWriter.Create(gameDirectory + spriteText))
				docSpriteFiles.Save(writer);

			using (XmlWriter writer = XmlWriter.Create(gameDirectory + mapText))
				docMapLegend.Save(writer);

			needSave(false);

			loadSpriteFilesXml();

		}

		public void needSave(Boolean changesMade) {

			if (changesMade) {
				pictureBox_NeedSave.Image = Properties.Resources.Red;
				label_ChangesMade.Text = "Changes made";
				changesNeedSaving = true;
			} else {
				pictureBox_NeedSave.Image = Properties.Resources.Green;
				label_ChangesMade.Text = "No Changes";
				changesNeedSaving = false;
			}
		}

		private void textChanged(Object sender, EventArgs e) {

			if (!loading) {
				needSave(true);
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
			save();
		}


		/** *************************
		 *	Dialog Text Tab Methods. 
		 *	*************************/


		private void button_NewEvent_Click(Object sender, EventArgs e) {

			using (NewEventDialog dialog = new NewEventDialog()) {

				DialogResult dResult = dialog.ShowDialog();

				if (dResult == DialogResult.OK) {

					String eventTag = "<event type=\"\" ></event>";
					XmlDocument newXml = new XmlDocument();
					newXml.Load(new StringReader(eventTag));

					XmlNode newNode = newXml.DocumentElement;

					RadioButton type = dialog.radioButtons_EventSelect
						.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
					newNode.Attributes["type"].InnerText = type.Text;
					XmlNode importNode = docDialogText.ImportNode(newNode, true);
					docDialogText.GetElementsByTagName("root")[0].AppendChild(importNode);
					treeView_Dialog.Nodes.Add(new TreeXMLNode(newNode, new TreeXMLNode[0]));

					loading = false;
					textChanged(null, null);
				}
			}
		}

		private void newLocationToolStripMenuItem_Click(Object sender, EventArgs e) {

			using (NewLocationDialog nld = new NewLocationDialog()) {
				if (nld.ShowDialog() == DialogResult.OK) {

					String eventTag = "<zone location=\"\" ></zone>";
					XmlDocument newXml = new XmlDocument();
					newXml.Load(new StringReader(eventTag));

					XmlNode newNode = newXml.DocumentElement;

					newNode.Attributes["location"].InnerText = nld.textBox_NewLocation.Text;
					XmlNode importNode = docDialogText.ImportNode(newNode, true);
					selectedTextTreeNode.node.AppendChild(importNode);
					selectedTextTreeNode.Nodes.Add(new TreeXMLNode(newNode, new TreeXMLNode[0]));

					loading = false;
					textChanged(null, null);

				}

			}

		}

		public void createNewDialogText(XmlNode prevNode, String fromAttribute) {

			String dt = "<dialogText from=\"" + fromAttribute + "\"></dialogText>";
			XmlDocument newXml = new XmlDocument();
			newXml.Load(new StringReader(dt));

			XmlNode newNode = newXml.DocumentElement;
			XmlNode importNode = docDialogText.ImportNode(newNode, true);
			prevNode.ParentNode.AppendChild(importNode);


			createDialogTextControl(importNode);
		}

		public void createNewInputText(XmlNode prevNode) {

			String dt = "<alphaInput saveTo=\"\" default=\"\" ></alphaInput>";
			XmlDocument newXml = new XmlDocument();
			newXml.Load(new StringReader(dt));

			XmlNode newNode = newXml.DocumentElement;
			XmlNode importNode = docDialogText.ImportNode(newNode, true);
			prevNode.ParentNode.AppendChild(importNode);

			//save();

			createInputControl(importNode);

		}

		private void createDialogTextControl(XmlNode node) {

			AccordionDialogTextControl adt = new AccordionDialogTextControl(this, node);
			accordionControlsList.Add(adt);

			accordion_Dialog.Add(adt, adt.getLabel(),
				"A text block", 1, false, contentBackColor: Color.Transparent);
		}

		private void createQueryTextControl(XmlNode node, Accordion queryAcc, int num) {

			AccordionAnswerControl aqc = new AccordionAnswerControl(this, node);
			accordionControlsList.Add(aqc);

			queryAcc.Add(aqc, "Option " + num, "Configure Player Choice", 1,
				true, contentBackColor: Color.Transparent);
		}

		private void createInputControl(XmlNode node) {
			AccordionInputControl aic = new AccordionInputControl(this, node);
			accordionControlsList.Add(aic);

			accordion_Dialog.Add(
				aic, node.Name, "Player keyboard input", 1, false,
				contentBackColor: Color.Transparent);
		}


		private void treeView_Dialog_MouseDoubleClick(Object sender, MouseEventArgs e) {

			loading = true;

			if (treeView_Dialog.SelectedNode == null)
				return;

			if (changesNeedSaving) {
				// ask to save before changing nodes
				DialogResult result = MessageBox.Show(this,
					"If you don't save all changes will perish!",
					"Save changes first?", MessageBoxButtons.YesNoCancel);
				if (result == DialogResult.Cancel)
					return;
				if (result == DialogResult.Yes)
					save();

			}

			TreeXMLNode selected = (TreeXMLNode)treeView_Dialog.SelectedNode;
			selectedTextNode = selected.node;

			groupBox_AccordionHolder.Controls.Remove(accordion_Dialog);
			accordion_Dialog.Dispose();
			accordionControlsList.Clear();

			rebuildAccordion();

			if (selectedTextNode.Attributes["speaker"] != null) {

				textBox_Speaker.Text = selected.Text;

				foreach (XmlNode child in selectedTextNode.ChildNodes) {
					switch (child.Name) {

						case "dialogText":

							createDialogTextControl(child);
							break;

						case "query":

							TableLayoutPanel flp = new TableLayoutPanel();
							flp.Dock = DockStyle.Fill;
							flp.AutoScroll = true;
							flp.AutoSize = true;
							flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

							AccordionQueryControl aqc = new AccordionQueryControl(this, child);
							flp.Controls.Add(aqc);
							Accordion queryAcc = createAccordion();
							flp.Controls.Add(queryAcc);

							int i = child.ChildNodes.Count - 1;
							foreach (XmlNode answer in child.ChildNodes) {

								createQueryTextControl(answer, queryAcc, i++);

							}
							accordion_Dialog.Add(flp, aqc.getLabel(),
								"Player text choices", 1, false, contentBackColor: Color.Transparent);
							break;

						case "alphaInput":

							createInputControl(child);
							break;
					}
				}

			}

			loading = false;
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
			acc.AutoSize = true;
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

		private void addNewDialogToolStripMenuItem_Click(Object sender, EventArgs e) {

			TreeXMLNode selected = (TreeXMLNode)treeView_Dialog.SelectedNode;

			if (selected.node == null || selected.node.Name != "event") {
				MessageBox.Show("A dialog must be nested in an event");
				return;
			}
		}

		/// <summary>
		/// Display context menu on Dialog Event tree view.
		/// </summary>
		private void mouseUp_EventsTreeView(Object sender, MouseEventArgs e) {


			if (e.Button == MouseButtons.Right) {

				selectedTextTreeNode = (TreeXMLNode)treeView_Dialog.GetNodeAt(e.Location);

				if (selectedTextTreeNode == null)
					return;

				switch (selectedTextTreeNode.Text) {
					case "Zone Text":
						Point loc = PointToScreen(e.Location);
						loc.Y += contextMenuStrip_MapLegend.Size.Height;
						loc.X += contextMenuStrip_MapLegend.Size.Width / 4;
						contextMenuStrip_ZoneText.Show(loc);
						break;
				}
			}
		}


		/** ************************
		 *	Sprite Loader Tab Methods.
		 *	************************ */

		private void button_LoadSprite_Click(Object sender, EventArgs e) {


			if (openFileDialog_Sprite.ShowDialog() == DialogResult.OK) {

				String ddsFile = openFileDialog_Sprite.FileName;
				S16.Drawing.DDSImage ddsImage = new S16.Drawing.DDSImage(File.ReadAllBytes(ddsFile));
				pictureBox_SpriteView.Image = ddsImage.BitmapImage;
				textBox_Dimensions.Text = ddsImage.BitmapImage.Width + ", " + ddsImage.BitmapImage.Height;
				textBox_SpriteFilePath.Text = ddsFile;
			}
		}

		private void pictureBox_SpriteView_Click(Object sender, EventArgs e) {


			using (ColorDialog dialog = new ColorDialog()) {

				if (dialog.ShowDialog() == DialogResult.OK) {

					pictureBox_SpriteView.BackColor = dialog.Color;

				}

			}
		}

		private void button_Zoom_Click(Object sender, EventArgs e) {


			//Size newSize = new Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
			//Bitmap bmp = new Bitmap(originalBitmap, newSize);
		}

		private void treeView_Sprites_MouseClick(Object sender, MouseEventArgs e) {

			treeView_Sprites.SelectedNode = (TreeXMLNode)treeView_Dialog.GetNodeAt(e.Location);

		}

		private void treeView_Sprites_MouseDoubleClick(Object sender, MouseEventArgs e) {

			selectedSpriteTreeNode = (TreeXMLNode)treeView_Sprites.SelectedNode;
			if (selectedSpriteTreeNode == null)
				return;
			selectedSpriteNode = selectedSpriteTreeNode.node;
			if (selectedSpriteNode == null || selectedSpriteNode.Name != "sprite")
				return;
			String ddsFile = gameDirectory + selectedSpriteNode.Attributes["file"].InnerText;
			S16.Drawing.DDSImage ddsImage = new S16.Drawing.DDSImage(File.ReadAllBytes(ddsFile));
			pictureBox_SpriteView.Image = ddsImage.BitmapImage;
			textBox_Dimensions.Text = ddsImage.BitmapImage.Width + ", " + ddsImage.BitmapImage.Height;
			textBox_SpriteFilePath.Text = ddsFile;
		}

		private void button_CreateSpriteFont_Click(Object sender, EventArgs e) {

			using (SelectFontDialog dialog = new SelectFontDialog()) {

				if (dialog.ShowDialog() == DialogResult.OK) {

					String font = ((Font)dialog.listBox_FontList.SelectedItem).Name;
					String fontName = dialog.textBox_FontName.Text;
					String fontFilePath = fontDir + fontName + ".spritefont";
					String fontFullFilePath = gameDirectory + fontFilePath;
					String fontSize = "" + dialog.numericUpDown_FontSize.Value;

					ProcessStartInfo start = new ProcessStartInfo();
					start.FileName = "\"" + gameDirectory + fontDir + "MakeSpriteFont\"";
					start.Arguments = "\"" + font + "\" \"" + fontFullFilePath + "\" /FontSize:" + fontSize;
					start.WindowStyle = ProcessWindowStyle.Normal;
					start.CreateNoWindow = false;
					start.ErrorDialog = true;

					using (Process proc = Process.Start(start)) {

						proc.WaitForExit();

						if (proc.ExitCode != 0) {
							MessageBox.Show(this, "Could not create Sprite Font!", "Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						String dt = "<font name=\"" + fontName + "\" file=\"" + fontFilePath
							+ "\" fontSize=\"" + fontSize + "\" />";
						XmlDocument newXml = new XmlDocument();
						newXml.Load(new StringReader(dt));

						XmlNode newNode = newXml.DocumentElement;
						XmlNode importNode = docSpriteFiles.ImportNode(newNode, true);

						XmlNode sf = docSpriteFiles.GetElementsByTagName("spriteFonts")[0];
						XmlNode prevNode = sf.LastChild;
						prevNode.ParentNode.AppendChild(importNode);

						TreeNode[] sfTreeNodes = treeView_Sprites.Nodes.Find("Sprite Fonts", false);
						if (sfTreeNodes.Length <= 0) {
							MessageBox.Show(this, "Could not find Sprite Font child in Tree View! "
								+ spriteText + " could be corrupted!", "Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						TreeXMLNode sfTreeNode = (TreeXMLNode)sfTreeNodes[0];
						if (sfTreeNode != null) {
							sfTreeNode.Nodes.Add(new TreeXMLNode(importNode.Attributes["name"].InnerText, importNode));
							needSave(true);

						}
					}
				}
			}
		}


		/** *********************
		 *	Map Tab Methods
		 * ********************** */

		private void treeView_MapLegend_MouseDoubleClick(Object sender, MouseEventArgs e) {

			TreeMapXMLNode tmxl = ((TreeMapXMLNode)treeView_MapLegend.SelectedNode);
			selectedMapNode = tmxl.node;

			if (mapTMX != null && mapTMX == tmxl.tmxFile)
				return;

			mapTMX = tmxl.tmxFile;

			loadMap(selectedMapNode);
			tmxl.tmxFile = mapTMX;

		}

		private void loadMap(XmlNode mapNode) {

			if (mapTMX == null) // load .tmx file
				mapTMX = new TMXFile(gameDirectory + mapNode.Attributes["file"].InnerText, mapNode.Attributes["name"].InnerText);

			this.tableLayoutPanel_LayersGroupBox.Controls.Clear();
			this.checkBoxes.Clear();
			this.tableLayoutPanel_LayersGroupBox.RowCount = mapTMX.layers.Count;

			int row = 0;

			foreach (Layer layer in mapTMX.layers) {

				CheckBox cb = new CheckBox();

				cb.Text = layer.name;
				cb.Checked = true;
				cb.CheckedChanged += new System.EventHandler(this.checkBoxLayerSelect_CheckedChanged);
				this.tableLayoutPanel_LayersGroupBox.Controls.Add(cb, 0, row++);
				this.checkBoxes.Add(cb);
			}


			textBox_MapName.Text = mapNode.Attributes["file"].InnerText;
			textBox_Orientation.Text = mapTMX.orientation;
			textBox_MapDimensions.Text = mapTMX.mapWidth + ", " + mapTMX.mapHeight;
			textBox_TileDimensions.Text = mapTMX.tileWidth + ", " + mapTMX.tileHeight;

			foreach (KeyValuePair<int, Image> entry in mapTMX.imageDict) {

				imageTMXList.Images.Add(entry.Value);

			}


			tabControl_ImageViewer.TabPages.Clear();
			this.tabControl_ImageViewer.Controls.Clear();

			foreach (TileSet tileset in mapTMX.tilesets) {
				PictureBox pb = new PictureBox();
				pb.SizeMode = PictureBoxSizeMode.AutoSize;
				pb.Image = tileset.image;

				TabPage newTab = new TabPage();
				newTab.Location = new System.Drawing.Point(4, 22);
				newTab.Name = tileset.name + " tabPage";
				newTab.Padding = new System.Windows.Forms.Padding(3);
				newTab.Size = new System.Drawing.Size(317, 264);
				newTab.TabIndex = 0;
				newTab.Text = tileset.name;
				newTab.UseVisualStyleBackColor = true;
				newTab.Controls.Add(pb);
				this.tabControl_ImageViewer.Controls.Add(newTab);
			}

			if (pictureBox_Map.Image != null)
				pictureBox_Map.Image.Dispose();
			pictureBox_Map.Image = mapTMX.getMapImage(checkBoxes.ToArray());
		}


		private void toolStripMenuItem_AddMap_Click(Object sender, EventArgs e) {

			if (openFileDialog_TMXFile.ShowDialog() == DialogResult.OK) {

				String file = openFileDialog_TMXFile.FileName;

				int index = file.LastIndexOf('/');
				if (index <= 0)
					index = file.LastIndexOf('\\');

				String name = file.Substring(index + 1);
				int lastIndex = file.LastIndexOf('.');
				int length = lastIndex - index;
				String shortname = file.Substring(index + 1, length - 1);

				String eventTag = "<map name=\"" + shortname + "\" file=\"" + mapDir + name + "\" ></map>";
				XmlDocument newXml = new XmlDocument();
				newXml.Load(new StringReader(eventTag));

				XmlNode newNode = newXml.DocumentElement;
				XmlNode importNode = docMapLegend.ImportNode(newNode, true);
				docMapLegend.GetElementsByTagName("root")[0].AppendChild(importNode);

				loading = false;
				textChanged(null, null);

				TreeMapXMLNode tmxl = new TreeMapXMLNode(importNode.Attributes["name"].InnerText, importNode);
				treeView_MapLegend.Nodes.Add(tmxl);
				loadMap(importNode);
				tmxl.tmxFile = mapTMX;

			}
		}

		private void toolStripMenuItem_RemoveMap_Click(Object sender, EventArgs e) {

		}

		private void checkBoxLayerSelect_CheckedChanged(Object sender, EventArgs e) {

			pictureBox_Map.Image.Dispose();
			pictureBox_Map.Image = mapTMX.getMapImage(checkBoxes.ToArray());

		}

		private void toolStripButton_HideLeftPanel_Click(Object sender, EventArgs e) {

			splitContainer_Main.Panel1Collapsed = !splitContainer_Main.Panel1Collapsed;
		}

		private void toolStripButton_HideSpritePanel_Click(Object sender, EventArgs e) {

			if (splitContainer_Base.Panel2Collapsed) {
				splitContainer_Base.Panel2Collapsed = false;
				splitContainer_MapTools.Panel2Collapsed = false;

			} else {
				if (splitContainer_MapTools.Panel1Collapsed)
					splitContainer_Base.Panel2Collapsed = true;
				else
					splitContainer_MapTools.Panel2Collapsed = !splitContainer_MapTools.Panel2Collapsed;
			}
		}

		private void toolStripButton_HideLayerSelect_Click(Object sender, EventArgs e) {

			if (splitContainer_Base.Panel2Collapsed) {
				splitContainer_Base.Panel2Collapsed = false;
				splitContainer_MapTools.Panel1Collapsed = false;

			} else {
				if (splitContainer_MapTools.Panel2Collapsed)
					splitContainer_Base.Panel2Collapsed = true;
				else
					splitContainer_MapTools.Panel1Collapsed = !splitContainer_MapTools.Panel1Collapsed;
			}
		}


		private void treeView_MapLegend_MouseDown(Object sender, MouseEventArgs e) {

			if (e.Button == MouseButtons.Right) {

				TreeXMLNode selected = (TreeXMLNode)treeView_MapLegend.GetNodeAt(e.Location);

				if (selected == null) {
					this.toolStripMenuItem_AddMap.Enabled = true;
					this.toolStripMenuItem_RemoveMap.Enabled = false;
				} else {
					this.toolStripMenuItem_AddMap.Enabled = false;
					this.toolStripMenuItem_RemoveMap.Enabled = true;
				}

				Point loc = PointToScreen(e.Location);
				loc.Y += contextMenuStrip_MapLegend.Size.Height;
				loc.X += contextMenuStrip_MapLegend.Size.Width / 4;
				contextMenuStrip_MapLegend.Show(loc);
			}
		}


		private void button_ConvertTMX_Click(Object sender, EventArgs e) {

			if (mapTMX == null)
				return;

			String newMapFile = mapTMX.file.Substring(0, mapTMX.file.Length - 3) + "map";
			if (File.Exists(newMapFile)) {
				DialogResult result
					= MessageBox.Show(this, "Map file already exists. Overwrite?",
						"Overwrite?", MessageBoxButtons.YesNo);
				if (result == DialogResult.No) {
					MessageBox.Show("No changes saved.");
					return;
				}
			}

			File.Copy(mapTMX.file, newMapFile, true);

			XmlDocument newMap = new XmlDocument();
			newMap.Load(newMapFile);

			String texconv = "\"D:\\github projects\\RPGEngine\\assets\\gfx\\texconv\\texconv.exe\"";
			String outputDir = "assets/gfx/tmx";

			foreach (TileSet tileset in mapTMX.tilesets) {
				ProcessStartInfo start = new ProcessStartInfo();
				start.FileName = texconv;
				start.Arguments = /*" -o " + outputDir*/
								  /*+ */" \"" + tileset.file + "\""; // having problems getting -o switch to work so manually moving files after creation
				start.WindowStyle = ProcessWindowStyle.Normal;
				start.CreateNoWindow = false;
				start.ErrorDialog = true;

				using (Process proc = Process.Start(start)) {

					proc.WaitForExit();

					String newFile = tileset.file.Substring(0, tileset.file.Length - 3) + "dds";

					if (!File.Exists(newFile) || proc.ExitCode != 0) { // don't think this ever occurs :/
						MessageBox.Show(this, "Could not convert image to DDS!" + newFile, "Error!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					needSave(true);

					String newFileName = newFile.Substring(newFile.LastIndexOf("/"));
					String newLoc = gameDirectory + outputDir + newFileName;

					XmlNode imageNode = null;
					foreach (XmlNode node in newMap.GetElementsByTagName("tileset"))
						if (node.Attributes["name"].InnerText == tileset.name)
							imageNode = node;
					if (imageNode == null) {
						MessageBox.Show("Can't find " + tileset.name + " in this map.", "SRS problems, bro");
						return;
					}
					imageNode.FirstChild.Attributes["source"].InnerText = outputDir + newFileName;

					try {
						File.Move(newFile, newLoc);

						String dt = "<sprite name=\"" + tileset.name
							+ "\" file=\"" + outputDir + newFileName + "\" />";

						XmlDocument newXml = new XmlDocument();
						newXml.Load(new StringReader(dt));

						XmlNode newNode = newXml.DocumentElement;
						XmlNode importNode = docSpriteFiles.ImportNode(newNode, true);

						XmlNode sf = docSpriteFiles.GetElementsByTagName("tmx")[0];
						sf.AppendChild(importNode);


					} catch (IOException ex) {
						// probably already exists, don't worry about it just continue
						MessageBox.Show(tileset.name + " already exists?");
						File.Delete(newFile);
					}
				}
			}
			using (XmlWriter writer = XmlWriter.Create(newMapFile))
				newMap.Save(writer);
		}
	}
}