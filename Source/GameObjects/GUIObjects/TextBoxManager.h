#pragma once

//#include <PrimitiveBatch.h>
#include <VertexTypes.h>

//#include "../../Engine/BaseGraphics/Sprite.h"
#include "TextBox.h"


using namespace std;

class TextBoxManager {
public:
	TextBoxManager();
	~TextBoxManager();

	bool load(ID3D11Device* device);

	/** RECT should be a multiple of border sprite length/height
		(currently 16x16). */
	void draw(SpriteBatch* batch, TextBox* textBox);

private:

	unique_ptr<Sprite> indicator;
	unique_ptr<Sprite> corner;
	unique_ptr<Sprite> side;
	unique_ptr<Sprite> bg;
};