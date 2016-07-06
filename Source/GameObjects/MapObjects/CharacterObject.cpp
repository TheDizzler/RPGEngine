#include "CharacterObject.h"

CharacterObject::CharacterObject() : AnimatedObject() {
}

CharacterObject::~CharacterObject() {
}

void CharacterObject::update(double deltaTime) {

	AnimatedObject::update(deltaTime);
}

string CharacterObject::interact() {

	return name_string;
}
