#include "GameObject.h"

GameObject::GameObject() {
}

GameObject::~GameObject() {
}

void GameObject::setRect() {

	rect = {x, y, x + width, y + height};
}

void GameObject::move(Vector2 moveAmount) {

	x += moveAmount.x;
	y += moveAmount.y;
	rect = {x, y, x + width, y + height};
}

void GameObject::update(double deltaTime) {

	
}
