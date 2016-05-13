#include "MapScreen.h"

MapScreen::MapScreen() {
}

MapScreen::~MapScreen() {
}

bool MapScreen::initialize(ID3D11Device* device, TextBoxManager* txtBxMng) {
	
	textBoxManager = txtBxMng;
	textBoxManager->startDialogTest();


	return true;
}

void MapScreen::setGameManager(Game* game) {
}

void MapScreen::update(double deltaTime, SimpleKeyboard* keys) {
}

void MapScreen::draw(SpriteBatch * batch) {
}
