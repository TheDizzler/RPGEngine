#pragma once

#include <queue>
#include <dinput.h>

#include "pugixml.hpp"

#include "../../globals.h"
#include "GUIBox.h"
//#include "../../Engine/BaseGraphics/Sprite.h"
#include "TextLabel.h"
//#include "../GameVariables.h"


using namespace pugi;

class Game;

static const enum Nodes {
	DIALOG_TEXT, QUERY, ALPHA_INPUT, EFFECT
};
static const char_t* nodeTypes[] = {"dialogText", "query", "alphaInput", "effect"};


static const enum ATTRIBUTES {
	SPEAKER, TO, FROM, DEFAULT
};
static const char_t* attributeTypes[] = {"speaker", "to", "from", "default"};



class TextBox : public GUIBox {
public:
	TextBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~TextBox();

	virtual void loadNode(xml_node node, Vector2* speakerPos = NULL);


	virtual bool update(double deltaTime, SimpleKeyboard* keys) override;
	virtual void drawText(SpriteBatch* batch) override;

	bool isTooFar();
	virtual bool closing(double deltaTime) override;

	/** Get next node in dialog chain. */
	virtual xml_node getSelectedNode();
	virtual bool isQuery();
	virtual bool isAlphaInput();

	Vector2 indicatorPos;
	bool indicatorOn = false;
	float indicatorRot = 0;
	Vector2* speakerPos = NULL;


protected:

	FontSet* font;

	Vector2 firstLabelPos;



	int marginOffset = 20;
	int spaceBetweenLines = 25;

	const float indicatorFlashTime = 1;
	float currentFlashTime = indicatorFlashTime;

	bool lastEnter = true;

	xml_node node;


	

private:

	wstring originalText;
	wstring text;
	void parseText(wstring text);

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