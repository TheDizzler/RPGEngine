#include "AlphaInputBox.h"

AlphaInputBox::AlphaInputBox(int top, int left, FontSet* fontSet)
	: TextBox(top, left, left + Globals::ALPHA_INPUT_WIDTH, top + Globals::ALPHA_INPUT_HEIGHT, fontSet) {

	indicatorOn = false; // uses own internal character
	indicatorPos = firstLabelPos;
}

AlphaInputBox::~AlphaInputBox() {
}


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
		lastEnter = false;
		return false;
	}

	if (keyChar >= 32 && keyChar <= 126 && !lastChar) {	// all chars between space and ~

		/*wstringstream wss;
		wss << keyChar;
		MessageBox(0, wss.str().c_str(), L"Test", MB_OK);*/

		lastChar = true;
		userInput += wchar_t(keyChar);
		return false;
	}

	if (keyChar == VK_RETURN && !lastEnter) {
		lastEnter = true;
		if (userInput.length() > 0)
			return true;
		return false;
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
	if (nextCharIndicatorOn)
		print += carat;
	font->draw(batch, print.c_str(), firstLabelPos);
}

bool AlphaInputBox::isAlphaInput() {
	return true;
}

wstring AlphaInputBox::getUserInput() {
	return userInput;
}
