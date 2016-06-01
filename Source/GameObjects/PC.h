#pragma once

#include <memory>
#include "GameObject.h"

const float WALK_SPEED = 175;
/** A class with a static pointer to an instance of itself because I
	don't know of a better way to handle this in C++. */
class PC {
public:
	PC();
	~PC();

	// map representation of pc
	unique_ptr<GameObject> gameObject;

	/** Collision detection is done on map level */
	void update(double deltaTime, Vector2 move);

	static unique_ptr<PC> pc;
private:


};
