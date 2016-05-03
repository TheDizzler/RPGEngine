#include "ListBox.h"

ListBox::ListBox(int top, int left, int right, int bottom, FontSet* fontSet)
	: TextBox(top, left, right, bottom, fontSet) {

	indicatorOn = true;
	indicatorPos = firstLabelPos + indicatorOffset;
	labelSelected = 0;
}

ListBox::~ListBox() {
}

void ListBox::loadList(vector<xml_node> nodes, vector<TextLabel*> lbls) {

	nodeList = nodes;
	labels = lbls;
}

void ListBox::update(double deltaTime, BYTE keyboardState[256]) {

	currentFlashTime += deltaTime;
	if (currentFlashTime >= indicatorFlashTime) {
		indicatorOn = !indicatorOn;
		currentFlashTime = 0;
	}

	if ((keyboardState[DIK_DOWN] & 0x80) && !lastDown) {

		lastDown = true;
		lastUp = false;
		++labelSelected;
		if (labelSelected >= labels.size()) {
			labelSelected = 0;
			indicatorPos = firstLabelPos + indicatorOffset;
		} else
			indicatorPos.y += spaceBetweenLines;
		indicatorOn = true;
		currentFlashTime = 0;

	} else if ((keyboardState[DIK_UP] & 0x80) && !lastUp) {

		lastUp = true;
		lastDown = false;
		--labelSelected;
		if (labelSelected < 0) {
			labelSelected = labels.size() - 1;
			indicatorPos.y = firstLabelPos.y + indicatorOffset.y
				+ labelSelected*spaceBetweenLines;
		} else
			indicatorPos.y -= spaceBetweenLines;
		indicatorOn = true;
		currentFlashTime = 0;

	}

	if (!(keyboardState[DIK_DOWN] & 0x80)) {
		lastDown = false;
	}
	if (!(keyboardState[DIK_UP] & 0x80)) {
		lastUp = false;
	}



}

void ListBox::drawText(SpriteBatch * batch) {


	Vector2 i(0, 0);
	for (TextLabel* label : labels) {
		label->position = firstLabelPos + i;
		label->draw(batch);
		i.y += spaceBetweenLines;
	}

}
