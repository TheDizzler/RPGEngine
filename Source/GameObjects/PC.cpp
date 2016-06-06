#include "PC.h"

unique_ptr<PC> PC::pc;

PC::PC() {

	gameObject.reset(new GameObject());
	gameObject->gid = 140;
	gameObject->name = "PC";
	gameObject->width = 16;
	gameObject->height = 16;
}

PC::~PC() {
}

Vector2 PC::getPosition() {
	//return Vector2(gameObject->x, gameObject->y);
	return gameObject->position;
}

void PC::update(double deltaTime, Vector2 move) {

	gameObject->move(move);
	gameObject->update(deltaTime);
}
