#pragma once

#include "CommandBox.h"
#include "../../GameScreens/Screen.h"
#include "../../globals.h"

class MenuTest : public Screen {
public:
	MenuTest();
	~MenuTest();

	// Inherited via Screen
	virtual bool initialize(ID3D11Device * device, TextBoxManager* textBoxManager) override;
	virtual void setGameManager(Game * game) override;
	virtual void update(double deltaTime, BYTE keyboardState[256], MouseController * mouse) override;
	virtual void draw(SpriteBatch * batch) override;

private:
	Game* game;
	
	TextBoxManager* textBoxManager;

	//unique_ptr<CommandBox> commandBox;
	//unique_ptr<TextBox> textBox;

	unique_ptr<TextLabel> testLabel;
};