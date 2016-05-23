using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MakerEngine {
	/// <summary>
	/// Main form is getting bloated so I'm encapsulating functions based around
	/// tmx files here.
	/// </summary>
	class TMXFile {

		XmlDocument tmx;


		public String orientation;
		public int width, height;
		public int tileWidth, tileHeight;

		public List<Image> tilesets;
		

		public TMXFile(String tmxfile) {

			tmx = new XmlDocument();
			tmx.Load(tmxfile);

			loadMapDescription();
			loadTilesets();

		}

		private void loadMapDescription() {
			
			XmlNode map = tmx.GetElementsByTagName("map")[0];
			orientation = map.Attributes["orientation"].InnerText;
			width = Int32.Parse(map.Attributes["width"].InnerText);
			height = Int32.Parse(map.Attributes["height"].InnerText);
			tileWidth = Int32.Parse(map.Attributes["tilewidth"].InnerText);
			tileHeight = Int32.Parse(map.Attributes["tileheight"].InnerText);

		}

		private void loadTilesets() {

			tilesets = new List<Image>();

			foreach (XmlNode tileset in tmx.GetElementsByTagName("image")) {

				tilesets.Add(Image.FromFile(tileset.Attributes["source"].InnerText));

			}
		}
	}
}
