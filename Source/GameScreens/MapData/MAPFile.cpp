#include "MAPFile.h"

#include "../../globals.h"
MAPFile::MAPFile(xml_node maprt) {

	mapRoot = maprt;

}

MAPFile::~MAPFile() {
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


	for each (TileLayer* layer in layers) {

		for (int row = 0; row < mapHeight; ++row) {
			for (int col = 0; col < mapWidth; ++col) {

				int key = layer->data[col][row];
				if (key <= 0)
					continue;
				SpriteSheet::SpriteFrame* spriteFrame = spriteDict[key];

				batch->Draw(spriteFrame->sheet->texture.Get(),
					Vector2(row * tileWidth, col *tileHeight),
					&spriteFrame->sourceRect, spriteFrame->tint,
					spriteFrame->rotation, spriteFrame->origin,
					spriteFrame->scale, SpriteEffects_None,
					spriteFrame->layerDepth);
			}
		}
	}

	//sprite->draw(batch);

	//RECT sourceRect = { 32, 32, 32, 32};

	/*batch->Draw(sprite->texture, Vector2(tileWidth, tileHeight),
		&sourceRect, spriteFrame->tint,
		spriteFrame->rotation, spriteFrame->origin, spriteFrame->scale, SpriteEffects_None,
		spriteFrame->layerDepth);*/
}

bool MAPFile::loadMapDescription() {

	mapWidth = mapRoot.attribute("width").as_int();
	mapHeight = mapRoot.attribute("height").as_int();
	tileWidth = mapRoot.attribute("tilewidth").as_int();
	tileHeight = mapRoot.attribute("tileheight").as_int();

	return true;
}

bool MAPFile::loadTileset(ID3D11Device * device) {

	/*sprite.reset(new Sprite());
	if (!sprite->load(device, L"assets/gfx/tmx/grass-tiles-2-small.dds")) {
		MessageBox(0, L"Booooo", L"Error loading sprite sheet", MB_OK);
		return false;
	}*/

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

#include <sstream>
#include <iostream>
#include <algorithm>
bool MAPFile::loadLayerData() {

	for each (xml_node layer in mapRoot.children("layer")) {

		TileLayer* tileLayer = new TileLayer();

		xml_node layerData = layer.child("data");
		if (layerData.attribute("encoding")) { // just gonna assume it's csv

			string str = layerData.text().as_string();

			istringstream datastream(str);
			string line;

			while (getline(datastream, line)) {
				line.erase(remove_if(line.begin(), line.end(), isspace), line.end());
				if (line.length() <= 0)
					continue;
				tileLayer->data.push_back(split(line));
			}
		}

		layers.push_back(tileLayer);
	}

	return true;
}

vector<int> MAPFile::split(string line) {

	vector<int> rowdata;
	stringstream ss(line);
	string token;

	while (getline(ss, token, ',')) {
		int i;
		istringstream(token) >> i;
		rowdata.push_back(i);
	}

	return rowdata;

}
