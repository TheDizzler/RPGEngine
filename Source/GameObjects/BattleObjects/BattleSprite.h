#pragma once

#include <vector>

#include "../../Engine/BaseGraphics/Sprite.h"
#include "../GUIObjects/TextLabel.h"
#include "../BattleCommand.h"


class BattleSprite : public Sprite {
public:
	BattleSprite(string name);
	~BattleSprite();

	TextLabel* setBattleLabel(TextLabel* label);
	TextLabel* getBattleLabel();



	virtual void update(double deltaTime) override;
	virtual void draw(SpriteBatch* batch) override;

	//virtual void fight();


	bool isReady = false;

	//vector<BattleCommand*> commands;
	BattleCommand* currentAction;

protected:

	int HP = 10;
	int str = 1;
	int def = 0;
	float speed; // rate action bar fills
	float currentActionBar = 0; // when action bar reaches 100(?) it's this actor's turn

	string battleName;
	unique_ptr<TextLabel> battleNameLabel;


	virtual void chooseAction() = 0;
};