#pragma once

#include <SimpleMath.h>


const enum KEYS {
	UP, DOWN, LEFT, RIGHT, SELECT, CANCEL, ESC
};

const int KEYCOUNT = 7;

class SimpleKeyboard {
public:
	SimpleKeyboard();
	~SimpleKeyboard();

	void getInput(RAWKEYBOARD* rawKey);
	void getLastInput();
	UINT getAlphaKey();


	bool keyDown[KEYCOUNT] = {false, false, false, false, false, false, false};
	bool lastDown[KEYCOUNT] = {false, false, false, false, false, false, false};

private:
	RAWKEYBOARD* rawKey;

	bool shiftPressed = false;
	

};