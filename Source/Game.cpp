#include "Game.h"

Game::Game(GameEngine* gmngn) {

	gameEngine = gmngn;
}

Game::~Game() {

	//xmlFreeDoc(doc);
	//xmlCleanupParser();
	delete docDialogText;
}

bool Game::initializeGame(ID3D11Device* dvc, MouseController* ms) {

	device = dvc;
	mouse = ms;

	if (!parseGameText()) {
		MessageBox(0, L"Could not parse game text", L"Error parsing text", MB_OK);
		return false;
	}


	textBoxManager.reset(new TextBoxManager(docDialogText));
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

	//if (escape == escapeStrings[hero])

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

	//if (escape == escapeStrings[hero])
	if (storedVariables.find(escape) == storedVariables.end())
		return L"NOTHING FOUND!";

	return storedVariables[escape];
}

bool Game::parseGameText() {


	docDialogText = new pugi::xml_document();
	if (!docDialogText->load_file(Assets::gameTextFile)) {
		MessageBox(0, L"Could not read gameTextFile", L"Error", MB_OK);
		return false;
	}

	return true;
}




