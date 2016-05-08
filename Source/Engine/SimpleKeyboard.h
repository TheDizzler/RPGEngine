#pragma once

#include <SimpleMath.h>


const enum KEYS {
	UP, DOWN, LEFT, RIGHT, SELECT, CANCEL, ESC
};



class SimpleKeyboard {
public:
	SimpleKeyboard();
	~SimpleKeyboard();

	void getInput(RAWKEYBOARD* rawKey);

	UINT getAlphaKey();


	bool keyDown[7] = {false, false, false, false, false, false, false};
	bool lastDown[7] = {false, false, false, false, false, false, false};

private:
	RAWKEYBOARD* rawKey;
	

};