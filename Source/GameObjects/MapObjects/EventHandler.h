#pragma once

#include "../GUIObjects/TextBoxManager.h"
#include "EventObject.h"


class EventHandler {
public:
	EventHandler(TextBoxManager* txtBxMng);
	~EventHandler();

	void loadEvent(EventObject* event);

	bool update(double deltaTime, SimpleKeyboard* keys);

	TextBoxManager* textBoxManager;
private:

	EventObject* currentEvent;
	xml_node rootEventNode;
	xml_node eventNode;
	xml_node currentNode;

};