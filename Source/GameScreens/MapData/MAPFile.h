#pragma once


#include <map>

#include "pugixml.hpp"

#include "../../GameScreens/MapData/Layer.h"
#include "../../Engine/SimpleKeyboard.h"


class MAPFile {
public:
	MAPFile(xml_node mapRoot);
	~MAPFile();

	bool initialize(ID3D11Device* device);

	void update(double deltaTime, SimpleKeyboard * keys);

	
	
	void draw(SpriteBatch* batch);

	

private:

	xml_node mapRoot;

	int mapWidth, mapHeight;
	int tileWidth, tileHeight;
	map<int, SpriteSheet::SpriteFrame*> spriteDict;

	vector<SpriteSheet*> spriteSheets;
	vector<Layer*> layers;

	vector<Layer*> collidable;
	//vector<GameObject*> 

	bool loadMapDescription();
	bool loadTileset(ID3D11Device * device);
	bool loadLayerData();

	RECT* checkCollision(Vector2 * distanceToTravel);

	Vector2 startPos;
	

};



