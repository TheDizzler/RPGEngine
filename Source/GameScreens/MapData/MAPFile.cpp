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



//#include "../../GameObjects/PC.h"
//void MAPFile::update(double deltaTime, SimpleKeyboard* keys) {
//
//	playerActions(deltaTime, keys);
//
//	for each (Layer* layer in layers)
//		layer->update(deltaTime);
//
//}

//void MAPFile::playerActions(double deltaTime, SimpleKeyboard * keys) {
//
//	Vector2 distanceToTravel(0, 0);
//	float moveAmount = WALK_SPEED * deltaTime;
//
//	if (keys->keyDown[UP]) {
//		distanceToTravel.y = -moveAmount;
//		if (keys->keyDown[RIGHT]) {
//			distanceToTravel.x = (moveAmount) * XM_PIDIV4;
//			distanceToTravel.y *= XM_PIDIV4;
//
//		} else if (keys->keyDown[LEFT]) {
//			distanceToTravel.x = (-moveAmount) * XM_PIDIV4;
//			distanceToTravel.y *= XM_PIDIV4;
//		}
//		PC::pc->gameObject->facing = UP;
//	} else if (keys->keyDown[DOWN]) {
//		distanceToTravel.y = moveAmount;
//		if (keys->keyDown[RIGHT]) {
//			distanceToTravel.x = (moveAmount) * XM_PIDIV4;
//			distanceToTravel.y *= XM_PIDIV4;
//		} else if (keys->keyDown[LEFT]) {
//			distanceToTravel.x = (-moveAmount) * XM_PIDIV4;
//			distanceToTravel.y *= XM_PIDIV4;
//		}
//		PC::pc->gameObject->facing = DOWN;
//	} else if (keys->keyDown[RIGHT]) {
//		distanceToTravel.x = moveAmount;
//		PC::pc->gameObject->facing = RIGHT;
//	} else if (keys->keyDown[LEFT]) {
//		distanceToTravel.x = -moveAmount;
//		PC::pc->gameObject->facing = LEFT;
//	}
//
//	RECT* overlap = checkCollision(&distanceToTravel);
//	if (overlap != NULL) {
//
//		int overlapWidth = overlap->right - overlap->left;
//		int overlapHeight = overlap->bottom - overlap->top;
//		if (overlapWidth < overlapHeight)  // probably coming from right or left
//			distanceToTravel.x = 0;
//		else if (overlapWidth > overlapHeight) // probable coming from top or bottom
//			distanceToTravel.y = 0;
//		else if (overlapWidth == overlapHeight) {
//			/* if they're == then it's at corner. Sometimes gets "Sticky".
//			*	using a tolerance variable in the layer collision method
//			*	seems to alleviate this problem. */
//			if (distanceToTravel.x > 0) // going right
//				PC::pc->gameObject->position.x += overlapWidth;
//			else if (distanceToTravel.x < 0) // going left
//				PC::pc->gameObject->position.x -= overlapWidth;
//
//			if (distanceToTravel.y > 0) // going down
//				PC::pc->gameObject->position.y += overlapWidth;
//			else if (distanceToTravel.y < 0)
//				PC::pc->gameObject->position.y -= overlapWidth;
//		}
//		delete overlap;
//	}
//
//	if (keys->keyDown[SELECT] && !keys->lastDown[SELECT]) {
//
//		InteractableObject* object = checkInteractable();
//		if (object != NULL) {
//			string name = object->interact();
//			/*int len;
//			int slength = (int) name.length() + 1;
//			len = MultiByteToWideChar(CP_ACP, 0, name.c_str(), slength, 0, 0);
//			wchar_t* buf = new wchar_t[len];
//			MultiByteToWideChar(CP_ACP, 0, name.c_str(), slength, buf, len);
//			std::wstring r(buf);
//			delete[] buf;
//			MessageBox(0, r.c_str(), L"Testing", MB_OK);*/
//
//
//		}
//	}
//
//	PC::pc->update(deltaTime, distanceToTravel);
//}


//InteractableObject* MAPFile::checkInteractable() {
//
//	// check direction facing
//	// look in that direction for an object that can be interacted with
//	for each (Layer* layer in interactable) {
//		InteractableObject* object = layer->checkInteractable(PC::pc.get());
//		if (object != NULL)
//			return object;
//	}
//
//	return NULL;
//}
//
//
//RECT* MAPFile::checkCollision(Vector2* distanceToTravel) {
//
//	RECT* overlap;
//	for each(Layer* layer in collidable) {
//
//		overlap = layer->checkCollision(PC::pc->gameObject.get(), distanceToTravel);
//		if (overlap != NULL) {
//			return overlap;
//				//distanceToTravel.y += (overLap.bottom - overLap.top) + 5;
//				//break;
//		}
//	}
//	return NULL;
//}




//void MAPFile::draw(SpriteBatch* batch) {
//
//	for each (Layer* layer in layers) {
//
//		layer->draw(batch, spriteDict);
//
//	}
//
//}


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
			layer->load(layerNode, spriteDict);

		} else if (strcmp(layerNode.name(), "objectgroup") == 0) {

		// this is where the PC starts on the map
			if (strcmp(layerNode.attribute("name").as_string(), "Start") == 0) {

				int x = layerNode.child("object").attribute("x").as_int()/* +
					layerNode.child("object").attribute("width").as_int() / 2*/;
				int y = layerNode.child("object").attribute("y").as_int()/* +
					layerNode.child("object").attribute("height").as_int() / 2*/;
				//startPos = Vector2(x, y);

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
			} else // missing Search
				continue;

		} else
			continue;


		layer->name = layerNode.attribute("name").as_string(); // leaving this here just as a check to see if everything is going right
		layers.push_back(layer);
	}

	return true;
}



