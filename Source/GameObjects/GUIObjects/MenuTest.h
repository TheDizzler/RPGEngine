#pragma once

#include "ListBox.h"
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
	unique_ptr<FontSet> guiFont;
	TextBoxManager* textBoxManager;

	unique_ptr<ListBox> listBox;
	unique_ptr<TextBox> textBox;

	unique_ptr<TextLabel> testLabel;
};