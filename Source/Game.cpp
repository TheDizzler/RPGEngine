#include "Game.h"

Game::Game(GameEngine* gmngn) {

	gameEngine = gmngn;
}

Game::~Game() {

	//xmlFreeDoc(doc);
	//xmlCleanupParser();
	delete doc;
}

bool Game::initializeGame(ID3D11Device* dvc, MouseController* ms) {

	device = dvc;
	mouse = ms;

	if (!parseGameText()) {
		MessageBox(0, L"Could not parse game text", L"Error parsing text", MB_OK);
		return false;
	}


	textBoxManager.reset(new TextBoxManager(doc));
	if (!textBoxManager->load(device))
		return false;


	currentScreen = new MenuTest();
	if (!currentScreen->initialize(device, textBoxManager.get()))
		return false;
	currentScreen->setGameManager(this);


	return true;
}



//void Game::update(double deltaTime, BYTE keyboardState[256],
//	MouseController* mouse) {
//
//
//	currentScreen->update(deltaTime, keyboardState, mouse);
//
//}

void Game::update(double deltaTime, SimpleKeyboard* keys) {

	currentScreen->update(deltaTime, keys);
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

map<wstring, wstring> Game::storedVariables;

void Game::storeVariable(wstring escape, wstring * store) {

	//MessageBox(0, store->c_str(), escape.c_str(), MB_OK);
	if (escape == escapeStrings[hero])
		storedVariables[escape] = *store;


	/*storedVariables[escapeStrings[temp1]] = L"Temp 1!";
	storedVariables[escapeStrings[temp2]] = L"Temp 2!";
	MessageBox(0, storedVariables[escapeStrings[hero]].c_str(), escapeStrings[hero].c_str(), MB_OK);
	MessageBox(0, storedVariables[escapeStrings[temp1]].c_str(), escapeStrings[temp1].c_str(), MB_OK);
	MessageBox(0, storedVariables[escapeStrings[temp2]].c_str(), escapeStrings[temp2].c_str(), MB_OK);*/
}

wstring Game::getStoredVariable(wstring escape) {

	/*MessageBox(0, storedVariables[escapeStrings[hero]].c_str(), escapeStrings[hero].c_str(), MB_OK);
	MessageBox(0, storedVariables[escapeStrings[temp1]].c_str(), escapeStrings[temp1].c_str(), MB_OK);
	MessageBox(0, storedVariables[escapeStrings[temp2]].c_str(), escapeStrings[temp2].c_str(), MB_OK);*/

	if (escape == escapeStrings[hero])
		return storedVariables[escape];

	return L"NOTHING FOUND!";
}

bool Game::parseGameText() {


	doc = new pugi::xml_document();
	if (!doc->load_file(Assets::gameTextFile)) {
		MessageBox(0, L"Could not read gameTextFile", L"Error", MB_OK);
		return false;
	}

	return true;
}




