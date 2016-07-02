#pragma once

#include "ListBox.h"
#include "CommandBox.h"
#include "AlphaInputBox.h"


using namespace std;


class TextBoxManager {
public:
	TextBoxManager(xml_document* xmlDoc);
	~TextBoxManager();

	bool load(ID3D11Device* device);
	void loadZone(string location);

	
	void update(double deltaTime, SimpleKeyboard* keys);
	/**  Called from Game.cpp.
	*		RECT should be a multiple of border sprite length/height
			(currently 16x16). */
	void draw(SpriteBatch* batch);


	void getDialog(string speaker, Vector2* speakerPos = NULL);
	void getTriggeredEvent(string eventName);

	/** Returns TRUE if no more dialog boxes left in this dialog chain. */
	bool isDialogChainDone();
	bool isTextBoxOpen();

	bool isModal();

	void setDialog(xml_node dialogTextNode);
	xml_node triggeredNode;

private:

	unique_ptr<FontSet> guiFont;

	xml_document* xmlDoc;
	xml_node rootNode;
	xml_node eventNode;
	

	xml_node zoneTextNode;


	unique_ptr<Sprite> indicator;
	unique_ptr<Sprite> corner;
	unique_ptr<Sprite> side;
	unique_ptr<Sprite> bg;

	TextBox* currentBox = NULL;
	/** currentBox should always be top box. */
	vector<TextBox*> textBoxes;
	vector<TextBox*> closingBoxes;

	/** Amount in pixels that one guibox will overlap it's parent box. */
	const int overlap = 12;

	//unique_ptr<TextBox> dialogBox;
	unique_ptr<CommandBox> commandBox;
	unique_ptr<AlphaInputBox> alphaBox;


	void drawBox(TextBox* textBox, SpriteBatch* batch);
};