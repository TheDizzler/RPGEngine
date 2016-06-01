#pragma once

#include "Screen.h"
#include "MapData\MAPFile.h"

class Game;

class MapScreen : public Screen {
public:
	MapScreen(xml_document* doc);
	~MapScreen();

	// Inherited via Screen
	virtual bool initialize(ID3D11Device * device, TextBoxManager * textBoxManager) override;
	virtual void setGameManager(Game * game) override;
	virtual void update(double deltaTime, SimpleKeyboard * keys) override;
	virtual void draw(SpriteBatch * batch) override;



private:

	Game* game;

	TextBoxManager* textBoxManager;

	unique_ptr<xml_document> docCurrentMap;

	xml_node rootLegendNode;
	unique_ptr<MAPFile> map;

	//void loadMap();
};