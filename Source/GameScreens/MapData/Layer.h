#pragma once

#include <vector>
#include "pugixml.hpp"

#include "../../GameObjects/GameObject.h"
#include "../../Engine/BaseGraphics/SpriteSheet.h"

class Layer {
public:
	string name;

	virtual void load(xml_node layerNode) = 0;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) = 0;
};

class TileLayer : public Layer {
public:

	int mapHeight, mapWidth;
	int tileWidth, tileHeight;

	vector<vector<int>> data;

	virtual void load(xml_node tileLayerNode) override;

	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*> & spriteDict) override;

private:
	vector<int> split(string line);
};

class ObjectLayer : public Layer {

public:

	vector<GameObject*> gameObjects;

	virtual void load(xml_node objectLayerNode) override;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;

};

