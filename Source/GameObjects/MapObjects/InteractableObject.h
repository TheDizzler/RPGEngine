#pragma once

#include <string>


/** An object on a map that can be used in some way. */
class InteractableObject {
public:
	InteractableObject();
	~InteractableObject();

	virtual std::string interact() = 0;

private:


};