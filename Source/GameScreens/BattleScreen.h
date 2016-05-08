#pragma once

#include <vector>

#include "../globals.h"
#include "Screen.h"
#include "../GameObjects/GUIObjects/TextBoxManager.h"
#include "../GameObjects/GUIObjects/CommandBox.h"
#include "../GameObjects/BattleObjects/Enemies/Enemy.h"
#include "../GameObjects/BattleObjects/BattleCharacter.h"

class BattleScreen : public Screen {
public:
	BattleScreen();
	~BattleScreen();

	// Inherited via Screen
	virtual bool initialize(ID3D11Device* device, TextBoxManager* textBoxManager) override;
	virtual void setGameManager(Game* game) override;
	//virtual void update(double deltaTime, BYTE keyboardState[256], MouseController * mouse) override;
	virtual void update(double deltaTime, SimpleKeyboard* keys) override;
	virtual void draw(SpriteBatch * batch) override;

private:

	Game* game;

	bool playerTurn;


	unique_ptr<FontSet> guiFont;

	int labelOffset = 20;
	Vector2 enemyLabelLocation = Vector2(25, 600);
	Vector2 characterLabelLocation = Vector2(225, 600);
	Vector2 battleCommandLocation = Vector2(225, 400);
	//vector<TextLabel*> enemyLabels;
	//vector<TextLabel*> characterLabels;
	//vector<TextLabel*> battleCommandLabels;


	Vector2 enemy1Position = Vector2(60, 60);
	Vector2 enemy2Position = Vector2(60, 220);
	Vector2 enemy3Position = Vector2(60, 360);
	//vector<Enemy*> enemies;

	Vector2 character1Pos = Vector2(400, 20);
	Vector2 character2Pos = Vector2(400, 180);
	Vector2 character3Pos = Vector2(400, 340);

	

	vector<BattleSprite*> actors;

	
	//unique_ptr<TextBoxFactory> textBoxFactory;
	//vector<RECT> textBoxes;

	TextBoxManager* textBoxManager;
	ListBox* enemyBox;
	ListBox* pcBox;
	CommandBox* currentCommandBox;
	vector<CommandBox*> commandBoxes;

};