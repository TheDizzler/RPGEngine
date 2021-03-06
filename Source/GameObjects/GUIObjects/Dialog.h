#pragma once

#include <vector>


#include "../../Engine/BaseGraphics/Sprite.h"
#include "Button.h"


static enum DialogResult {
	NONE, CONFIRM, CANCEL_DIALOG
};


class Dialog : public Sprite {
public:
	Dialog(const Vector2& position);
	~Dialog();

	bool initialize(ID3D11Device* device, const wchar_t* fontFile);

	virtual void update(double deltaTime, MouseController* mouse);
	virtual void draw(SpriteBatch* batch);

	void open();
	void close();
	DialogResult getResult();

	bool isOpen = false;

private:

	unique_ptr<FontSet> font;
	vector<TextLabel*> labels;
	vector<Button*> buttons;

	
	DialogResult result = NONE;

};