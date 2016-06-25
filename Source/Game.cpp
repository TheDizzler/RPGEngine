#include "Game.h"

#include "Engine/GameEngine.h"
Game::Game(GameEngine* gmngn) {

	gameEngine = gmngn;
	camera = gameEngine->camera.get();
}

Game::~Game() {

	delete docDialogText;
	delete docMapLegend;
	delete docSpriteFiles;
}

#include "GameObjects/PC.h"
bool Game::initializeGame(ID3D11Device* dvc, MouseController* ms) {

	device = dvc;
	mouse = ms;

	if (!parseXMLFiles()) {
		MessageBox(0, L"Could not parse game text", L"Error parsing text", MB_OK);
		return false;
	}


	textBoxManager.reset(new TextBoxManager(docDialogText));
	if (!textBoxManager->load(device))
		return false;

	PC::pc.reset(new PC());
	PC::pc->gameObject->name = "PC";

	mapScreen.reset(new MapScreen(docMapLegend));
	if (!mapScreen->initialize(device, textBoxManager.get()))
		return false;
	mapScreen->setGameManager(this);

	battleScreen.reset(new BattleScreen());
	if (!battleScreen->initialize(device, textBoxManager.get()))
		return false;
	battleScreen->setGameManager(this);

	menuScreen.reset(new MenuScreen());
	if (!menuScreen->initialize(device, textBoxManager.get()))
		return false;
	menuScreen->setGameManager(this);



	currentScreen = menuScreen.get();


	return true;
}



void Game::update(double deltaTime, SimpleKeyboard* keys) {

	currentScreen->update(deltaTime, keys);
}




void Game::draw(SpriteBatch * batch) {

	currentScreen->draw(batch);

}

void Game::drawTextBoxes(SpriteBatch * batchDialog) {

	textBoxManager->draw(batchDialog);
}

void Game::loadLevel() {

	if (lastScreen)
		delete lastScreen;
	lastScreen = currentScreen;
	//currentScreen = new BattleScreen();

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
	//currentScreen = new BattleScreen();

	if (!currentScreen->initialize(device, textBoxManager.get())) {
		MessageBox(NULL, L"Failed to load main menu", L"ERROR", MB_OK);
		exit();
	}
	currentScreen->setGameManager(this);
}




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

bool Game::parseXMLFiles() {


	docDialogText = new pugi::xml_document();
	if (!docDialogText->load_file(Assets::gameTextFile)) {
		MessageBox(0, L"Could not read gameTextFile", L"Error", MB_OK);
		return false;
	}

	docMapLegend = new pugi::xml_document();
	if (!docMapLegend->load_file(Assets::mapLegendFile)) {
		MessageBox(0, L"Could not read MapLegend file", L"Error", MB_OK);
		return false;
	}


	//MessageBox(0, Globals::convertCharStarToWCharT(Assets::mapLegendFile), L"This is test desu.", MB_OK);

	docSpriteFiles = new pugi::xml_document();
	if (!docSpriteFiles->load_file(Assets::spriteFiles)) {
		MessageBox(0, L"Could not read SpriteFiles file", L"Error", MB_OK);
		return false;
	}


	return true;
}




