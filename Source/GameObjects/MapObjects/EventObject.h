#pragma once

#include "GameObject.h"


class EventObject : public GameObject {
public:
	EventObject();
	~EventObject();

	bool triggered = false;

	//xml_node eventNode;

private:


};