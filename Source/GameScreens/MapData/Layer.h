#pragma once

#include <vector>
#include "pugixml.hpp"

#include "../../GameObjects/MapObjects/GameObject.h"


class Layer {
public:
	string name;

	/** SpriteFrame dictionary needed for loading animations. */
	virtual void load(xml_node layerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) = 0;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) = 0;
	virtual void update(double deltaTime) = 0;
	// Returns true if collision detected
	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) = 0;
};

class TileLayer : public Layer {
public:

	int mapHeight, mapWidth;
	int tileWidth, tileHeight;

	vector<vector<int>> data;

	virtual void load(xml_node tileLayerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*> & spriteDict) override;
	virtual void update(double deltaTime) override;

	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) override;
private:
	vector<int> split(string line);
};

class ObjectLayer : public Layer {

public:

	~ObjectLayer();
	vector<GameObject*> gameObjects;

	virtual void load(xml_node objectLayerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void update(double deltaTime) override;

	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) override;
};

