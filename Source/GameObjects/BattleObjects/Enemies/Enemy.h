#pragma once

#include "../BattleSprite.h"


class Enemy : public BattleSprite {
public:
	Enemy(string name);
	~Enemy();

	
private:

	virtual void chooseAction();

};