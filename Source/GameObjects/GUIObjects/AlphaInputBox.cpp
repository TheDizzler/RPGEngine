#include "AlphaInputBox.h"

AlphaInputBox::AlphaInputBox(int top, int left, FontSet* fontSet)
	: TextBox(top, left, left + Globals::ALPHA_INPUT_WIDTH, top + Globals::ALPHA_INPUT_HEIGHT, fontSet) {

	indicatorOn = false; // uses own internal character
}

AlphaInputBox::~AlphaInputBox() {
}

bool AlphaInputBox::update(double deltaTime, BYTE keyboardState[256]) {

	currentFlashTime += deltaTime;
	if (currentFlashTime >= indicatorFlashTime) {
		nextCharIndicatorOn != nextCharIndicatorOn;
		currentFlashTime = 0;
	}

	return false;
}

void AlphaInputBox::drawText(SpriteBatch * batch) {

	wchar_t* print = userInput;
	if (nextCharIndicatorOn)
		print += nextChar;
	font->draw(batch, print, firstLabelPos);
}
