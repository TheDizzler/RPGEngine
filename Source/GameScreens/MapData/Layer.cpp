#include "Layer.h"

#include <sstream>
#include <iostream>
#include <algorithm>


#include "../../GameObjects/PC.h"

CharacterLayer::~CharacterLayer() {

	for each (GameObject* gameObject in characterObjects) {
		delete gameObject;
	}
}

CollisionLayer::~CollisionLayer() {
	for each (GameObject* gameObject in collisionObjects) {
		delete gameObject;
	}
}

TriggerLayer::~TriggerLayer() {
	for each (GameObject* gameObject in events) {
		delete gameObject;
	}
}



void TriggerLayer::load(xml_node layerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	for each (xml_node objectNode in layerNode.children("object")) {
		EventObject* eventObj = new EventObject();

		//gameObj->gid = objectNode.attribute("gid").as_int();
		//gameObj->spriteFrame = spriteDict[gameObj->gid];
		eventObj->name = objectNode.attribute("name").as_string();

		eventObj->width = objectNode.attribute("width").as_int();
		eventObj->height = objectNode.attribute("height").as_int();
		int x = objectNode.attribute("x").as_int();
		int y = objectNode.attribute("y").as_int();
		eventObj->position = Vector2(x, y);

		eventObj->setRect();
		events.push_back(eventObj);
	}
}

void CharacterLayer::load(xml_node objectLayerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	/*if (strcmp(objectLayerNode.attribute("name").as_string(), "NPC") == 0) {*/
	// Add the pc to the npc layer
	PC::pc->gameObject->spriteFrame = spriteDict[PC::pc->gameObject->gid];
	characterObjects.push_back(PC::pc->gameObject.get());

	for each (xml_node objectNode in objectLayerNode.children("object")) {
		CharacterObject* charObj = new CharacterObject();

		charObj->gid = objectNode.attribute("gid").as_int();
		charObj->spriteFrame = spriteDict[charObj->gid];
		charObj->name = objectNode.attribute("name").as_string();

		charObj->width = objectNode.attribute("width").as_int();
		charObj->height = objectNode.attribute("height").as_int();
		int x = objectNode.attribute("x").as_int();
		int y = objectNode.attribute("y").as_int();
		charObj->position = Vector2(x, y);

		charObj->setRect();
		characterObjects.push_back(charObj);
	}
}

void CollisionLayer::load(xml_node layerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	for each (xml_node objectNode in layerNode.children("object")) {
		GameObject* gameObj = new GameObject();

		//gameObj->gid = objectNode.attribute("gid").as_int();
		//gameObj->spriteFrame = spriteDict[gameObj->gid];
		gameObj->name = objectNode.attribute("name").as_string();

		gameObj->width = objectNode.attribute("width").as_int();
		gameObj->height = objectNode.attribute("height").as_int();
		int x = objectNode.attribute("x").as_int();
		int y = objectNode.attribute("y").as_int();
		gameObj->position = Vector2(x, y);

		gameObj->setRect();
		collisionObjects.push_back(gameObj);
	}
}

void TileLayer::load(xml_node tileLayerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	mapWidth = tileLayerNode.attribute("width").as_int();
	mapHeight = tileLayerNode.attribute("height").as_int();
	tileWidth = tileLayerNode.parent().attribute("tilewidth").as_int();
	tileHeight = tileLayerNode.parent().attribute("tileheight").as_int();
	xml_node layerDataNode = tileLayerNode.child("data");

	if (layerDataNode.attribute("encoding")) { // just gonna assume it's csv

		string str = layerDataNode.text().as_string();

		istringstream datastream(str);
		string line;

		while (getline(datastream, line)) {
			line.erase(remove_if(line.begin(), line.end(), isspace), line.end());
			if (line.length() <= 0)
				continue;
			data.push_back(split(line));
		}
	}

}



void TriggerLayer::update(double deltaTime) {
}

