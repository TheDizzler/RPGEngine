#include "AlphaInputBox.h"

AlphaInputBox::AlphaInputBox(int top, int left, FontSet* fontSet)
	: TextBox(top, left, left + Globals::ALPHA_INPUT_WIDTH, top + Globals::ALPHA_INPUT_HEIGHT, fontSet) {

	indicatorOn = false; // uses own internal character
	indicatorPos = firstLabelPos;
}

AlphaInputBox::~AlphaInputBox() {
}

void AlphaInputBox::loadNode(xml_node node) {

	TextBox::loadNode(node);

	if (node.attribute("default") != NULL) {

		string def = node.attribute("default").as_string();
		wstringstream wss;
		wss << def.c_str();
		userInput = wss.str();

	}
}

#include "../../Game.h"
bool AlphaInputBox::update(double deltaTime, SimpleKeyboard* keys) {


	currentFlashTime += deltaTime;
	if (currentFlashTime >= indicatorFlashTime) {
		nextCharIndicatorOn != nextCharIndicatorOn;
		currentFlashTime = 0;
	}

	UINT keyChar = keys->getAlphaKey();
	if (keyChar == -1) {
		lastChar = false;
		lastBackspace = false;
		//lastEnter = false;
		return false;
	}

	if (keyChar >= 32 && keyChar <= 126 && !lastChar) {	// all chars between space and ~

		if (userInput.length() >= Globals::MAX_CHARACTERS)
			return false;

				/*wstringstream wss;
				wss << keyChar;
				MessageBox(0, wss.str().c_str(), L"Test", MB_OK);*/

		lastChar = true;
		userInput += wchar_t(keyChar);
		return false;
	}

	if (keyChar == VK_RETURN && !keys->lastDown[SELECT]) {
		//lastEnter = true;
		if (userInput.length() <= 0)
			return false;

		// get saveTo escape
		string saveTo = node.attribute("saveTo").as_string();
		wstringstream wss;
		wss << saveTo.c_str();
		//MessageBox(0, wss.str().c_str(), userInput.c_str(), MB_OK);
		Game::storeVariable(wss.str(), &userInput);

		return true;
	}

	if (keyChar == 8 && !lastBackspace) {	// backspace
		lastBackspace = true;
		userInput = userInput.substr(0, userInput.length() - 1);
		return false;
	}



	return false;
}

void AlphaInputBox::drawText(SpriteBatch * batch) {

	wstring print = userInput;
	if (nextCharIndicatorOn && userInput.length() < Globals::MAX_CHARACTERS)
		print += carat;
	font->draw(batch, print.c_str(), firstLabelPos);
}

bool AlphaInputBox::isAlphaInput() {
	return true;
}

wstring AlphaInputBox::getUserInput() {
	return userInput;
}
