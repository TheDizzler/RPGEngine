using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakerEngine {

	/// <summary>
	///  For Layer Control TreeView with checkboxes.
	/// </summary>
	class TreeCheckBoxNode : TreeNode {

		public ObjectLayer.GameObject gameObject;
		/// <summary>
		/// The layer that this game object is contained in.
		/// </summary>
		public ObjectLayer layer;


		public TreeCheckBoxNode(ObjectLayer.GameObject gameObject, ObjectLayer layer) {

			this.gameObject = gameObject;
			this.layer = layer;

			this.Text = gameObject.name;
			this.Name = "" + gameObject.gid;
		}

		//public TreeCheckBoxNode(Layer layer, TreeNode[] treeNode) : base(layer.getName(), treeNode) {
		//	this.layer = layer;



		//}
	}
}
