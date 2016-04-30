#include "BattleCommand.h"

BattleCommand::BattleCommand(string commandName, BattleSprite* chara) {

	command = commandName;
	character = chara;
}

//BattleCommand::BattleCommand(string commandName, FontSet* guiFont) {
//
//	commandLabel.reset(new TextLabel(Vector2(0, 0), guiFont));
//	commandLabel->setText(commandName);
//}

BattleCommand::~BattleCommand() {
}

void BattleCommand::draw(SpriteBatch * batch) {

	commandLabel->draw(batch);
}
