#pragma once

#include <queue>
#include <dinput.h>

#include "pugixml.hpp"

#include "../../globals.h"
#include "GUIBox.h"
#include "../../Engine/BaseGraphics/Sprite.h"
#include "TextLabel.h"


using namespace pugi;


static const enum NODES {
	DIALOG_TEXT, QUERY, DIALOG_REPLY
};
static const char_t* nodeTypes[] = {"dialogText", "query", "dialogReply"};


class TextBox : public GUIBox {
public:
	TextBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~TextBox();

	void loadNode(xml_node node);


	virtual bool update(double deltaTime, BYTE keyboardState[256]) override;
	virtual void drawText(SpriteBatch* batch) override;

	/** Get next node in dialog chain. */
	virtual xml_node getSelectedNode();
	virtual bool isQuery();


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

	bool lastEnter = true;
	//bool lastUp = false;

	xml_node node;

private:

	wstring originalText;
	wstring text;
	void loadText(wstring text);

	Vector2 currentLabelPos;
	int currentLineStart;
	int textPos = 0;
	vector<int> newLinePos;

	float letterDelay = Globals::LETTER_DELAY;
	float timeSinceLastLetter = 0;

	bool writeNextLetter = true;
	bool writingDone = false;
	float maxLineLength;
	float maxTextHeight;
	int numLines = 0;


	
	

};