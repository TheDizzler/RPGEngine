#pragma once

#include "BattleSprite.h"

enum BattleCommands {Fight, Magic, Item, Run};


class BattleCharacter : public BattleSprite {
public:
	BattleCharacter(string name);
	~BattleCharacter();


private:

	virtual void chooseAction();
};