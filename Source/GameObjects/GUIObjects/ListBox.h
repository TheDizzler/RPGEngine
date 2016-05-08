#pragma once

#include "TextBox.h"




/** A TextBox with a list of non-interactable items. */
class ListBox : public TextBox {
public:
	ListBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~ListBox();

	virtual void loadList(vector<TextLabel*> labels);

	//virtual bool update(double deltaTime, BYTE keyboardState[256]) override;
	virtual bool update(double deltaTime, SimpleKeyboard* keys) override;
	virtual void drawText(SpriteBatch* batch) override;


protected:

	vector<TextLabel*> labels;



private:

};