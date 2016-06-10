#include "MapScreen.h"

MapScreen::MapScreen(pugi::xml_document* doc) {

	rootLegendNode = doc->child("root");
}

MapScreen::~MapScreen() {

}

bool MapScreen::initialize(ID3D11Device* device, TextBoxManager* txtBxMng) {

	textBoxManager = txtBxMng;

	const char* mapFile = rootLegendNode.find_child_by_attribute("name", "Test Village").attribute("file").as_string();

	docCurrentMap.reset(new xml_document());
	if (!docCurrentMap->load_file(mapFile)) {
		int a = lstrlenA(mapFile);
		BSTR unicodestr = SysAllocStringLen(NULL, a);
		MultiByteToWideChar(CP_ACP, 0, mapFile, a, unicodestr, a);
		MessageBox(0, unicodestr, L"Error Reading Map File", MB_OK);
		SysFreeString(unicodestr);
		return false;
	}


	map.reset(new MAPFile(docCurrentMap->child("map")));

	if (!map->initialize(device))
		return false;

	textBoxManager->loadZone("Test Village");


	return true;
}

void MapScreen::setGameManager(Game* gm) {

	game = gm;
}


//void MapScreen::loadMap() {
//
//
//}

void MapScreen::update(double deltaTime, SimpleKeyboard* keys) {


	playerActions(deltaTime, keys);

	for each (Layer* layer in map->layers)
		layer->update(deltaTime);

	textBoxManager->update(deltaTime, keys);
}

#include "../GameObjects/PC.h"
void MapScreen::playerActions(double deltaTime, SimpleKeyboard * keys) {

	Vector2 distanceToTravel(0, 0);
	float moveAmount = WALK_SPEED * deltaTime;

	if (keys->keyDown[UP]) {
		distanceToTravel.y = -moveAmount;
		if (keys->keyDown[RIGHT]) {
			distanceToTravel.x = (moveAmount) * XM_PIDIV4;
			distanceToTravel.y *= XM_PIDIV4;
		} else if (keys->keyDown[LEFT]) {
			distanceToTravel.x = (-moveAmount) * XM_PIDIV4;
			distanceToTravel.y *= XM_PIDIV4;
		}
		PC::pc->gameObject->facing = UP;
		collisionAlgo(&distanceToTravel);
	} else if (keys->keyDown[DOWN]) {
		distanceToTravel.y = moveAmount;
		if (keys->keyDown[RIGHT]) {
			distanceToTravel.x = (moveAmount) * XM_PIDIV4;
			distanceToTravel.y *= XM_PIDIV4;
		} else if (keys->keyDown[LEFT]) {
			distanceToTravel.x = (-moveAmount) * XM_PIDIV4;
			distanceToTravel.y *= XM_PIDIV4;
		}
		PC::pc->gameObject->facing = DOWN;
		collisionAlgo(&distanceToTravel);
	} else if (keys->keyDown[RIGHT]) {
		distanceToTravel.x = moveAmount;
		PC::pc->gameObject->facing = RIGHT;
		collisionAlgo(&distanceToTravel);
	} else if (keys->keyDown[LEFT]) {
		distanceToTravel.x = -moveAmount;
		PC::pc->gameObject->facing = LEFT;
		collisionAlgo(&distanceToTravel);
	}

	

	if (keys->keyDown[SELECT] && !keys->lastDown[SELECT] && !textBoxManager->isTextBoxOpen()) {

		InteractableObject* object = checkInteractable();
		if (object != NULL) {
			textBoxManager->getDialog(object->interact(), &((CharacterObject*)object)->position);
		}
	}

	PC::pc->update(deltaTime, distanceToTravel);
}


void MapScreen::collisionAlgo(Vector2* distanceToTravel) {

	RECT* overlap = checkCollision(distanceToTravel);
	if (overlap != NULL) {

		int overlapWidth = overlap->right - overlap->left;
		int overlapHeight = overlap->bottom - overlap->top;
		if (overlapWidth < overlapHeight)  // probably coming from right or left
			distanceToTravel->x = 0;
		else if (overlapWidth > overlapHeight) // probable coming from top or bottom
			distanceToTravel->y = 0;
		else if (overlapWidth == overlapHeight) {
			/* if they're == then it's at corner. Sometimes gets "Sticky".
			*	using a tolerance variable in the layer collision method
			*	seems to alleviate this problem. */
			if (distanceToTravel->x > 0) // going right
				PC::pc->gameObject->position.x += overlapWidth;
			else if (distanceToTravel->x < 0) // going left
				PC::pc->gameObject->position.x -= overlapWidth;

			if (distanceToTravel->y > 0) // going down
				PC::pc->gameObject->position.y += overlapWidth;
			else if (distanceToTravel->y < 0)
				PC::pc->gameObject->position.y -= overlapWidth;
		}
		delete overlap;
	}
}


RECT* MapScreen::checkCollision(Vector2* distanceToTravel) {

	RECT* overlap;
	for each(Layer* layer in map->collidable) {

		overlap = layer->checkCollision(PC::pc->gameObject.get(), distanceToTravel);
		if (overlap != NULL) {
			return overlap;
			//distanceToTravel.y += (overLap.bottom - overLap.top) + 5;
			//break;
		}
	}
	return NULL;
}


InteractableObject* MapScreen::checkInteractable() {

	// check direction facing
	// look in that direction for an object that can be interacted with
	for each (Layer* layer in map->interactable) {
		InteractableObject* object = layer->checkInteractable(PC::pc.get());
		if (object != NULL)
			return object;
	}

	return NULL;
}


void MapScreen::draw(SpriteBatch* batch) {

	for each (Layer* layer in map->layers) {

		layer->draw(batch, map->spriteDict);

	}

	textBoxManager->draw(batch);
}
