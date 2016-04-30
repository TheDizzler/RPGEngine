#include "ListBox.h"

ListBox::ListBox(int top, int left, int right, int bottom, FontSet* fontSet)
	: TextBox(top, left, right, bottom, fontSet) {

	
}

ListBox::~ListBox() {
}

void ListBox::drawText(SpriteBatch * batch) {


	Vector2 i(0, 0);
	for (TextLabel* label : labels) {
		label->position = firstLabelPos + i;
		label->draw(batch);
		i.y += spaceBetweenLines;
	}
}
