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

			this.Text = node.Attributes["speaker"].InnerText;
		}

		public TreeXMLNode(XmlNode nd, TreeXMLNode[] children) : base(nd.Attributes["type"].InnerText, children) {

			node = nd;
		}
	}
}
