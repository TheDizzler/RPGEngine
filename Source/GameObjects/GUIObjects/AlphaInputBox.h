#pragma once

#include "TextBox.h"



class AlphaInputBox : public TextBox {
public:
	/** Fixed length and height. */
	AlphaInputBox(int top, int left, FontSet* fontSet);
	~AlphaInputBox();

	//virtual bool update(double deltaTime, BYTE keyboardState[256]) override;
	virtual bool update(double deltaTime, SimpleKeyboard* keys) override;
	virtual void drawText(SpriteBatch* batch) override;
	virtual bool isAlphaInput() override;
	wstring getUserInput();
	
private:

	
	wstring carat = L"_";

	bool lastChar = true;
	bool lastBackspace = true;
	bool nextCharIndicatorOn = true;
	wstring userInput;
};