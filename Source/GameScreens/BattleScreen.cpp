#include "BattleScreen.h"

BattleScreen::BattleScreen() {
}

BattleScreen::~BattleScreen() {
}

using namespace Globals;

bool BattleScreen::initialize(ID3D11Device* device, TextBoxManager* txtBxMng) {


	guiFont.reset(new FontSet());
	if (!guiFont->load(device, Assets::battleFontFile))
		return false;
	guiFont->setTint(DirectX::Colors::White.v);


	textBoxManager = txtBxMng;
	/*textBoxFactory.reset(new TextBoxManager());
	if (!textBoxFactory->load(device))
		return false;*/


	enemyBox = new ListBox(WINDOW_HEIGHT - LISTBOX_HEIGHT, TEXTBOX_MARGIN,
		LISTBOX_WIDTH + TEXTBOX_MARGIN, WINDOW_HEIGHT, guiFont.get());
	pcBox = new ListBox(WINDOW_HEIGHT - LISTBOX_HEIGHT, enemyBox->rect.right,
		LISTBOX_WIDTH + enemyBox->rect.right, WINDOW_HEIGHT, guiFont.get());

	/*int leftPos = TEXTBOX_MARGIN + LISTBOX_WIDTH / 2;
	int topPos = enemyBox->rect.top - LISTBOX_HEIGHT / 2;*/
	/*CommandBox* commandBox = new CommandBox(topPos, leftPos,
		LISTBOX_WIDTH + leftPos, topPos + LISTBOX_HEIGHT);
	commandBox->labels.push_back(new TextLabel(Vector2(0, 0), guiFont.get(), "Fight"));
	commandBox->labels.push_back(new TextLabel(Vector2(0, 0), guiFont.get(), "Magic"));
	commandBox->labels.push_back(new TextLabel(Vector2(0, 0), guiFont.get(), "Item"));
	commandBox->labels.push_back(new TextLabel(Vector2(0, 0), guiFont.get(), "Run"));

	commandBoxes.push_back(commandBox);*/


	int numAdded = 0;
	Enemy* enemy = new Enemy("Enemy 1");
	if (!enemy->load(device, Assets::beetleFile))
		return false;
	enemy->setPosition(enemy1Position);
	enemy->setScale(Vector2(4, 4));
	TextLabel* label = enemy->setBattleLabel(new TextLabel(
		Vector2(enemyLabelLocation.x, enemyLabelLocation.y + labelOffset*numAdded++),
		guiFont.get()));
	//enemyBox->labels.push_back(label);
	actors.push_back(enemy);

	enemy = new Enemy("Enemy 2");
	if (!enemy->load(device, Assets::beetleFile))
		return false;
	enemy->setPosition(enemy2Position);
	enemy->setScale(Vector2(4, 4));
	label = enemy->setBattleLabel(new TextLabel(
		Vector2(enemyLabelLocation.x, enemyLabelLocation.y + labelOffset*numAdded++),
		guiFont.get()));
	//enemyBox->labels.push_back(label);
	actors.push_back(enemy);

	enemy = new Enemy("Enemy 3");
	if (!enemy->load(device, Assets::beetleFile))
		return false;
	enemy->setPosition(enemy3Position);
	enemy->setScale(Vector2(4, 4));
	label = enemy->setBattleLabel(new TextLabel(
		Vector2(enemyLabelLocation.x, enemyLabelLocation.y + labelOffset*numAdded++),
		guiFont.get()));
	//enemyBox->labels.push_back(label);
	actors.push_back(enemy);

	//numAdded = 0;

	//BattleCharacter* character = new BattleCharacter("Character 1");
	//if (!character->load(device, Assets::blueDudeFile))
	//	return false;
	//label = character->setBattleLabel(new TextLabel(
	//	Vector2(characterLabelLocation.x, characterLabelLocation.y + labelOffset*numAdded++),
	//	guiFont.get()));
	////label->setText("Character 1");
	////characterLabels.push_back(label);
	//actors.push_back(character);

	///*label = new TextLabel(
	//	Vector2(characterLabelLocation.x, characterLabelLocation.y + labelOffset*numAdded++),
	//	guiFont.get());
	//label->setText("Character 2");
	//characterLabels.push_back(label);

	//label = new TextLabel(
	//	Vector2(characterLabelLocation.x, characterLabelLocation.y + labelOffset*numAdded++),
	//	guiFont.get());
	//label->setText("Character 3");
	//characterLabels.push_back(label);*/

	//


	return true;
}

void BattleScreen::setGameManager(Game* gm) {

	game = gm;
}


void BattleScreen::update(double deltaTime, BYTE keyboardState[256], MouseController * mouse) {

	for (BattleSprite* sprite : actors) {
		sprite->update(deltaTime);
		if (sprite->isReady) {
			int leftPos = TEXTBOX_MARGIN + LISTBOX_WIDTH / 2;
			int topPos = enemyBox->rect.top - LISTBOX_HEIGHT / 2;
			CommandBox * box = new CommandBox(topPos, leftPos,
				LISTBOX_WIDTH + leftPos, topPos + LISTBOX_HEIGHT, guiFont.get());
			commandBoxes.insert(commandBoxes.begin(), box);
		}
	}

	currentCommandBox->update(deltaTime, keyboardState);

}

void BattleScreen::draw(SpriteBatch * batch) {


	for (BattleSprite* actor : actors) {
		if (actor->isAlive) {
			actor->draw(batch);

		}

	}

	/*textBoxManager->draw(batch, enemyBox);
	textBoxManager->draw(batch, pcBox);

	if (!currentCommandBox) {
		currentCommandBox = commandBoxes.back();
		commandBoxes.pop_back();
	}
	for (CommandBox* commandBox : commandBoxes)
		textBoxManager->draw(batch, commandBox);*/

			/*for (TextLabel* label : characterLabels)
				label->draw(batch);*/

			//if (playerTurn) // show battle commands
			//	for (TextLabel* label : battleCommandLabels)
			//		label->draw(batch);
}
