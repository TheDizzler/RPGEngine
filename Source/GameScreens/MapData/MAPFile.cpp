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

bool MAPFile::initialize(ID3D11Device* device) {

	if (!loadMapDescription())
		return false;
	if (!loadTileset(device))
		return false;
	if (!loadLayerData())
		return false;
	return true;
}

#include "../../GameObjects/PC.h"
void MAPFile::update(double deltaTime, SimpleKeyboard* keys) {

	if (keys->keyDown[UP]) {
	// get max move distance
	// check for collisions and get distance to collision
		Vector2 distanceToTravel(0, -WALK_SPEED*deltaTime);

		for each(Layer* layer in collidable) {

			layer->checkCollision(PC::pc->gameObject.get(), distanceToTravel);

		}
		//PC::pc->update(deltaTime, distanceToTravel);

	} else if (keys->keyDown[DOWN]) {
		//PC::pc->update(deltaTime, Vector2(0, WALK_SPEED*deltaTime));
		Vector2 distanceToTravel(0, WALK_SPEED*deltaTime);

		for each(Layer* layer in collidable) {

			layer->checkCollision(PC::pc->gameObject.get(), distanceToTravel);

		}
	}
	if (keys->keyDown[LEFT]) {
		//PC::pc->update(deltaTime, Vector2(-WALK_SPEED*deltaTime, 0));
		Vector2 distanceToTravel(-WALK_SPEED*deltaTime, 0);

		for each(Layer* layer in collidable) {

			layer->checkCollision(PC::pc->gameObject.get(), distanceToTravel);

		}
	} else if (keys->keyDown[RIGHT]) {
		//PC::pc->update(deltaTime, Vector2(WALK_SPEED*deltaTime, 0));
		Vector2 distanceToTravel(WALK_SPEED*deltaTime, 0);

		for each(Layer* layer in collidable) {

			layer->checkCollision(PC::pc->gameObject.get(), distanceToTravel);

		}
	}



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

		// this is where the PC starts on the map
			if (strcmp(layerNode.attribute("name").as_string(), "Start") == 0) {

				int x = layerNode.child("object").attribute("x").as_int()/* +
					layerNode.child("object").attribute("width").as_int() / 2*/;
				int y = layerNode.child("object").attribute("y").as_int()/* +
					layerNode.child("object").attribute("height").as_int() / 2*/;
				//startPos = Vector2(x, y);

					// set PC start position
				PC::pc->gameObject->x = x;
				PC::pc->gameObject->y = y;
				PC::pc->gameObject->setRect();
				continue;
			}

			layer = new ObjectLayer();

			((ObjectLayer*) layer)->load(layerNode);
			if (strcmp(layer->name.c_str(), "Collision") == 0
				|| strcmp(layer->name.c_str(), "NPC")) {
				collidable.push_back(layer);

			}

		} else
			continue;

		// leaving this here just as a check to see if everything is going right
		layer->name = layerNode.attribute("name").as_string();
		layers.push_back(layer);
	}

	return true;
}



