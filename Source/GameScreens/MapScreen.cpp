#include "MapScreen.h"

MapScreen::MapScreen(pugi::xml_document* doc) {

	rootLegendNode = doc->child("root");
}

MapScreen::~MapScreen() {
}

bool MapScreen::initialize(ID3D11Device* device, TextBoxManager* txtBxMng) {

	textBoxManager = txtBxMng;
	textBoxManager->startDialogTest();

	const char* mapFile = rootLegendNode.find_child_by_attribute("name", "Test Village").attribute("file").as_string();

	docCurrentMap.reset(new xml_document());
	if (!docCurrentMap->load_file(mapFile)) {
		int a = lstrlenA(mapFile);
		BSTR unicodestr = SysAllocStringLen(NULL, a);
		MultiByteToWideChar(CP_ACP, 0, mapFile, a, unicodestr, a);
		MessageBox(0, unicodestr, L"Error Reading Map File", MB_OK);
		SysFreeString(unicodestr);
		return false;
	}


	map.reset(new MAPFile(docCurrentMap->child("map")));

	if (!map->initialize(device))
		return false;


	return true;
}

void MapScreen::setGameManager(Game* gm) {

	game = gm;
}


//void MapScreen::loadMap() {
//
//
//}

void MapScreen::update(double deltaTime, SimpleKeyboard* keys) {
}

void MapScreen::draw(SpriteBatch * batch) {

	map->draw(batch);

}
