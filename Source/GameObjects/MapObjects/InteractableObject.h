#pragma once

//#include "GameObject.h"


/** An object on a map that can be used in some way. */
class InteractableObject/* : GameObject */{
public:
	InteractableObject();
	~InteractableObject();

	virtual void interact() = 0;

private:


};