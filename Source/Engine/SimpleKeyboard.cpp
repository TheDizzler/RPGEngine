#include "SimpleKeyboard.h"

SimpleKeyboard::SimpleKeyboard() {
}

SimpleKeyboard::~SimpleKeyboard() {
}


void SimpleKeyboard::getInput(RAWKEYBOARD* rwky) {

	rawKey = rwky;
	bool down;

	if (rawKey->Message == WM_KEYDOWN) {

		down = true;

	} else if (rawKey->Message == WM_KEYUP) {

		down = false;

	} else {
	// something else that we don't care about??
		return;
	}

	UINT keyChar = rawKey->VKey;

	switch (keyChar) {
		case VK_LEFT:
		case VK_NUMPAD4:
			keyDown[LEFT] = down;
			break;

		case VK_RIGHT:
		case VK_NUMPAD6:
			keyDown[RIGHT] = down;
			break;

		case VK_UP:
		case VK_NUMPAD8:
			keyDown[UP] = down;
			break;

		case VK_DOWN:
		case VK_NUMPAD2:
			keyDown[DOWN] = down;
			break;

		case VK_RETURN:
		case 'c':
		case 'C':
			keyDown[SELECT] = down;
			break;

		case 'x':
		case 'X':
			keyDown[CANCEL] = down;
			break;

		case VK_ESCAPE:
			keyDown[ESC] = down;
			break;

	}


}

UINT SimpleKeyboard::getAlphaKey() {

	if (rawKey->Message == WM_KEYDOWN) {

		return rawKey->VKey;

		//if (keyChar > 32 && keyChar < 126	// all chars between space and ~
		//	|| keyChar == 8					// or backspace
		//	|| keyChar == 13) {				// or enter key

		//	return keyChar;


		//}
	}

	return -1;
}
