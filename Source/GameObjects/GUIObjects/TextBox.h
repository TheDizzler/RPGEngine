#pragma once

#include <queue>
#include <dinput.h>

#include "../../globals.h"
#include "GUIBox.h"
#include "../../Engine/BaseGraphics/Sprite.h"
#include "TextLabel.h"

class TextBox : public GUIBox {
public:
	TextBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~TextBox();

	void loadText(wstring text);

	virtual void update(double deltaTime, BYTE keyboardState[256]) override;
	virtual void drawText(SpriteBatch* batch) override;


	vector<TextLabel*> labels;

	Vector2 indicatorPos;
	bool indicatorOn = false;
	float indicatorRot = 0;
protected:

	FontSet* font;

	Vector2 firstLabelPos;



	int marginOffset = 20;
	int spaceBetweenLines = 25;

	const float indicatorFlashTime = 1;
	float currentFlashTime = indicatorFlashTime;

	bool lastEnter = false;
	//bool lastUp = false;

private:
	wstring originalText;
	wstring text;


	Vector2 currentLabelPos;
	int currentLineStart;
	int textPos = -1;
	vector<int> newLinePos;

	float letterDelay = Globals::LETTER_DELAY;
	float timeSinceLastLetter = 0;

	bool writeNextLetter = true;
	bool writingDone = false;
	float maxLineLength;
	float maxTextHeight;
	int numLines = 0;

	

};