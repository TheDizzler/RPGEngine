#include "EventHandler.h"

EventHandler::EventHandler(TextBoxManager* txtBxMng) {

	textBoxManager = txtBxMng;
	rootEventNode = textBoxManager->triggeredNode;
}

EventHandler::~EventHandler() {
}

void EventHandler::loadEvent(EventObject* event) {

	currentEvent = event;
	eventNode = rootEventNode.find_child_by_attribute("name", currentEvent->name_string.c_str());

	eventList = eventNode.children().begin();
}

bool EventHandler::update(double deltaTime, SimpleKeyboard* keys) {

	if (nodeDone) {

		currentNode = (eventList++)->first_child();

		// get next action from event
		if (strcmp(currentNode.name(), "dialogText")) {
			textBoxManager->setDialog(currentNode);
			nodeDone = false;
		} else if (strcmp(currentNode.name(), "effect")) {

			nodeDone = false;
		}
	}

	nodeDone = textBoxManager->isDialogChainDone();

	return !nodeDone;
}
