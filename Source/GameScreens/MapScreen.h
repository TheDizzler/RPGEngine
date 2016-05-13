#pragma once

#include "Screen.h"


class MapScreen : public Screen {
public:
	MapScreen();
	~MapScreen();

	// Inherited via Screen
	virtual bool initialize(ID3D11Device * device, TextBoxManager * textBoxManager) override;
	virtual void setGameManager(Game * game) override;
	virtual void update(double deltaTime, SimpleKeyboard * keys) override;
	virtual void draw(SpriteBatch * batch) override;



private:

	Game* game;

	TextBoxManager* textBoxManager;
};