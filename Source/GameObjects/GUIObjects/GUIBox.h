#pragma once

#include <vector>
#include "../../Engine/BaseGraphics/Sprite.h"


class GUIBox {
public:
	GUIBox(int top, int left, int right, int bottom);
	~GUIBox();

	virtual bool update(double deltaTime, BYTE keyboardState[256]) = 0;
	virtual void drawText(SpriteBatch* batch) = 0;

	RECT rect;

	

};