#pragma once

#include "ListBox.h"


class CommandBox : public ListBox {
public:
	CommandBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~CommandBox();

	virtual void update(double deltaTime, BYTE keyboardState[256]) override;
	virtual void drawText(SpriteBatch* batch);

private:

	
};