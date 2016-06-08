#pragma once

#include "GameObject.h"

/** A Visible Object on a map. */
class SpriteObject : public GameObject {
public:
	SpriteObject();
	~SpriteObject();

	Vector2 origin;

	/* Direction objects (usually a character) is facing/ */
	int facing = DOWN;
	int getGID();


	SpriteSheet::SpriteFrame* spriteFrame;

	//bool collided[4] = {false, false, false, false};

private:


};