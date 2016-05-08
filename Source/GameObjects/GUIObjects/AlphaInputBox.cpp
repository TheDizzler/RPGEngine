#include "AlphaInputBox.h"

AlphaInputBox::AlphaInputBox(int top, int left, FontSet* fontSet)
	: TextBox(top, left, left + Globals::ALPHA_INPUT_WIDTH, top + Globals::ALPHA_INPUT_HEIGHT, fontSet) {

	indicatorOn = false; // uses own internal character
	indicatorPos = firstLabelPos;
}

AlphaInputBox::~AlphaInputBox() {
}

//bool AlphaInputBox::update(double deltaTime, BYTE keyboardState[256]) {
//
//	currentFlashTime += deltaTime;
//	if (currentFlashTime >= indicatorFlashTime) {
//		nextCharIndicatorOn != nextCharIndicatorOn;
//		currentFlashTime = 0;
//	}
//
//
//	return false;
//}

bool AlphaInputBox::update(double deltaTime, SimpleKeyboard* keys) {

	currentFlashTime += deltaTime;
	if (currentFlashTime >= indicatorFlashTime) {
		nextCharIndicatorOn != nextCharIndicatorOn;
		currentFlashTime = 0;
	}

	UINT keyChar = keys->getAlphaKey();
	if (keyChar == -1) {
		lastChar = false;
		return false;
	}

	if (keyChar > 32 && keyChar < 126 && !lastChar) {	// all chars between space and ~
		lastChar = true;
		userInput += wchar_t(keyChar);
		return false;
	}
	//if (!(keyChar > 32 && keyChar < 126))
		//lastChar = false;

	if (keyChar == VK_RETURN && !lastEnter) {
		lastEnter = true;
		return true;
	}
	if (keyChar != VK_RETURN)
		lastEnter = false;

	if (keyChar == 8 && !lastBackspace) {	// backspace
		lastBackspace = true;
		userInput = userInput.substr(0, userInput.length() - 2);
		return false;
	}
	if (keyChar != 8)
		lastBackspace = false;


	return false;
}

void AlphaInputBox::drawText(SpriteBatch * batch) {

	/*wchar_t* print = userInput;
	if (nextCharIndicatorOn)
		print += nextChar;
	font->draw(batch, print, firstLabelPos);*/

	font->draw(batch, userInput.c_str(), firstLabelPos);
}

bool AlphaInputBox::isAlphaInput() {
	return true;
}

wstring AlphaInputBox::getUserInput() {
	return userInput;
}