void CharacterLayer::update(double deltaTime) {

	for each (CharacterObject* gameObject in characterObjects) {
		gameObject->update(deltaTime);
	}
}

void CollisionLayer::update(double deltaTime) {
}

void TileLayer::update(double deltaTime) {

}



void TriggerLayer::draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {
// don't draw nothin
}

void CharacterLayer::draw(SpriteBatch * batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	for each (CharacterObject* gameObject in characterObjects) {
		if (gameObject->gid <= 0) // empty tile
			return;
		SpriteSheet::SpriteFrame* spriteFrame
			= spriteDict[gameObject->getGID()];

		if (!spriteFrame->sheet->texture) // not an object with a visual representation on the map
			return;

		batch->Draw(spriteFrame->sheet->texture.Get(), gameObject->position,
			&spriteFrame->sourceRect, spriteFrame->tint,
			spriteFrame->rotation, gameObject->origin,
			spriteFrame->scale, SpriteEffects_None,
			spriteFrame->layerDepth);

	}
}

void CollisionLayer::draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {
	// don't draw nothin
}

void TileLayer::draw(SpriteBatch * batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	for (int row = 0; row < mapHeight; ++row) {
		for (int col = 0; col < mapWidth; ++col) {

			int gid = data[col][row];
			if (gid <= 0)
				continue;

			SpriteSheet::SpriteFrame* spriteFrame = spriteDict[gid];

			batch->Draw(spriteFrame->sheet->texture.Get(),
				Vector2(row * tileWidth, col * tileHeight),
				&spriteFrame->sourceRect, spriteFrame->tint,
				spriteFrame->rotation, spriteFrame->origin,
				spriteFrame->scale, SpriteEffects_None,
				spriteFrame->layerDepth);
		}
	}

}




RECT* TriggerLayer::checkCollision(GameObject* movingObject, Vector2* moveDistance) {
	return nullptr;
}

RECT* CharacterLayer::checkCollision(GameObject* movingObject, Vector2* moveDistance) {

	RECT afterMove = movingObject->rect;
	int tolerance = 5;
	afterMove.left += moveDistance->x - tolerance;
	afterMove.right += moveDistance->x + tolerance;
	afterMove.top += moveDistance->y - tolerance;
	afterMove.bottom += moveDistance->y + tolerance;

	for each (GameObject* gameObject in characterObjects) {

		if (strcmp(gameObject->name.c_str(), movingObject->name.c_str()) == 0)
			continue;


		RECT* overlapRect = new RECT{-1, -1, -1, -1};
		// If the rectangles intersect, the return value is nonzero.
		// If the rectangles do not intersect, the return value is zero.
		if (IntersectRect(overlapRect, &afterMove, &gameObject->rect) != 0)
			return overlapRect;

		delete overlapRect;
	}

	return NULL;

}

RECT* CollisionLayer::checkCollision(GameObject* movingObject, Vector2* moveDistance) {

	RECT afterMove = movingObject->rect;
	int tolerance = 5;
	afterMove.left += moveDistance->x - tolerance;
	afterMove.right += moveDistance->x + tolerance;
	afterMove.top += moveDistance->y - tolerance;
	afterMove.bottom += moveDistance->y + tolerance;

	for each (GameObject* gameObject in collisionObjects) {

		if (strcmp(gameObject->name.c_str(), movingObject->name.c_str()) == 0)
			continue;


		RECT* overlapRect = new RECT{-1, -1, -1, -1};
		// If the rectangles intersect, the return value is nonzero.
		// If the rectangles do not intersect, the return value is zero.
		if (IntersectRect(overlapRect, &afterMove, &gameObject->rect) != 0)
			return overlapRect;

		delete overlapRect;
	}

	return NULL;
}

RECT* TileLayer::checkCollision(GameObject* movingObject, Vector2* moveDistance) {

	return NULL;
}



vector<int> TileLayer::split(string line) {

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
