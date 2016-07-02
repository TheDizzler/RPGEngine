#pragma once

#include "../GUIObjects/TextBoxManager.h"
#include "EventObject.h"


class EventHandler {
public:
	EventHandler(TextBoxManager* txtBxMng);
	~EventHandler();

	void loadEvent(EventObject* event);

	/** Returns TRUE when event is completed or when control should be
	*	relinquished to player. */
	bool update(double deltaTime, SimpleKeyboard* keys);

	TextBoxManager* textBoxManager;
private:

	EventObject* currentEvent;
	xml_node rootEventNode;
	xml_node eventNode;
	xml_node currentNode;

	bool nodeDone = true;
	xml_node_iterator eventList;
	int eventi = 0;

};