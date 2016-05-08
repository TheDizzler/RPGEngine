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

	//void update(double deltaTime, BYTE keyboardState[256]);
	void update(double deltaTime, SimpleKeyboard* keys);
	/** RECT should be a multiple of border sprite length/height
		(currently 16x16). */
	void draw(SpriteBatch* batch/*, TextBox* textBox*/);

	void startDialogTest();

private:

	unique_ptr<FontSet> guiFont;

	xml_document* xmlDoc;
	xml_node rootNode;

	unique_ptr<Sprite> indicator;
	unique_ptr<Sprite> corner;
	unique_ptr<Sprite> side;
	unique_ptr<Sprite> bg;

	TextBox* currentBox;
	/** currentBox should always be top box. */
	vector<TextBox*> textBoxes;


	/** Amount in pixels that one guibox will overlap it's parent box. */
	const int overlap = 12;

	unique_ptr<TextBox> dialogBox;
	unique_ptr<CommandBox> commandBox;
	unique_ptr<AlphaInputBox> alphaBox;



};