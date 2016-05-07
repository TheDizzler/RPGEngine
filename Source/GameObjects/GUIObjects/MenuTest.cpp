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

void MenuTest::update(double deltaTime, BYTE keyboardState[256], MouseController * mouse) {

	//textBox->update(deltaTime, keyboardState);
	textBoxManager->update(deltaTime, keyboardState);

}

void MenuTest::draw(SpriteBatch * batch) {

	textBoxManager->draw(batch);
	//testLabel->draw(batch);
}

