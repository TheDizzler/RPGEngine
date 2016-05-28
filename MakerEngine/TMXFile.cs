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
	class TMXFile : IDisposable {

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
		public Dictionary<int, Image> imageDict;
		public List<Layer> layers;
		public List<ObjectLayer> objectLayers;


		public String layerImageDir = MakerEngineForm.gameDirectory + MakerEngineForm.mapDir + @"tempimgs\";
		public String missingNOImg = MakerEngineForm.gameDirectory + MakerEngineForm.gfxDir + "missingNO.dds";

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

			objectLayers = new List<ObjectLayer>();
			foreach (XmlNode objLayer in tmx.GetElementsByTagName("objectgroup")) {

				objectLayers.Add(new ObjectLayer(objLayer));

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
			imageDict = new Dictionary<int, Image>();


			foreach (XmlNode tilesetNode in tmx.GetElementsByTagName("tileset")) {

				String file = MakerEngineForm.gameDirectory + tilesetNode.ChildNodes[0].Attributes["source"].InnerText;
				if (!File.Exists(file)) {
					//MessageBox.Show("Cannot find tileset image " + file);
					continue;
				}
				TileSet tileset = new TileSet(tilesetNode);
				tilesets.Add(tileset);

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
						if (key != 0) {
							//Image tileImg;
							if (!imageDict.ContainsKey(key))
								imageDict[key] = new S16.Drawing.DDSImage(File.ReadAllBytes(missingNOImg)).BitmapImage;
							g.DrawImage(imageDict[key], new Point(i * tileWidth, j * tileHeight));
						}

					}
				}
				String dir = layerImageDir;
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

			foreach (ObjectLayer objLayer in objectLayers) {

				Image img = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
				Graphics g = Graphics.FromImage(img);


				foreach (ObjectLayer.GameObject gameObj in objLayer.gameObjects) {

					if (gameObj.gid == -1)
						g.DrawRectangle(Pens.Firebrick, gameObj.getRect());
					else
						g.DrawImage(imageDict[gameObj.gid], new Point(gameObj.x, gameObj.y));
				}

				String dir = layerImageDir;
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
				outputFileName = dir + objLayer.name + " Layer.png";
				using (MemoryStream memory = new MemoryStream()) {
					using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite)) {
						img.Save(memory, ImageFormat.Png);
						byte[] bytes = memory.ToArray();
						fs.Write(bytes, 0, bytes.Length);
					}
				}
				objLayer.image = Image.FromFile(outputFileName);
				g.Dispose();
				img.Dispose();
			}


		}

		public Image getMapImage(CheckBox[] layerCheckBox, CheckBox[] objLayerCheckBox) {


			int width = mapWidth * tileWidth;
			int height = mapHeight * tileHeight;
			Image img = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(img);
			//g.Clear(SystemColors.AppWorkspace);


			for (int i = 0; i < layerCheckBox.Length; ++i) {

				if (layerCheckBox[i].Checked)
					g.DrawImage(layers[i].image, new Point(0, 0));

			}

			for (int i = 0; i < objLayerCheckBox.Length; ++i) {

				if (objLayerCheckBox[i].Checked)
					g.DrawImage(objLayers[i].image, new Point(0, 0));

			}

			String dir = layerImageDir;
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


		public void Dispose() {

			foreach (Layer layer in layers) {
				layer.data.Clear();
				layer.image.Dispose();
				File.Delete(layerImageDir + layer.name + " Layer.png");
			}

			layers.Clear();
			imageDict.Clear();
			tilesets.Clear();
		}
	}


	class TileSet {

		public String name;
		public String file;
		public int tilewidth, tileheight;
		public int tilesetWidth, tilesetHeight;
		public int gid;

		public Image image;

		public List<Animation> animations;


		public TileSet(XmlNode tilesetNode) {


			XmlNode imageNode = tilesetNode.ChildNodes[0];
			file = MakerEngineForm.gameDirectory + imageNode.Attributes["source"].InnerText;

			S16.Drawing.DDSImage ddsImage = new S16.Drawing.DDSImage(File.ReadAllBytes(file));
			image = ddsImage.BitmapImage;



			name = tilesetNode.Attributes["name"].InnerText;
			gid = Int32.Parse(tilesetNode.Attributes["firstgid"].InnerText);

			tilewidth = Int32.Parse(tilesetNode.Attributes["tilewidth"].InnerText);
			tileheight = Int32.Parse(tilesetNode.Attributes["tileheight"].InnerText);

			tilesetWidth = Int32.Parse(imageNode.Attributes["width"].InnerText);
			tilesetHeight = Int32.Parse(imageNode.Attributes["height"].InnerText);


			while ((imageNode = imageNode.NextSibling) != null) {

				if (animations == null)
					animations = new List<Animation>();

				foreach (XmlNode aniNode in imageNode.ChildNodes) {

					animations.Add(new Animation(aniNode));
				}

			}

		}


		public class Animation {

			int tileID;
			List<Frame> frames;

			public Animation(XmlNode aniNode) {

				tileID = Int32.Parse(aniNode.Attributes["id"].InnerText);

				frames = new List<Frame>();

				foreach (XmlNode frameNode in aniNode.ChildNodes)
					frames.Add(new Frame(frameNode));

			}

		}

		class Frame {

			/// <summary>
			/// The tile id tha this frame displays.
			/// </summary>
			int tileid;
			/// <summary>
			/// Length in ms that this frame stays drawn.
			/// </summary>
			int duration;


			public Frame(XmlNode frameNode) {

				tileid = Int32.Parse(frameNode.Attributes["tileid"].InnerText);
				duration = Int32.Parse(frameNode.Attributes["duration"].InnerText);
			}
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


	class ObjectLayer {

		public String name;

		public List<GameObject> gameObjects;
		/// <summary>
		/// Fully realized image of this layer. 
		/// </summary>
		public Image image;


		public ObjectLayer(XmlNode layerNode) {

			name = layerNode.Attributes["name"].InnerText;

			gameObjects = new List<GameObject>();

			foreach (XmlNode obj in layerNode.ChildNodes)
				gameObjects.Add(new GameObject(obj));

		}


		public class GameObject {

			public String name;
			public int id;

			/// <summary>
			/// ID of tile representing this object.
			/// </summary>
			public int gid = -1;
			/// <summary>
			/// Top-left coordinates of rect
			/// </summary>
			public int x, y;
			public int width, height;


			public GameObject(XmlNode objNode) {

				name = objNode.Attributes["name"].InnerText;
				id = Int32.Parse(objNode.Attributes["id"].InnerText);

				if (objNode.Attributes["gid"] != null)
					gid = Int32.Parse(objNode.Attributes["gid"].InnerText);

				x = Int32.Parse(objNode.Attributes["x"].InnerText);
				y = Int32.Parse(objNode.Attributes["y"].InnerText);
				width = Int32.Parse(objNode.Attributes["width"].InnerText);
				height = Int32.Parse(objNode.Attributes["height"].InnerText);
			}


			public Rectangle getRect() {

				return new Rectangle(x, y, width, height);
			}

		}
	}


}
