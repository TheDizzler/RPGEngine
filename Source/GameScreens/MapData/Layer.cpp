#include "Layer.h"

#include <sstream>
#include <iostream>
#include <algorithm>

//#include "../../Game.h"
#include "../../GameObjects/PC.h"

void ObjectLayer::load(xml_node objectLayerNode) {

	if (strcmp(objectLayerNode.attribute("name").as_string(), "NPC") == 0) {
	// Add the pc to the npc layer
		gameObjects.push_back(PC::pc->gameObject.get());

	}

	for each (xml_node objectNode in objectLayerNode.children("object")) {
		GameObject* gameObj = new GameObject();

		gameObj->gid = objectNode.attribute("gid").as_int();
		gameObj->name = objectNode.attribute("name").as_string();

		gameObj->width = objectNode.attribute("width").as_int();
		gameObj->height = objectNode.attribute("height").as_int();
		int x = objectNode.attribute("x").as_int();
		int y = objectNode.attribute("y").as_int() - gameObj->height;
		gameObj->position = Vector2(x, y);
		//gameObj->x = x;
		//gameObj->y = y;
		gameObj->setRect();
		gameObjects.push_back(gameObj);
	}

}

void TileLayer::load(xml_node tileLayerNode) {

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

RECT* TileLayer::checkCollision(GameObject * movingObject, Vector2* moveDistance) {

	return NULL;
}



void ObjectLayer::draw(SpriteBatch * batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	for each (GameObject* gameObject in gameObjects) {
		if (gameObject->gid <= 0) // empty tile
			return;
		SpriteSheet::SpriteFrame* spriteFrame = spriteDict[gameObject->gid];

		if (!spriteFrame->sheet->texture) // not an object with a visual representation on the map
			return;

		batch->Draw(spriteFrame->sheet->texture.Get(), gameObject->position/*Vector2(gameObject->x, gameObject->y)*/,
			&spriteFrame->sourceRect, spriteFrame->tint,
			spriteFrame->rotation, spriteFrame->origin,
			spriteFrame->scale, SpriteEffects_None,
			spriteFrame->layerDepth);

	}
}


RECT* ObjectLayer::checkCollision(GameObject* movingObject, Vector2* moveDistance) {

	//Vector2 actualMove;

	RECT afterMove = movingObject->rect;
	afterMove.left += moveDistance->x - 5;
	afterMove.right += moveDistance->x + 5;
	afterMove.top += moveDistance->y - 5;
	afterMove.bottom += moveDistance->y + 5;
	for each (GameObject* gameObject in gameObjects) {

		if (strcmp(gameObject->name.c_str(), movingObject->name.c_str()) == 0)
			continue;


		RECT* overlapRect = new RECT{-1, -1, -1, -1};
		// If the rectangles intersect, the return value is nonzero.
		// If the rectangles do not intersect, the return value is zero.
		if (IntersectRect(overlapRect, &afterMove, &gameObject->rect) != 0)
			return overlapRect;
	}

	return NULL;

}


//bool ObjectLayer::checkCollision(GameObject* movingObject, Vector2* moveDistance) {
//
//	//Vector2 actualMove;
//
//	for each (GameObject* gameObject in gameObjects) {
//
//		if (strcmp(gameObject->name.c_str(), movingObject->name.c_str()) == 0)
//			continue;
//
//
//		RECT overlapRect;
//		// If the rectangles intersect, the return value is nonzero.
//		// If the rectangles do not intersect, the return value is zero.
//		if (IntersectRect(&overlapRect, &movingObject->rect, &gameObject->rect) == 0)
//			continue;
//
//		if (moveDistance->x != 0) {
//			int distanceToFar = overlapRect.right - overlapRect.left;
//			moveDistance->x -= distanceToFar;
//		}
//		if (moveDistance->y != 0) {
//			int distanceToFar = overlapRect.bottom - overlapRect.top;
//			moveDistance->y -= distanceToFar;
//
//		}
//		return true;
//	}
//
//	return false;
//	//return actualMove;
//}





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