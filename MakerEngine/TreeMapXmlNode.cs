using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MakerEngine {
	class TreeMapXMLNode : TreeXMLNode{

		public TMXFile tmxFile;

		public TreeMapXMLNode(String name, XmlNode nd) : base(name, nd) {


		}


	}
}
