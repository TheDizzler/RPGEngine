#include "MAPFile.h"

#include "../../globals.h"
MAPFile::MAPFile(xml_node maprt) {

	mapRoot = maprt;

}

MAPFile::~MAPFile() {
	for each (SpriteSheet* sheet in spriteSheets)
		delete sheet;
	for each (Layer* layer in layers)
		delete layer;
}

bool MAPFile::initialize(ID3D11Device * device) {

	if (!loadMapDescription())
		return false;
	if (!loadTileset(device))
		return false;
	if (!loadLayerData())
		return false;
	return true;
}

void MAPFile::draw(SpriteBatch* batch) {


	for each (Layer* layer in layers) {

		layer->draw(batch, spriteDict);

	}

}


bool MAPFile::loadMapDescription() {

	mapWidth = mapRoot.attribute("width").as_int();
	mapHeight = mapRoot.attribute("height").as_int();
	tileWidth = mapRoot.attribute("tilewidth").as_int();
	tileHeight = mapRoot.attribute("tileheight").as_int();

	return true;
}

bool MAPFile::loadTileset(ID3D11Device * device) {


	spriteDict.clear();

	for (xml_node tileset = mapRoot.child("tileset"); tileset; tileset = tileset.next_sibling("tileset")) {


		SpriteSheet* sheet = new SpriteSheet();
		if (!sheet->load(device, tileset)) {
			//MessageBox(0, L"Failed to load spritesheet", L"Error loading sprite sheet", MB_OK);
			return false;
		}
		spriteSheets.push_back(sheet);
		spriteDict.insert(sheet->spriteMap.begin(), sheet->spriteMap.end());
	}

	return true;
}


bool MAPFile::loadLayerData() {

	for each (xml_node layerNode in mapRoot.children()) {

		Layer* layer;


		if (strcmp(layerNode.name(), "layer") == 0) {

			layer = new TileLayer();
			layer->load(layerNode);

		} else if (strcmp(layerNode.name(), "objectgroup") == 0) {

			layer = new ObjectLayer();

			((ObjectLayer*) layer)->load(layerNode);


		} else
			continue;

		// leaving this here just as a check to see if everything is going right
		layer->name = layerNode.attribute("name").as_string();
		layers.push_back(layer);
	}

	return true;
}



