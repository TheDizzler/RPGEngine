#include "AnimatedObject.h"

AnimatedObject::AnimatedObject() : SpriteObject() {
}

AnimatedObject::~AnimatedObject() {
}

int AnimatedObject::getGID() {
	return gid + facing;
}

void AnimatedObject::update(double deltaTime) {

	SpriteObject::update(deltaTime);

	timeElapsedSinceFrameSwitch += deltaTime;
	if (timeElapsedSinceFrameSwitch >= spriteFrame->animation->duration) {
		if (++currentFrame >= spriteFrame->animation->tileIDs.size()) {
			gid = spriteFrame->gid;
			currentFrame = 0;
		}
		gid += spriteFrame->animation->tileIDs[currentFrame];
		timeElapsedSinceFrameSwitch = 0;
	}
}
