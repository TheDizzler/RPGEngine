#pragma once

#include <dinput.h>
#include "BaseGraphics/Sprite.h"


class MouseController : public Sprite {
public:


	MouseController();
	~MouseController();

	DIMOUSESTATE setCurrentState();
	DIMOUSESTATE currentState;
	DIMOUSESTATE lastState;

private:

	

};