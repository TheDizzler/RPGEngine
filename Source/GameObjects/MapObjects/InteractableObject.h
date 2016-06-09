#pragma once

#include <string>

//#include "GameObject.h"


/** An object on a map that can be used in some way. */
class InteractableObject/* : GameObject */{
public:
	InteractableObject();
	~InteractableObject();

	virtual std::string interact() = 0;

private:


};