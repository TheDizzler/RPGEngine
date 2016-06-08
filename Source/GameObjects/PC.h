#pragma once

#include <memory>
#include "MapObjects/GameObject.h"

const float WALK_SPEED = 135;
/** A class with a static pointer to an instance of itself because I
	don't know of a better way to handle this in C++. Yay for circular references.*/
class PC {
public:
	PC();
	~PC();

	// map representation of pc
	unique_ptr<GameObject> gameObject;
	//bool collided[4] = {false, false, false, false};


	Vector2 getPosition();

	/** Collision detection is done on map level */
	void update(double deltaTime, Vector2 move);

	static unique_ptr<PC> pc;
private:


};
