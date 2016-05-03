#pragma once

//#include <libxml/tree.h>

#include "pugixml.hpp"

#include "TextBox.h"


using namespace pugi;

/** A TextBox with a list of non-interactable items. */
class ListBox : public TextBox {
public:
	ListBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~ListBox();

	virtual void loadList(vector<xml_node> nodes, vector<TextLabel*> labels);

	virtual void update(double deltaTime, BYTE keyboardState[256]) override;
	virtual void drawText(SpriteBatch* batch) override;


protected:
	bool lastDown = false;
	bool lastUp = false;

	vector<xml_node> nodeList;
	vector<TextLabel*> labels;

	int labelSelected = -1;
	Vector2 indicatorOffset = Vector2(-12, 12);

private:

};