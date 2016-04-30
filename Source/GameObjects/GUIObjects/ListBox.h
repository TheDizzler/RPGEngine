#pragma once

#include "TextBox.h"

/** A TextBox with a list of non-interactable items. */
class ListBox : public TextBox {
public:
	ListBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~ListBox();

	virtual void drawText(SpriteBatch* batch) override;


protected:
	bool lastDown = false;
	bool lastUp = false;

private:

};