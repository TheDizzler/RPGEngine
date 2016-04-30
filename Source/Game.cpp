#include "Game.h"

Game::Game(GameEngine* gmngn) {

	gameEngine = gmngn;
}

Game::~Game() {
}

bool Game::initializeGame(ID3D11Device* dvc, MouseController* ms) {

	device = dvc;
	mouse = ms;

	textBoxManager.reset(new TextBoxManager());
	if (!textBoxManager->load(device))
		return false;


	currentScreen = new MenuTest();
	if (!currentScreen->initialize(device, textBoxManager.get()))
		return false;
	currentScreen->setGameManager(this);


	return true;
}



void Game::update(double deltaTime, BYTE keyboardState[256],
	MouseController* mouse) {

	
	currentScreen->update(deltaTime, keyboardState, mouse);
	
}




void Game::draw(SpriteBatch * batch) {

	currentScreen->draw(batch);

}

void Game::loadLevel() {

	if (lastScreen)
		delete lastScreen;
	lastScreen = currentScreen;
	currentScreen = new BattleScreen();

	if (!currentScreen->initialize(device, textBoxManager.get())) {
		MessageBox(NULL, L"Failed to load screen", L"ERROR", MB_OK);
		exit();
	}
	currentScreen->setGameManager(this);

}

void Game::loadMainMenu() {

	if (lastScreen)
		delete lastScreen;
	lastScreen = currentScreen;
	currentScreen = new BattleScreen();

	if (!currentScreen->initialize(device, textBoxManager.get())) {
		MessageBox(NULL, L"Failed to load main menu", L"ERROR", MB_OK);
		exit();
	}
	currentScreen->setGameManager(this);
}


#include "Engine/GameEngine.h"

void Game::exit() {


	//dialogs.push_back(exitDialog.get());

	gameEngine->exit();
}

