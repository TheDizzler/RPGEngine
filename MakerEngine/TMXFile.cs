using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MakerEngine {

	/// <summary>
	/// Main form is getting bloated so I'm encapsulating functions based around
	/// tmx files here.
	/// </summary>
	class TMXFile {

		XmlDocument tmx;


		public String orientation;
		/// <summary>
		/// In tiles (not pixels)!
		/// </summary>
		public int mapWidth, mapHeight;
		public int tileWidth, tileHeight;

		public List<Image> tilesets;
		public Dictionary<int, Image> imageDict;

		public List<Layer> layers;


		public TMXFile(String tmxfile) {

			tmx = new XmlDocument();
			tmx.Load(tmxfile);

			loadMapDescription();
			loadTilesets();
			loadLayerData();
			buildMapImages();

		}

		private void loadLayerData() {

			layers = new List<Layer>();

			foreach (XmlNode layerNode in tmx.GetElementsByTagName("layer")) {

				Layer layer = new Layer(layerNode);
				layers.Add(layer);
			}

		}

		private void loadMapDescription() {

			XmlNode map = tmx.GetElementsByTagName("map")[0];
			orientation = map.Attributes["orientation"].InnerText;
			mapWidth = Int32.Parse(map.Attributes["width"].InnerText);
			mapHeight = Int32.Parse(map.Attributes["height"].InnerText);
			tileWidth = Int32.Parse(map.Attributes["tilewidth"].InnerText);
			tileHeight = Int32.Parse(map.Attributes["tileheight"].InnerText);

		}

		private void loadTilesets() {

			tilesets = new List<Image>();
			imageDict = new Dictionary<int, Image>();


			foreach (XmlNode tileset in tmx.GetElementsByTagName("tileset")) {

				XmlNode imageNode = tileset.ChildNodes[0];
				Image image = Image.FromFile(imageNode.Attributes["source"].InnerText);

				tilesets.Add(image);

				int gid = Int32.Parse(tileset.Attributes["firstgid"].InnerText);

				int tilewidth = Int32.Parse(tileset.Attributes["tilewidth"].InnerText);
				int tileheight = Int32.Parse(tileset.Attributes["tileheight"].InnerText);

				int tilesetWidth = Int32.Parse(imageNode.Attributes["width"].InnerText);
				int tilesetHeight = Int32.Parse(imageNode.Attributes["height"].InnerText);

				int columns = Int32.Parse(tileset.Attributes["columns"].InnerText);
				int rows = Int32.Parse(tileset.Attributes["tilecount"].InnerText) / columns;

				for (int h = 0; h < rows; ++h) {
					for (int w = 0; w < columns; ++w) {

						//if (w + tilewidth > tilesetWidth || h + tileheight > tilesetHeight)
						//	continue; // sometimes the image file isn't 
						Rectangle rect = new Rectangle(w * tilewidth, h * tileheight, tilewidth, tileheight);
						Bitmap source = new Bitmap(image);

						Image cropped = source.Clone(rect, source.PixelFormat);
						imageDict.Add(gid, cropped);
						++gid;
					}
				}

			}
		}

		public void buildMapImages() {


			int width = mapWidth * tileWidth;
			int height = mapHeight * tileHeight;


			String outputFileName;

			foreach (Layer layer in layers) {


				Image img = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
				Graphics g = Graphics.FromImage(img);

				for (int j = 0; j < mapHeight; ++j) {
					for (int i = 0; i < mapWidth; ++i) {

						int key = layer.data[j][i];
						if (key != 0)
							g.DrawImage(imageDict[key], new Point(i * tileWidth, j * tileHeight));

					}
				}
				outputFileName = @"D:\github projects\" + layer.name + " Layer.png";
				using (MemoryStream memory = new MemoryStream()) {
					using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite)) {
						img.Save(memory, ImageFormat.Png);
						byte[] bytes = memory.ToArray();
						fs.Write(bytes, 0, bytes.Length);
					}
				}
				layer.image = Image.FromFile(outputFileName);
				g.Dispose();
				img.Dispose();
			}


		}


		public Image getMapImage(CheckBox[] checkBox) {


			int width = mapWidth * tileWidth;
			int height = mapHeight * tileHeight;
			Image img = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(img);
			//g.Clear(SystemColors.AppWorkspace);

			//if (checkBox != null) {

			for (int i = 0; i < checkBox.Length; ++i) {

				if (checkBox[i].Checked)
					g.DrawImage(layers[i].image, new Point(0, 0));

			}
			//} else {
			//	foreach (Layer layer in layers)
			//		g.DrawImage(layer.image, new Point(0, 0));
			//}

			String outputFileName = @"D:\github projects\final.png";

			using (MemoryStream memory = new MemoryStream()) {
				using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite)) {
					img.Save(memory, ImageFormat.Png);
					byte[] bytes = memory.ToArray();
					fs.Write(bytes, 0, bytes.Length);
				}
			}

			g.Dispose();
			img.Dispose();

			return Image.FromFile(outputFileName);

		}

	}


	class Layer {

		public String name;
		public int width, height;
		public List<List<int>> data;

		public Image image;


		public Layer(XmlNode layerNode) {

			this.name = layerNode.Attributes["name"].InnerText;
			this.width = Int32.Parse(layerNode.Attributes["width"].InnerText);
			this.height = Int32.Parse(layerNode.Attributes["height"].InnerText);

			this.data = new List<List<int>>();
			XmlNode data = layerNode.FirstChild;

			if (data.Attributes["encoding"] != null && data.Attributes["encoding"].InnerText == "csv") {
				using (StringReader reader = new StringReader(data.InnerText)) {

					string line/* = reader.ReadLine()*/;



					while ((line = reader.ReadLine()) != null) {
						if (String.IsNullOrWhiteSpace(line))
							continue;
						List<int> row = new List<int>();
						String[] gids = line.Split(',');
						foreach (string gid in gids) {
							if (!String.IsNullOrWhiteSpace(gid))
								row.Add(Int32.Parse(gid));
						}

						this.data.Add(row);

					}
				}
			} else {

				int row = 0;
				int col = 0;

				List<int> rowList = new List<int>();

				foreach (XmlNode tile in data.ChildNodes) {

					rowList.Add(Int32.Parse(tile.Attributes["gid"].InnerText));
					++col;
					if (col >= width) {
						++row;
						this.data.Add(rowList);
						rowList = new List<int>();
						col = 0;

					}
				}

			}
		}
	}
}
