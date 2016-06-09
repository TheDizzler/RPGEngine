#pragma once

#include "InteractableObject.h"
#include "AnimatedObject.h"

class CharacterObject : public AnimatedObject, public InteractableObject  {
public:
	CharacterObject();
	~CharacterObject();

	virtual void update(double deltaTime) override;


	// Inherited via InteractableObject
	virtual string interact() override;
private:
};