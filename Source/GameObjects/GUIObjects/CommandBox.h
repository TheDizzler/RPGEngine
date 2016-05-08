#pragma once



#include "ListBox.h"



class CommandBox : public TextBox {
public:
	CommandBox(int top, int left, int right, int bottom, FontSet* fontSet);
	~CommandBox();

	void loadNodes(xml_node node, vector<xml_node> subNodes);

	//virtual bool update(double deltaTime, BYTE keyboardState[256]) override;
	virtual bool update(double deltaTime, SimpleKeyboard* keys) override;
	virtual void drawText(SpriteBatch* batch);

	virtual xml_node getSelectedNode() override;
	virtual bool isQuery() override;
	bool nodeSelected = false;

private:

	bool lastDown = false;
	bool lastUp = false;

	vector<xml_node> nodeList;

	int itemSelected = -1;
	Vector2 indicatorOffset = Vector2(-12, 12);

	TextBox* textBox;


};