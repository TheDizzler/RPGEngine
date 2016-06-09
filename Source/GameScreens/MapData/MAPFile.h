#pragma once


#include <map>

#include "pugixml.hpp"

#include "../../GameScreens/MapData/Layer.h"
//#include "../../Engine/SimpleKeyboard.h"


class MAPFile {
public:


	std::map<int, SpriteSheet::SpriteFrame*> spriteDict;

	vector<SpriteSheet*> spriteSheets;
	vector<Layer*> layers;
	vector<Layer*> collidable;
	vector<Layer*> interactable;


	MAPFile(xml_node mapRoot);
	~MAPFile();

	bool initialize(ID3D11Device* device);

	//void update(double deltaTime, SimpleKeyboard * keys);
	//void playerActions(double deltaTime, SimpleKeyboard * keys);


	//void draw(SpriteBatch* batch);


private:

	xml_node mapRoot;

	int mapWidth, mapHeight;
	int tileWidth, tileHeight;
	/*map<int, SpriteSheet::SpriteFrame*> spriteDict;

	vector<SpriteSheet*> spriteSheets;
	vector<Layer*> layers;

	vector<Layer*> collidable;
	vector<Layer*> interactable;*/

	bool loadMapDescription();
	bool loadTileset(ID3D11Device* device);
	bool loadLayerData();

	/*RECT* checkCollision(Vector2* distanceToTravel);
	InteractableObject* checkInteractable();*/

	Vector2 startPos;


};



