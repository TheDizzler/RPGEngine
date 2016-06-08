#include "GameObject.h"

GameObject::GameObject() {
}

GameObject::~GameObject() {
}

int GameObject::getGID() {


	return gid + facing;
}

void GameObject::setRect() {

	rect = {(long) position.x, (long) position.y,
		(long) position.x + width, (long) position.y + height};
}

void GameObject::move(Vector2 moveAmount) {

	/*x += moveAmount.x;
	y += moveAmount.y;
	rect = {x, y, x + width, y + height};*/
	position += moveAmount;
	rect = {(long) position.x, (long) position.y,
		(long) position.x + width, (long) position.y + height};
}

void GameObject::update(double deltaTime) {

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
