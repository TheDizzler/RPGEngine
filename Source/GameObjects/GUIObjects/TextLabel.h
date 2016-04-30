#pragma once

#include <tchar.h>
#include <sstream>
#include <strsafe.h>

#include "../../Engine/BaseGraphics/FontSet.h"

using namespace std;


class TextLabel {
public:
	TextLabel(Vector2 position, FontSet* font);
	TextLabel(Vector2 position, FontSet* font, wstring text);
	~TextLabel();

	void draw(SpriteBatch* batch);

	void setText(string text);
	void setText(wostringstream& text);
	const wchar_t* getText();
	
	Vector2 position;

private:

	wstring label;
	FontSet* font;
	
};

