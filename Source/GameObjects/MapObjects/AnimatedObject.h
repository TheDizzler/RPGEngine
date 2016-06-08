#pragma once

#include "SpriteObject.h"


class AnimatedObject : public SpriteObject {
public:
	AnimatedObject();
	~AnimatedObject();

	double timeElapsedSinceFrameSwitch = 0;
	int currentFrame = 0;
	int getGID();

	virtual void update(double deltaTime) override;

private:


};