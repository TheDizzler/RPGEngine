#pragma once

#include <vector>
#include "pugixml.hpp"

#include "../../GameObjects/MapObjects/CharacterObject.h"
#include "../../GameObjects/MapObjects/EventObject.h"
#include "../../GameObjects/PC.h"

class Layer {
public:
	string name;

	/** SpriteFrame dictionary needed for loading animations. */
	virtual void load(xml_node layerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) = 0;
	virtual void update(double deltaTime) = 0;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) = 0;

	/** Returns rect of overlaping area. */
	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) = 0;
	virtual InteractableObject* checkInteractable(PC* pc) = 0;

//protected:
	//RECT* checkCollision(vector<GameObject*> objects, GameObject* movingObject, Vector2* moveDistance);
};

class TileLayer : public Layer {
public:

	int mapHeight, mapWidth;
	int tileWidth, tileHeight;

	vector<vector<int>> data;

	virtual void load(xml_node tileLayerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void update(double deltaTime) override;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*> & spriteDict) override;


	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) override;
	virtual InteractableObject* checkInteractable(PC* pc) override;
private:
	vector<int> split(string line);
};

/** Layer containing NPCs and PCs. */
class CharacterLayer : public Layer {
public:

	~CharacterLayer();


	virtual void load(xml_node objectLayerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void update(double deltaTime) override;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;


	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) override;
	virtual InteractableObject* checkInteractable(PC* pc) override;
private:
	vector<CharacterObject*> characterObjects;
};


class CollisionLayer : public Layer {
public:
	~CollisionLayer();
		// Inherited via Layer
	virtual void load(xml_node layerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void update(double deltaTime) override;
	virtual void draw(SpriteBatch * batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;

	virtual RECT * checkCollision(GameObject * movingObject, Vector2 * moveDistance) override;
	virtual InteractableObject* checkInteractable(PC* pc) override;

private:
	vector<GameObject*> collisionObjects;
};


/** Layer containing triggered events. */
class TriggerLayer : public Layer {
public:
	~TriggerLayer();
	// Inherited via Layer
	virtual void load(xml_node layerNode, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;
	virtual void update(double deltaTime) override;
	virtual void draw(SpriteBatch* batch, map<int, SpriteSheet::SpriteFrame*>& spriteDict) override;

	virtual RECT* checkCollision(GameObject* movingObject, Vector2* moveDistance) override;
	virtual InteractableObject* checkInteractable(PC* pc) override;

private:
	vector<EventObject*> events;
};

