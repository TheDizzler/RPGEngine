#include "TextBox.h"

TextBox::TextBox(int top, int left, int right, int bottom, FontSet* fnt)
	:GUIBox(top, left, right, bottom) {


	font = fnt;
	firstLabelPos = Vector2(left + marginOffset, top + marginOffset);

}

TextBox::~TextBox() {
}

void TextBox::loadNode(xml_node nd) {

	node = nd;

	letterDelay = Globals::LETTER_DELAY;
	writingDone = false;
	textPos = 0;

	const char_t* ch_dialog = node.text().as_string();
	wstringstream wss;
	wss << ch_dialog;
	loadText(wss.str());
	//MessageBox(0, wss.str().c_str(), L"huh>", MB_OK);
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


//bool TextBox::update(double deltaTime, BYTE keyboardState[256]) {
//
//	timeSinceLastLetter += deltaTime;
//	if (timeSinceLastLetter >= letterDelay) {
//		writeNextLetter = true;
//		timeSinceLastLetter = 0;
//	}
//
//
//	if ((keyboardState[DIK_RETURN] & 0x80) && !lastEnter) {
//		lastEnter = true;
//		if (!writingDone) { // speed through rest of text
//			letterDelay = Globals::LETTER_DELAY_FAST;
//
//		} else if (text.length() > currentLineStart + textPos) {
//		// more text to write
//			text = text.substr(currentLineStart + textPos);
//			currentLineStart = 0;
//			textPos = 0;
//			numLines = 0;
//			writingDone = false;
//
//		} else { // All done!
//			indicatorOn = true;
//			return true;
//
//		}
//
//	}
//
//	if (!(keyboardState[DIK_RETURN] & 0x80)) {
//		lastEnter = false;
//	}
//
//
//	if (writingDone) {
//		currentFlashTime += deltaTime;
//		if (currentFlashTime >= indicatorFlashTime) {
//			indicatorOn = !indicatorOn;
//			currentFlashTime = 0;
//		}
//
//		if (!(text.length() > currentLineStart + textPos)
//			&& (string) node.next_sibling().name() == nodeTypes[QUERY]) {
//			// if the next node in this dialog chain is a question, go right to the
//			// question without waiting
//			letterDelay = Globals::LETTER_DELAY;
//			writingDone = false;
//			indicatorOn = true;
//			return true;
//
//		}
//	}
//
//	if (!writingDone && writeNextLetter) {
//		writeNextLetter = false;
//		++textPos;
//
//		int checkPos = textPos;
//		char c = text[currentLineStart + checkPos];
//		if (isspace(c)) {
//
//			while (currentLineStart + checkPos < text.length()
//				&& !isspace(text[currentLineStart + ++checkPos]));
//
//			Vector2 measure = font->measureString(text.substr(currentLineStart, checkPos).c_str());
//
//			if (measure.x > maxLineLength) { // insert new line
//
//				if (measure.y*numLines > maxTextHeight) {
//					// wait for input
//					writingDone = true;
//					letterDelay = Globals::LETTER_DELAY;
//				} else {
//					text = text.replace(currentLineStart + textPos, 1, 1, '\n');
//					currentLineStart += textPos - 1;
//					textPos = 0;
//					++numLines;
//				}
//			}
//		}
//	}
//
//	return false;
//}


bool TextBox::update(double deltaTime, SimpleKeyboard* keys) {

	timeSinceLastLetter += deltaTime;
	if (timeSinceLastLetter >= letterDelay) {
		writeNextLetter = true;
		timeSinceLastLetter = 0;
	}


	if (keys->keyDown[SELECT] && !lastEnter) {
		lastEnter = true;
		if (!writingDone) { // speed through rest of text
			letterDelay = Globals::LETTER_DELAY_FAST;

		} else if (text.length() > currentLineStart + textPos) {
			// more text to write
			text = text.substr(currentLineStart + textPos);
			currentLineStart = 0;
			textPos = 0;
			numLines = 0;
			writingDone = false;

		} else { // All done!
			indicatorOn = true;
			return true;

		}

	}

	if (!keys->keyDown[SELECT]) {
		lastEnter = false;
	}


	if (writingDone) {
		currentFlashTime += deltaTime;
		if (currentFlashTime >= indicatorFlashTime) {
			indicatorOn = !indicatorOn;
			currentFlashTime = 0;
		}

		if (!(text.length() > currentLineStart + textPos)
			&& (string) node.next_sibling().name() == nodeTypes[QUERY]) {
			// if the next node in this dialog chain is a question, go right to the
			// question without waiting
			letterDelay = Globals::LETTER_DELAY;
			writingDone = false;
			indicatorOn = true;
			return true;

		}
	}

	if (!writingDone && writeNextLetter) {
		writeNextLetter = false;
		++textPos;

		int checkPos = textPos;
		char c = text[currentLineStart + checkPos];
		if (isspace(c)) {

			while (currentLineStart + checkPos < text.length()
				&& !isspace(text[currentLineStart + ++checkPos]));

			Vector2 measure = font->measureString(text.substr(currentLineStart, checkPos).c_str());

			if (measure.x > maxLineLength) { // insert new line

				if (measure.y*numLines > maxTextHeight) {
					// wait for input
					writingDone = true;
					letterDelay = Globals::LETTER_DELAY;
				} else {
					text = text.replace(currentLineStart + textPos, 1, 1, '\n');
					currentLineStart += textPos - 1;
					textPos = 0;
					++numLines;
				}
			}
		}
	}

	return false;
}


#include <iostream>



void TextBox::drawText(SpriteBatch * batch) {


	if (textPos > -1)
		font->draw(batch, text.substr(0, currentLineStart + textPos).c_str(), currentLabelPos);

	if (currentLineStart + textPos >= text.length())
		writingDone = true;


}

xml_node TextBox::getSelectedNode() {

	const char_t* att = node.attribute("to").as_string();
	/*wstring name;
	wstringstream wss;
	wss << att.c_str();
	name = wss.str();*/

	if (att == "") { // if no "to" attribute continue on to next node
		//MessageBox(0, L"NOTHNG", L"oh HI", MB_OK);
		return node.next_sibling();
	}

	// search for to corresponding "from" attribute
	return node.parent().find_child_by_attribute(attributeTypes[FROM], att);
}

bool TextBox::isQuery() {
	return false;
}

bool TextBox::isAlphaInput() {
	return false;
}
