#include "MenuScreen.h"

MenuScreen::MenuScreen() {
}

MenuScreen::~MenuScreen() {
}

bool MenuScreen::initialize(ID3D11Device* device, TextBoxManager* txtBxMng) {

	textBoxManager = txtBxMng;

	textBoxManager->loadZone("Intro");


	return true;
}

#include "../Game.h"
void MenuScreen::setGameManager(Game* gm) {

	game = gm;

}

void MenuScreen::update(double deltaTime, SimpleKeyboard* keys) {

	textBoxManager->update(deltaTime, keys);
}

void MenuScreen::draw(SpriteBatch* batch) {

	textBoxManager->draw(batch);
}
