#include "EventHandler.h"

EventHandler::EventHandler(TextBoxManager* txtBxMng) {

	textBoxManager = txtBxMng;
	rootEventNode = textBoxManager->triggeredNode;
}

EventHandler::~EventHandler() {
}

void EventHandler::loadEvent(EventObject* event) {

	currentEvent = event;
	eventNode = rootEventNode.find_child_by_attribute("name", currentEvent->name.c_str());
	currentNode = eventNode.first_child();

}

bool EventHandler::update(double deltaTime, SimpleKeyboard* keys) {

	if (strcmp(currentNode.name(), "dialogText")) {
	textBoxManager->

	}

	return true;
}
