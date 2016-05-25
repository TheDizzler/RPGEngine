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
	/// tmx/map files here.
	/// </summary>
	class TMXFile {

		public XmlDocument tmx;

		public String name;
		public String file;

		public String orientation;
		/// <summary>
		/// In tiles (not pixels)!
		/// </summary>
		public int mapWidth, mapHeight;
		public int tileWidth, tileHeight;

		public List<TileSet> tilesets;
		//public Dictionary<String, Image> tilesetDict;
		public Dictionary<int, Image> imageDict;

		public List<Layer> layers;


		public TMXFile(String mapfile, String mapName, bool converting) {

			file = mapfile;
			tmx = new XmlDocument();
			tmx.Load(file);


			name = mapName;
			if (!converting) {
				load();
			}

		}

		/// <summary>
		/// Call this manually after converting from tmx file.
		/// </summary>
		public void load() {

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

			tilesets = new List<TileSet>();
			//tilesetDict = new Dictionary<String, Image>();
			imageDict = new Dictionary<int, Image>();


			foreach (XmlNode tilesetNode in tmx.GetElementsByTagName("tileset")) {

				TileSet tileset = new TileSet(tilesetNode);
				tilesets.Add(tileset);

				////tilesetDict.Add(tileset.Attributes["name"].InnerText, image);
				int gid = Int32.Parse(tilesetNode.Attributes["firstgid"].InnerText);

				int tilewidth = Int32.Parse(tilesetNode.Attributes["tilewidth"].InnerText);
				int tileheight = Int32.Parse(tilesetNode.Attributes["tileheight"].InnerText);

				int columns = Int32.Parse(tilesetNode.Attributes["columns"].InnerText);
				int rows = Int32.Parse(tilesetNode.Attributes["tilecount"].InnerText) / columns;

				for (int h = 0; h < rows; ++h) {
					for (int w = 0; w < columns; ++w) {

						Rectangle rect = new Rectangle(w * tilewidth, h * tileheight, tilewidth, tileheight);
						Bitmap source = new Bitmap(tileset.image);

						Image cropped = source.Clone(rect, source.PixelFormat);
						imageDict.Add(gid, cropped);
						++gid;
					}
				}

			}
		}

		private void buildMapImages() {


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
				String dir = @"D:\github projects\" + name + @"tempimgs\";
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
				outputFileName = dir + layer.name + " Layer.png";
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


			for (int i = 0; i < checkBox.Length; ++i) {

				if (checkBox[i].Checked)
					g.DrawImage(layers[i].image, new Point(0, 0));

			}

			String dir = @"D:\github projects\" + name + @"tempimgs\";
			String outputFileName = dir + "final.png";

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


	class TileSet {

		public String name;
		public String file;
		public int tilewidth, tileheight;
		public int tilesetWidth, tilesetHeight;
		public int gid;

		public Image image;


		public TileSet(XmlNode tilesetNode) {


			XmlNode imageNode = tilesetNode.ChildNodes[0];
			file = MakerEngineForm.gameDirectory + imageNode.Attributes["source"].InnerText;

			//String ddsFile = openFileDialog_Sprite.FileName;
			//image = Image.FromFile(file);
			S16.Drawing.DDSImage ddsImage = new S16.Drawing.DDSImage(File.ReadAllBytes(file));
			image = ddsImage.BitmapImage;

			

			name = tilesetNode.Attributes["name"].InnerText;
			gid = Int32.Parse(tilesetNode.Attributes["firstgid"].InnerText);

			tilewidth = Int32.Parse(tilesetNode.Attributes["tilewidth"].InnerText);
			tileheight = Int32.Parse(tilesetNode.Attributes["tileheight"].InnerText);

			tilesetWidth = Int32.Parse(imageNode.Attributes["width"].InnerText);
			tilesetHeight = Int32.Parse(imageNode.Attributes["height"].InnerText);
		}
	}


	class Layer {

		public String name;
		public int width, height;
		public List<List<int>> data;

		/// <summary>
		/// Fully realized image of this layer. 
		/// </summary>
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
