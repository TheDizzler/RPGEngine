#pragma once


#include <map>

#include "pugixml.hpp"

#include "../../GameScreens/MapData/Layer.h"






class MAPFile {
public:
	MAPFile(xml_node mapRoot);
	~MAPFile();

	bool initialize(ID3D11Device* device);

	void draw(SpriteBatch* batch);

	

private:

	xml_node mapRoot;

	int mapWidth, mapHeight;
	int tileWidth, tileHeight;
	map<int, SpriteSheet::SpriteFrame*> spriteDict;

	vector<SpriteSheet*> spriteSheets;
	vector<Layer*> layers;

	bool loadMapDescription();
	bool loadTileset(ID3D11Device * device);
	bool loadLayerData();

	

};



