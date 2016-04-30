#include "BattleSprite.h"

BattleSprite::BattleSprite(string name) : Sprite() {

	battleName = name;

	// setup basic battle commands: fight, run
	/*BattleCommand* command = new BattleCommand("Fight", this);
	commands.push_back(command);
	command = new BattleCommand("Run", this);
	commands.push_back(command);*/
}

BattleSprite::~BattleSprite() {
}

TextLabel* BattleSprite::setBattleLabel(TextLabel* label) {

	battleNameLabel.reset(label);
	battleNameLabel->setText(battleName);
	return battleNameLabel.get();
}

TextLabel* BattleSprite::getBattleLabel() {
	return battleNameLabel.get();
}

void BattleSprite::update(double deltaTime) {

	if (isReady) // waiting for action to be chosen
		return;

	currentActionBar += deltaTime;

	if (currentActionBar >= 100) {
		//chooseAction();
		isReady = true;
		currentActionBar = 0;
	}
	Sprite::update(deltaTime);
}

void BattleSprite::draw(SpriteBatch * batch) {

	Sprite::draw(batch);
	//battleNameLabel->draw(batch);
}

//void BattleSprite::fight() {
//}

