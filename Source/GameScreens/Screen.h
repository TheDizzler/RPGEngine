#pragma once

//#include <dinput.h>

#include "../GameObjects/GUIObjects/TextBoxManager.h"
#include "../GameObjects/GUIObjects/TextLabel.h"
#include "../Engine/MouseController.h"


class Game;

/** An interface class for a game screen; menu screens,
	battle screens, etc. */
interface Screen {
public:
	virtual bool initialize(ID3D11Device* device, TextBoxManager* textBoxManager) = 0;
	virtual void setGameManager(Game* game) = 0;
	//virtual void update(double deltaTime, BYTE keyboardState[256],
		//MouseController* mouse) = 0;
	virtual void update(double deltaTime, SimpleKeyboard* keys) = 0;
	virtual void draw(SpriteBatch* batch) = 0;

	TextBoxManager* textBoxManager;
	Game* game;
};