using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MakerEngine {
	class TreeXMLNode : TreeNode {

		public XmlNode node;


		public TreeXMLNode(XmlNode nd) {

			node = nd;

			if (node.Attributes["speaker"] != null)
				this.Text = node.Attributes["speaker"].InnerText;
			else if (node.Attributes["location"] != null)
				this.Text = node.Attributes["location"].InnerText;
		}

		public TreeXMLNode(XmlNode nd, TreeXMLNode[] children) : base("", children) {

			node = nd;

			if (nd.Attributes["type"] != null)
				this.Text = nd.Attributes["type"].InnerText;
			else if (nd.Attributes["location"] != null)
				this.Text = nd.Attributes["location"].InnerText;
		}

		/// <summary>
		/// Constructor for Sprite TreeView.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="nd"></param>
		public TreeXMLNode(String name, XmlNode nd){

			node = nd;
			this.Text = name;
		}


		/// <summary>
		/// Constructor for Sprite TreeView with children.
		/// </summary>
		public TreeXMLNode(String name, TreeXMLNode[] children) : base("", children) {

			this.Text = name;
		}
	}
}
