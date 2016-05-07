#pragma once

#include "TextBox.h"


class AlphaInputBox : public TextBox {
public:
	/** Fixed length and height. */
	AlphaInputBox(int top, int left, FontSet* fontSet);
	~AlphaInputBox();

	virtual bool update(double deltaTime, BYTE keyboardState[256]) override;
	virtual void drawText(SpriteBatch* batch) override;


private:

	const int MAX_CHARACTERS = 10;
	const char nextChar = '_';

	bool nextCharIndicatorOn = true;
	wchar_t* userInput;
};