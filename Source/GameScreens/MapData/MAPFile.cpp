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
	for each (Layer* layer in events)
		delete layer;
}

bool MAPFile::initialize(ID3D11Device* device) {

	if (!loadMapDescription())
		return false;
	if (!loadTileset(device))
		return false;
	if (!loadLayerData())
		return false;
	return true;
}



bool MAPFile::loadMapDescription() {

	mapWidth = mapRoot.attribute("width").as_int();
	mapHeight = mapRoot.attribute("height").as_int();
	tileWidth = mapRoot.attribute("tilewidth").as_int();
	tileHeight = mapRoot.attribute("tileheight").as_int();

	trueMapWidth = mapWidth*tileWidth;
	trueMapHeight = mapHeight*tileHeight;

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
			layer->load(layerNode, spriteDict);

		} else if (strcmp(layerNode.name(), "objectgroup") == 0) {

		// this is where the PC starts on the map
			if (strcmp(layerNode.attribute("name").as_string(), "Start") == 0) {

				int x = layerNode.child("object").attribute("x").as_int()/* +
					layerNode.child("object").attribute("width").as_int() / 2*/;
				int y = layerNode.child("object").attribute("y").as_int()/* +
					layerNode.child("object").attribute("height").as_int() / 2*/;
				startPos = Vector2(x, y);

					// set PC start position
				PC::pc->gameObject->position.x = x;
				PC::pc->gameObject->position.y = y;
				PC::pc->gameObject->setRect();
				continue;
			}

			if (strcmp(layerNode.attribute("name").as_string(), "NPC") == 0) {

				layer = new CharacterLayer();
				((CharacterLayer*) layer)->load(layerNode, spriteDict);
				collidable.push_back(layer);
				interactable.push_back(layer);

			} else if (strcmp(layerNode.attribute("name").as_string(), "Collision") == 0) {

				layer = new CollisionLayer();
				layer->load(layerNode, spriteDict);
				collidable.push_back(layer);


			} else if (strcmp(layerNode.attribute("name").as_string(), "Triggered Events") == 0) {

				layer = new TriggerLayer();
				layer->load(layerNode, spriteDict);
				events.push_back((TriggerLayer*) layer);

			} else // missing Search
				continue;

		} else
			continue;


		layer->name = layerNode.attribute("name").as_string(); // leaving this here just as a check to see if everything is going right
		layers.push_back(layer);
	}

	return true;
}



