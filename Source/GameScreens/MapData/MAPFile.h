#pragma once

#include <vector>
#include <map>


#include "pugixml.hpp"
#include "SpriteBatch.h"

using namespace std;
using namespace DirectX;
using namespace pugi;

class MAPFile {
public:
	MAPFile(xml_node mapRoot);
	~MAPFile();

	bool initialize();

	void draw(SpriteBatch* batch);

private:

	xml_node mapRoot;

	int mapWidth, mapHeight;
	int tileWidth, tileHeight;

	vector<SpriteSheet> spriteSheets;
	map<int, RECT> spriteDict;

	bool loadMapDescription();
	bool loadTileset();
	bool loadLayerData();

};

class SpriteSheet {
public:
	struct SpriteFrame {
		RECT sourceRect;
		XMFLOAT2 size;
		XMFLOAT2 origin;
		bool rotated;

	};
	SpriteSheet();
	~SpriteSheet();

private:

};