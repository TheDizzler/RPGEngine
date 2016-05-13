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

namespace MakerEngine {
	public partial class MakerEngineForm : Form {

		public DirectoryInfo workingDirectory;


		public String gameDirectory = "D:/github projects/RPGEngine/";
		public String dialogText = "assets/text/GameText.xml";

		XmlDocument docDialogText;


		public MakerEngineForm() {
			InitializeComponent();

			loadGameXmlFiles();

		}

		private void loadGameXmlFiles() {


			docDialogText = new XmlDocument();
			docDialogText.Load(gameDirectory + dialogText);
			XmlNode root = docDialogText.FirstChild;

			this.Text = "Maker Engine - " + root.Attributes["game"].InnerText;

			//build tree view from dialog text
			List<TreeNode> treeNodeList;

			foreach (XmlNode node in root.ChildNodes) {
				string eventType = node.Attributes["type"].InnerText;

				treeNodeList = new List<TreeNode>();

				foreach (XmlNode child in node.ChildNodes) {
					string speaker = child.Attributes["speaker"].InnerText;

					treeNodeList.Add(new TreeNode(speaker));
				}
				treeView_Dialog.Nodes.Add(new TreeNode(eventType, treeNodeList.ToArray()));
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

	}
}
