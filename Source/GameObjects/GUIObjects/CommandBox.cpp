#include "CommandBox.h"

CommandBox::CommandBox(int top, int left, int right, int bottom, FontSet* fontSet)
	: TextBox(top, left, right, bottom, fontSet) {

	indicatorOn = true;
	indicatorPos = firstLabelPos + indicatorOffset;
	itemSelected = 0;

}

CommandBox::~CommandBox() {
}


void CommandBox::loadNodes(xml_node nd, vector<xml_node> nds) {

	node = nd;
	nodeList = nds;

	indicatorOn = true;
	indicatorPos = firstLabelPos + indicatorOffset;
	itemSelected = 0;
}


bool CommandBox::update(double deltaTime, BYTE keyboardState[256]) {

	/*if (nodeSelected) {
		return false;
} else */
	{
		nodeSelected = false;

		currentFlashTime += deltaTime;
		if (currentFlashTime >= indicatorFlashTime) {
			indicatorOn = !indicatorOn;
			currentFlashTime = 0;
		}

		if ((keyboardState[DIK_DOWN] & 0x80) && !lastDown) {

			lastDown = true;
			lastUp = false;
			++itemSelected;
			if (itemSelected >= nodeList.size()) {
				itemSelected = 0;
				indicatorPos = firstLabelPos + indicatorOffset;
			} else
				indicatorPos.y += spaceBetweenLines;
			indicatorOn = true;
			currentFlashTime = 0;

		} else if ((keyboardState[DIK_UP] & 0x80) && !lastUp) {

			lastUp = true;
			lastDown = false;
			--itemSelected;
			if (itemSelected < 0) {
				itemSelected = nodeList.size() - 1;
				indicatorPos.y = firstLabelPos.y + indicatorOffset.y
					+ itemSelected*spaceBetweenLines;
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

		if (keyboardState[DIK_RETURN] & 0x80 && !lastEnter) { // perform action for selected node

			nodeSelected = true;

			/*const char_t* type = nodeList[itemSelected].name();
			if (type == "dialog") {
				textBox = new TextBox(rect.top, rect.left + overlap,
					rect.right + overlap, rect.bottom, font);
				textBox->loadNode(nodeList[itemSelected]);

			}*/
			return true;

		}

	}

	if (!(keyboardState[DIK_RETURN] & 0x80)) {
		lastEnter = false;
	}

	return false;

}

xml_node CommandBox::getSelectedNode() {

	nodeSelected = false;
	lastEnter = true;

	// read to attribute of selected
	const char_t* reply = nodeList[itemSelected].attribute("to").as_string();
	//string reply_s = reply;

	return node.parent().find_child_by_attribute(attributeTypes[FROM], reply);

}

bool CommandBox::isQuery() {
	return true;
}

void CommandBox::drawText(SpriteBatch * batch) {

	Vector2 i(0, 0);
	for (xml_node node : nodeList) {

		wstring name;
		const char_t* ch_name = node.text().as_string();
		wstringstream wss;
		wss << ch_name;
		name = wss.str();

		font->draw(batch, name.c_str(), firstLabelPos + i);
		i.y += spaceBetweenLines;

	}

}

