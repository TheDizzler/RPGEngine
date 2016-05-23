using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
		/// <summary>
		/// In tiles (not pixels)!
		/// </summary>
		public int mapWidth, mapHeight;
		public int tileWidth, tileHeight;

		private List<Image> tilesets;
		public Dictionary<int, Image> imageDict;

		public List<Layer> layers;


		public TMXFile(String tmxfile) {

			tmx = new XmlDocument();
			tmx.Load(tmxfile);

			loadMapDescription();
			loadTilesets();
			loadLayerData();

		}

		private void loadLayerData() {

			layers = new List<Layer>();

			foreach (XmlNode layerNode in tmx.GetElementsByTagName("layer")) {

				Layer layer = new Layer(layerNode.FirstChild.InnerText);
				layer.name = layerNode.Attributes["name"].InnerText;
				layer.width = Int32.Parse(layerNode.Attributes["width"].InnerText);
				layer.height = Int32.Parse(layerNode.Attributes["height"].InnerText);
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

		public Image getMap() {


			int width = mapWidth * tileWidth;
			int height = mapHeight * tileHeight;
			Image img = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(img);
			g.Clear(SystemColors.AppWorkspace);

			foreach (Layer layer in layers) {
				for (int j = 0; j < mapHeight; ++j) {
					for (int i = 0; i < mapWidth; ++i) {

						int key = layer.csv[j][i];
						if (key != 0)
							g.DrawImage(imageDict[key], new Point(i * tileWidth, j * tileHeight));
						//g.DrawImage(imageDict[1], new Point(tileWidth * i++, tileHeight * j));
						//g.DrawImage(imageDict[1], new Point(tileWidth * i++, tileHeight * j));
						//g.DrawImage(imageDict[3], new Point(tileWidth * i++, tileHeight * j));
						//g.DrawImage(imageDict[2], new Point(tileWidth * i++, tileHeight * j));
						//i = 0;
						//++j;
						//g.DrawImage(imageDict[4], new Point(tileWidth * i++, tileHeight * j));
						//g.DrawImage(imageDict[4], new Point(tileWidth * i++, tileHeight * j));

					}
				}
			}
			g.Dispose();
			String outputFileName = @"D:\github projects\test.bmp";
			//img.Save(final, System.Drawing.Imaging.ImageFormat.Bmp);
			//img.Dispose();

			using (MemoryStream memory = new MemoryStream()) {
				using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite)) {
					img.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
					byte[] bytes = memory.ToArray();
					fs.Write(bytes, 0, bytes.Length);
				}
			}
			img.Dispose();

			return Image.FromFile(outputFileName);
		}
	}


	class Layer {

		public String name;
		public int width, height;
		public List<List<int>> csv;


		public Layer(String text) {

			using (StringReader reader = new StringReader(text)) {

				string line = reader.ReadLine();

				csv = new List<List<int>>();

				while ((line = reader.ReadLine()) != null) {

					List<int> row = new List<int>();
					String[] gids = line.Split(',');
					foreach (string gid in gids) {
						if (!String.IsNullOrWhiteSpace(gid))
							row.Add(Int32.Parse(gid));
					}

					csv.Add(row);

				}
			}
		}
	}
}
