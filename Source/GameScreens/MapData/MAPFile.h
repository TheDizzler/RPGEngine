#pragma once


#include <map>

#include "pugixml.hpp"

#include "../../GameScreens/MapData/Layer.h"


class MAPFile {
public:


	std::map<int, SpriteSheet::SpriteFrame*> spriteDict;

	vector<SpriteSheet*> spriteSheets;
	vector<Layer*> layers;
	vector<Layer*> collidable;
	vector<Layer*> interactable;
	vector<TriggerLayer*> events;

	MAPFile(xml_node mapRoot);
	~MAPFile();

	bool initialize(ID3D11Device* device);

	Vector2 startPos;
	// used in Camera
	int mapWidth, mapHeight;
	int tileWidth, tileHeight;

	int trueMapWidth, trueMapHeight;
private:

	xml_node mapRoot;

	


	bool loadMapDescription();
	bool loadTileset(ID3D11Device* device);
	bool loadLayerData();


	


};



