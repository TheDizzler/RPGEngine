#include "MAPFile.h"

MAPFile::MAPFile(xml_node maprt) {

	mapRoot = maprt;
	
}

MAPFile::~MAPFile() {
}

bool MAPFile::initialize() {

	loadMapDescription();
	return true;
}

bool MAPFile::loadMapDescription() {

	mapWidth = mapRoot.attribute("width").as_int;
	mapHeight = mapRoot.attribute("height").as_int;
	tileWidth = mapRoot.attribute("tilewidth").as_int;
	tileHeight = mapRoot.attribute("tileheight").as_int;

	return true;
}

bool MAPFile::loadTileset() {




	return true;
}
