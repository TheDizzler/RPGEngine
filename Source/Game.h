#pragma once

#include <stdio.h>
#include <map>


#include "GameScreens\BattleScreen.h"
#include "GameObjects\GUIObjects\MenuTest.h"
#include "Engine\MouseController.h"


enum GameState {
	menu, paused, playing
};

static const enum EscapeStrings {
	hero, temp1, temp2
};

static const wstring escapeStrings[3] = {L"hero", L"temp1", L"temp2"};



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

	
	static void storeVariable(wstring escape, wstring* store);
	static wstring getStoredVariable(wstring escape);
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


	static map<wstring, wstring> storedVariables;
	//static const wchar_t* storedVariables[3] = {heroStoredName, L"0123456789", L"0123456789"};


	/*wstring tempA = L"Temp 1!";
	wstring tempB = L"Temp 2!";*/



};