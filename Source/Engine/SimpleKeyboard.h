#pragma once

#include <SimpleMath.h>


const enum KEYS {
	DOWN, LEFT, UP, RIGHT,
	SELECT, CANCEL, ESC,
	ZOOM_IN, ZOOM_OUT
};

const int KEYCOUNT = 9;

class SimpleKeyboard {
public:
	SimpleKeyboard();
	~SimpleKeyboard();

	void getInput(RAWKEYBOARD* rawKey);

	UINT getAlphaKey();


	bool keyDown[KEYCOUNT] = {false, false, false, false, false, false, false, false, false};
	bool lastDown[KEYCOUNT] = {false, false, false, false, false, false, false, false, false};

private:
	RAWKEYBOARD* rawKey;

	bool shiftPressed = false;
	void getLastInput();

};