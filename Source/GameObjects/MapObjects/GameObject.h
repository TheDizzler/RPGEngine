#pragma once

#include <string>
#include <SimpleMath.h>

#include "../../Engine/SimpleKeyboard.h"
#include "../../Engine/BaseGraphics/SpriteSheet.h"


using namespace DirectX::SimpleMath;
using namespace std;

class GameObject {
public:
	GameObject();
	~GameObject();

	string name;
	int id = -1;
	/* ID of tile representing this object. */
	int gid = -1;
	/* Top-left coordinates of rect. */
	//int x, y;
	Vector2 position;
	Vector2 origin;
	int width, height;

	/* Direction objects (usually a character) is facing/ */
	int facing = DOWN;
	/* Time since the animation frame changed. */
	double timeElapsedSinceFrameSwitch = 0;
	int currentFrame = 0;
	int getGID();

	SpriteSheet::SpriteFrame* spriteFrame;

	//bool collided[4] = {false, false, false, false};

	RECT rect;
	void setRect();

	void move(Vector2 moveAmount);
	void update(double deltaTime);

private:


};