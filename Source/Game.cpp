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

bool Game::parseGameText() {

	//LIBXML_TEST_VERSION;


	//doc = xmlReadFile(Assets::gameTextFile, NULL, 0);
	/*if (doc == NULL) {
		MessageBox(0, L"Could not read gameTextFile", L"Error", MB_OK);
		return false;
	}*/

	//gameTextRootNode = xmlDocGetRootElement(doc);

	doc = new pugi::xml_document();
	if (!doc->load_file(Assets::gameTextFile)) {
		MessageBox(0, L"Could not read gameTextFile", L"Error", MB_OK);
		return false;
	}

	/*wstring name;
	const char_t* ch_name = doc->child("root").child("dialog").name();
	wstringstream wss;
	wss << ch_name;
	name = wss.str();

	MessageBox(NULL, name.c_str(), L"Test", MB_OK);*/
	
	return true;
}

