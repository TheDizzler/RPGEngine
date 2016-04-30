#include "TextBox.h"

TextBox::TextBox(int top, int left, int right, int bottom, FontSet* fnt)
	:GUIBox(top, left, right, bottom) {


	font = fnt;
	firstLabelPos = Vector2(left + marginOffset, top + marginOffset);

}

TextBox::~TextBox() {
}

void TextBox::loadText(wstring txt) {

	originalText = txt;
	text = originalText;

	maxLineLength = (rect.right - marginOffset) - (rect.left + marginOffset);
	maxTextHeight = (rect.bottom - marginOffset) - (rect.top + marginOffset);


	currentLabelPos = firstLabelPos;
	currentLineStart = 0;
	indicatorPos = Vector2(rect.right - marginOffset, rect.bottom - marginOffset);
	indicatorRot = -XM_PI / 2;
}

void TextBox::update(double deltaTime, BYTE keyboardState[256]) {

	timeSinceLastLetter += deltaTime;
	if (timeSinceLastLetter >= letterDelay) {
		writeNextLetter = true;
		timeSinceLastLetter = 0;
	}


	if ((keyboardState[DIK_RETURN] & 0x80) && !lastEnter) {
		lastEnter = true;
		if (!writingDone) {
			letterDelay = .0001;

		} else if (text.length() > currentLineStart + textPos) {
			text = text.substr(currentLineStart + textPos);
			currentLineStart = 0;
			textPos = 0;
			numLines = 0;
			writingDone = false;

		}

	}

	if (!(keyboardState[DIK_RETURN] & 0x80)) {
		lastEnter = false;
	}


	if (writingDone) {
		currentFlashTime += deltaTime;
		if (currentFlashTime >= indicatorFlashTime) {
			indicatorOn = !indicatorOn;
			currentFlashTime = 0;
		}
	}
}

#include <iostream>


void TextBox::drawText(SpriteBatch * batch) {

	if (!writingDone && writeNextLetter) {
		writeNextLetter = false;
		++textPos;

		int checkPos = textPos;
		char c = text[currentLineStart + checkPos];
		if (isspace(c)) {
			
			while (!isspace(text[currentLineStart + ++checkPos]));
			Vector2 measure = font->measureString(text.substr(currentLineStart, checkPos).c_str());

			if (measure.x > maxLineLength) { // insert new line

				text = text.replace(currentLineStart + textPos, 1, 1, '\n');
				currentLineStart += textPos - 1;
				textPos = 0;
				++numLines;
			}

			if (measure.y*numLines > maxTextHeight) {
			 // wait for input
				writingDone = true;
				letterDelay = LETTER_DELAY;
			}

		}
	}
	if (textPos > -1)
		font->draw(batch, text.substr(0, currentLineStart + textPos).c_str(), currentLabelPos);

	if (currentLineStart + textPos >= text.length())
		writingDone = true;


}
