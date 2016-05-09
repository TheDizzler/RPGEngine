#pragma once



//#include <dinput.h>
//#include <DirectXMath.h>
//#include <GamePad.h>

#include "SimpleKeyboard.h"
#include "MouseController.h"


//using namespace DirectX;


class Input {
public:
	Input();
	~Input();

	bool initRawInput(HWND hwnd);
	/** DEPRECATED!! */
	//bool initDirectInput(HINSTANCE hInstance, HWND hwnd);
	/** DEPRECATED!! */
	virtual void detectInput(double time) = 0;

	void setRawInput(RAWINPUT* raw);

protected:

	SimpleKeyboard* keys;
	//RAWKEYBOARD* rawKey;
	RAWMOUSE* rawMouse;

   /** DEPRECATED!! */
	//IDirectInputDevice8* inputKB;
	/** DEPRECATED!! */
	//IDirectInputDevice8* inputMouse;
	//IDirectInputDevice8* inputJoystick;

	/** DEPRECATED!! */
	//LPDIRECTINPUT8 directInput;
	/** DEPRECATED!! */
	std::unique_ptr<MouseController> mouse;

};

