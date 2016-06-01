#include "Layer.h"

#include <sstream>
#include <iostream>
#include <algorithm>

void ObjectLayer::load(xml_node objectLayerNode) {

	for each (xml_node objectNode in objectLayerNode.children("object")) {
		ObjectLayer::GameObject* gameObj = new ObjectLayer::GameObject();

		gameObj->gid = objectNode.attribute("gid").as_int();
		gameObj->name = objectNode.attribute("name").as_string();
		gameObj->position = Vector2(objectNode.attribute("x").as_int(),
			objectNode.attribute("y").as_int());
		gameObj->width = objectNode.attribute("width").as_int();
		gameObj->height = objectNode.attribute("height").as_int();
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



void ObjectLayer::draw(SpriteBatch * batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) {

	for each (GameObject* gameObject in gameObjects) {
		if (gameObject->gid <= 0)
			return;
		SpriteSheet::SpriteFrame* spriteFrame = spriteDict[gameObject->gid];

		if (!spriteFrame->sheet->texture)
			return;
		batch->Draw(spriteFrame->sheet->texture.Get(), gameObject->position,
			&spriteFrame->sourceRect, spriteFrame->tint,
			spriteFrame->rotation, spriteFrame->origin,
			spriteFrame->scale, SpriteEffects_None,
			spriteFrame->layerDepth);

	}
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