#pragma once

#include <string>
#include <SimpleMath.h>

#include "../../Engine/SimpleKeyboard.h"
#include "../../Engine/BaseGraphics/SpriteSheet.h"


using namespace DirectX::SimpleMath;
using namespace std;

/** A basic object found on a map, either visible or not. */
class GameObject {
public:
	GameObject();
	~GameObject();

	string name;
	int id = -1;
	/* ID of tile representing this object. -1 means not meant to be a visible object.*/
	int gid = -1;
	/* Top-left coordinates of rect. */
	Vector2 position;
	int width, height;

	

	/* Used for collision detection. */
	RECT rect;
	/* Set the Hit Rect. */
	void setRect();

	void move(Vector2 moveAmount);
	virtual void update(double deltaTime);

private:


};