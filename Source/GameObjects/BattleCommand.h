#pragma once

#include "GUIObjects\TextLabel.h"
//#include "BattleObjects\BattleSprite.h"

class BattleSprite;

class BattleCommand {
public:
	BattleCommand(string commandName, BattleSprite* character);
	/** Deprecated? */
	//BattleCommand(string commandName, FontSet* guiFont);
	~BattleCommand();

	void draw(SpriteBatch* batch);

	string command;
	/** Character associated with this command. */
	BattleSprite* character;
private:

	unique_ptr<TextLabel> commandLabel;

};