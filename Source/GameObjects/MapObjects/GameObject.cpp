#include "GameObject.h"

GameObject::GameObject() {
}

GameObject::~GameObject() {
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

}
