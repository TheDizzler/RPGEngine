#pragma once

#include <stdio.h>


#include "GameScreens/MapScreen.h"
#include "GameScreens/BattleScreen.h"
#include "GameScreens/MenuScreen.h"
#include "GameObjects/GUIObjects/MenuTest.h"
#include "Engine/MouseController.h"
//#include "GameObjects/PC.h"

enum GameState {
	menu, paused, playing
};

static const enum EscapeStrings {
	HERO, PC_ESC, SPEAKER_ESC, MOVE_TO, MOVE_BY
};
static const wstring escapeStrings[] = {
		L"hero", L"pc", L"speaker", L"moveto", L"moveby"
};



class GameEngine;

/** The lowest level of class where game code should be included.
	Everything below this (GameEngine downward) should generally go unmodified. */
class Game {
public:
	Game(GameEngine* gameEngine);
	~Game();


	bool initializeGame(ID3D11Device* device, MouseController* mouse);


	void update(double deltaTime, SimpleKeyboard* keys);
	void draw(SpriteBatch* batch);
	void drawTextBoxes(SpriteBatch* batchDialog);

	void loadLevel();
	void loadMainMenu();
	void exit();

	// A pointer to all things player related
	//static PC* pc;

	static void storeVariable(wstring escape, wstring* store);
	static wstring getStoredVariable(wstring escape);
	static void runScript(wstring script);

	Camera* camera;
private:



	Screen* currentScreen;
	unique_ptr<MenuScreen> menuScreen;
	static unique_ptr<MapScreen> mapScreen;
	unique_ptr<BattleScreen> battleScreen;
	Screen* lastScreen = 0;

	GameEngine* gameEngine;
	MouseController* mouse;
	ID3D11Device* device;

	unique_ptr<TextBoxManager> textBoxManager;


	pugi::xml_document* docDialogText;
	pugi::xml_document* docMapLegend;
	pugi::xml_document* docSpriteFiles;

	bool parseXMLFiles();


	static map<wstring, wstring> storedVariables;

};