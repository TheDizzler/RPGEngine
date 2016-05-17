#include "MenuTest.h"

MenuTest::MenuTest() {
}

MenuTest::~MenuTest() {
}



bool MenuTest::initialize(ID3D11Device * device, TextBoxManager* txtBxMng) {


	textBoxManager = txtBxMng;
	textBoxManager->startDialogTest();


	return true;
}

void MenuTest::setGameManager(Game* gm) {
	game = gm;
}



void MenuTest::update(double deltaTime, SimpleKeyboard* keys) {
	textBoxManager->update(deltaTime, keys);
}

void MenuTest::draw(SpriteBatch * batch) {

	textBoxManager->draw(batch);
}

