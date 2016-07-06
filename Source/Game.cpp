#include "Game.h"

unique_ptr<MapScreen> Game::mapScreen;


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



	battleScreen.reset(new BattleScreen());
	if (!battleScreen->initialize(device, textBoxManager.get()))
		return false;
	battleScreen->setGameManager(this);

	menuScreen.reset(new MenuScreen());
	if (!menuScreen->initialize(device, textBoxManager.get()))
		return false;
	menuScreen->setGameManager(this);

	mapScreen.reset(new MapScreen(docMapLegend));
	if (!mapScreen->initialize(device, textBoxManager.get()))
		return false;
	mapScreen->setGameManager(this);

	currentScreen = mapScreen.get();

	wstring name = L"Pharty Bolz";
	storeVariable(L"hero", &name);


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

	gameEngine->exit();
}

map<wstring, wstring> Game::storedVariables;


void Game::storeVariable(wstring escape, wstring* toStore) {

	storedVariables[escape] = *toStore;
}

wstring Game::getStoredVariable(wstring escape) {

	if (storedVariables.find(escape) == storedVariables.end())
		return L"NOTHING FOUND!";

	return storedVariables[escape];
}


void Game::runScript(wstring script) {

	script = script.substr(1, script.length() - 2);
	//MessageBox(0, script.c_str(), L"Script Test", MB_OK);

	// parse commands
	for (int i = 1; i < script.length(); ++i) {

		wchar_t ch = script[i];
		while (isalpha(ch)) {
			ch = script[++i];
		}

		wstring object = script.substr(1, --i);

		GameObject* gameObject = mapScreen->getGameObject(object);

		//MessageBox(0, gameObject->name_wstring.c_str(), L"Script Test", MB_OK);
		if (gameObject == NULL) {
			MessageBox(0, L"No object found!", L"Fatal Error?", MB_OK);
			return;
		}

		if (object == escapeStrings[PC_ESC]) {
			// parse actions to take
			i += 3;
			int start = i;
			ch = script[i];
			while (isalpha(ch)) {
				ch = script[++i];
			}
			wstring command = script.substr(start, i - start);
			//MessageBox(0, command.c_str(), L"Script Test", MB_OK);
			if (command == escapeStrings[MOVE_BY]) {

				i += 1;
				start = i;
				ch = script[i];
				while (isdigit(ch) || ch == '-') {
					ch = script[++i];
				}
				wstring x = script.substr(start, i - start);

				i += 1;
				start = i;
				ch = script[i];
				while (isdigit(ch) || ch == '-') {
					ch = script[++i];
				}
				wstring y = script.substr(start, i - start);
				//MessageBox(0, y.c_str(), L"Script Test", MB_OK);

				Vector2 moveby(stoi(x), stoi(y));

				gameObject->setMovement(moveby);

			}
		}
		break;
	}
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




