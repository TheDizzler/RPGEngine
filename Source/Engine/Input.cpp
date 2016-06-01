#include "Input.h"


Input::Input() {
}


Input::~Input() {

	//inputKB->Unacquire();
	//inputMouse->Unacquire();
	////inputJoystick->Unacquire();
	//directInput->Release();
}

bool Input::initRawInput(HWND hwnd) {

	RAWINPUTDEVICE rid[1];
	rid[0].usUsagePage = 1;
	rid[0].usUsage = 6; // keyboard
	rid[0].dwFlags = RIDEV_NOLEGACY; // adds HID keyboard and ignores legacy mouse msgs
	rid[0].hwndTarget = hwnd; // 0??

	//rid[1].usUsagePage = 1;
	//rid[1].usUsage = 2; // mouse
	//rid[1].dwFlags = RIDEV_NOLEGACY; // adds HID mouse and legacy keyboard msgs
	//rid[1].hwndTarget = 0; // 0??

	if (!RegisterRawInputDevices(rid, 1, sizeof((rid[0]))))
		return false;

	keys = new SimpleKeyboard();
	mouse.reset(new MouseController());

	return true;
}


//bool Input::initDirectInput(HINSTANCE hInstance, HWND hwnd) {
//
//
//	if (FAILED(DirectInput8Create(hInstance, DIRECTINPUT_VERSION, IID_IDirectInput8,
//		(void**) &directInput, NULL)))
//
//		return false;
//
//	if (FAILED(directInput->CreateDevice(GUID_SysKeyboard, &inputKB, NULL)))
//
//		return false;
//
//	if (FAILED(directInput->CreateDevice(GUID_SysMouse, &inputMouse, NULL)))
//
//		return false;
//
//	/*if (FAILED(directInput->CreateDevice(GUID_Joystick, &inputJoystick, NULL)))
//		return false;*/
//
//		/*gamepad.reset(new GamePad);
//		gamepad->Resume();
//		buttons.Reset();*/
//
//	if (FAILED(inputKB->SetDataFormat(&c_dfDIKeyboard)))
//
//		return false;
//
//	if (FAILED(inputKB->SetCooperativeLevel(hwnd, DISCL_FOREGROUND | DISCL_NONEXCLUSIVE)))
//
//		return false;
//
//	if (FAILED(inputMouse->SetDataFormat(&c_dfDIMouse)))
//
//		return false;
//
//	if (FAILED(inputMouse->SetCooperativeLevel(hwnd, DISCL_EXCLUSIVE | DISCL_NOWINKEY | DISCL_FOREGROUND)))
//		return false;
//
//	mouse.reset(new MouseController());
//
//	return true;
//}


void Input::setRawInput(RAWINPUT* raw) {

	keys->getLastInput();
	if (raw->header.dwType == RIM_TYPEKEYBOARD)
		keys->getInput(&raw->data.keyboard);

	if (raw->header.dwType == RIM_TYPEMOUSE)
		rawMouse = &raw->data.mouse;
}




