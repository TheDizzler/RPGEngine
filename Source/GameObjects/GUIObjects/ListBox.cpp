#include "ListBox.h"

ListBox::ListBox(int top, int left, int right, int bottom, FontSet* fontSet)
	: TextBox(top, left, right, bottom, fontSet) {

	indicatorOn = false;
	
}

ListBox::~ListBox() {
}

void ListBox::loadList(vector<TextLabel*> lbls) {

	labels = lbls;
}

//bool ListBox::update(double deltaTime, BYTE keyboardState[256]) {
//
//	
//
//
//
//	return false;
//}


bool ListBox::update(double deltaTime, SimpleKeyboard * keys) {
	return false;
}

void ListBox::drawText(SpriteBatch * batch) {


	Vector2 i(0, 0);
	for (TextLabel* label : labels) {
		label->position = firstLabelPos + i;
		label->draw(batch);
		i.y += spaceBetweenLines;
	}



}
