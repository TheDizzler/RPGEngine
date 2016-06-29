#pragma once

#include <map>

#include "Screen.h"
#include "MapData/MAPFile.h"
#include "../Engine/Camera.h"
#include "../Engine/SimpleKeyboard.h"
#include "../GameObjects/MapObjects/EventHandler.h"


//class Game;

class MapScreen : public Screen {
public:
	MapScreen(xml_document* doc);
	~MapScreen();

	// Inherited via Screen
	virtual bool initialize(ID3D11Device* device, TextBoxManager* textBoxManager) override;
	virtual void setGameManager(Game* game) override;
	virtual void update(double deltaTime, SimpleKeyboard* keys) override;
	virtual void draw(SpriteBatch* batch) override;



private:

	//Game* game;

	//TextBoxManager* textBoxManager;

	unique_ptr<xml_document> docCurrentMap;
	unique_ptr<EventHandler> eventHandler;

	xml_node rootLegendNode;
	unique_ptr<MAPFile> map;


	void playerActions(double deltaTime, SimpleKeyboard * keys);
	void collisionAlgo(Vector2* distanceToTravel);
	RECT* checkCollision(Vector2* distanceToTravel);
	InteractableObject* checkInteractable();

	/** Check if player has touched the edge of the map. */
	bool outsideBounds(Vector2* playerPos);

	bool eventPlaying = false;
};