#pragma once

#include <vector>
#include <map>

#include "pugixml.hpp"

#include "../../Engine/BaseGraphics/Sprite.h"
#include "../../Engine/BaseGraphics/SpriteSheet.h"

using namespace std;
using namespace DirectX;
using namespace pugi;


class TileLayer {
public:

	vector<vector<int>> data;



};

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
	vector<TileLayer*> layers;

	bool loadMapDescription();
	bool loadTileset(ID3D11Device * device);
	bool loadLayerData();

	vector<int> split(string line);

	unique_ptr<Sprite> sprite;
};



