#pragma once

#include <stdio.h>



#include "GameScreens\BattleScreen.h"
#include "GameObjects\GUIObjects\MenuTest.h"
#include "Engine\MouseController.h"


enum GameState {
	menu, paused, playing
};


class GameEngine;

/** The lowest level of class where game code should be included.
	Everything below this (GameEngine downward) should generally go unmodified. */
class Game {
public:
	Game(GameEngine* gameEngine);
	~Game();


	bool initializeGame(ID3D11Device* device, MouseController* mouse);


	//void update(double deltaTime, BYTE keyboardState[256], MouseController* mouse);
	void update(double deltaTime, SimpleKeyboard* keys);
	void draw(SpriteBatch* batch);


	void loadLevel();
	void loadMainMenu();
	void exit();

private:

	Screen* currentScreen;
	Screen* lastScreen = 0;

	GameEngine* gameEngine;
	MouseController* mouse;
	ID3D11Device* device;

	unique_ptr<TextBoxManager> textBoxManager;
	

	//xmlDoc* doc;
	//xmlNode* gameTextRootNode;
	pugi::xml_document* doc;
	pugi::xml_parse_result result;
	bool parseGameText();

	
};