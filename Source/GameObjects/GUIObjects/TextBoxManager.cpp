#include "TextBoxManager.h"

TextBoxManager::TextBoxManager() {

}

TextBoxManager::~TextBoxManager() {
}

bool TextBoxManager::load(ID3D11Device* device) {

	indicator.reset(new Sprite());
	if (!indicator->load(device, Assets::indicatorFile))
		return false;

	corner.reset(new Sprite());
	if (!corner->load(device, Assets::borderCornerFile))
		return false;

	side.reset(new Sprite());
	if (!side->load(device, Assets::borderSideFile))
		return false;

	bg.reset(new Sprite());
	if (!bg->load(device, Assets::blackFile))
		return false;


	return true;
}


void TextBoxManager::draw(SpriteBatch* batch, TextBox* textBox) {

	RECT* rect = &textBox->rect;
	int spriteHeight = bg->getSpriteHeight();
	int spriteWidth = bg->getSpriteWidth();

	int height = rect->bottom - rect->top;
	int length = rect->right - rect->left;

	// draw colored background
	for (int i = 0; i <= length; i += spriteWidth) {
		for (int j = 0; j < height; j += spriteHeight) {
			bg->setPosition(Vector2(rect->left + i, rect->top + j));
			bg->draw(batch);
		}
	}

// draw border
	corner->setPosition(Vector2(rect->left, rect->top));
	corner->setRotation(0);
	corner->draw(batch);

	corner->setPosition(Vector2(rect->right, rect->top));
	corner->setRotation(XM_PI / 2);
	corner->draw(batch);

	corner->setPosition(Vector2(rect->right, rect->bottom - spriteHeight));
	corner->setRotation(XM_PI);
	corner->draw(batch);

	corner->setPosition(Vector2(rect->left, rect->bottom - spriteHeight));
	corner->setRotation(-XM_PI / 2);
	corner->draw(batch);

	spriteWidth = corner->getSpriteWidth();
	length -= spriteWidth;
	spriteHeight = corner->getSpriteHeight();
	height -= spriteHeight;


	for (int i = spriteHeight; i < height; i += spriteHeight) {
		int pos = rect->top + i;
		side->setRotation(0);
		side->setPosition(Vector2(rect->left, pos));
		side->draw(batch);
		side->setRotation(XM_PI);
		side->setPosition(Vector2(rect->right, pos));
		side->draw(batch);
	}


	for (int i = spriteWidth; i <= length; i += spriteWidth) {
		int pos = rect->left + i;
		side->setRotation(XM_PI / 2);
		side->setPosition(Vector2(pos, rect->top));
		side->draw(batch);
		side->setRotation(-XM_PI / 2);
		side->setPosition(Vector2(pos, rect->bottom - spriteHeight));
		side->draw(batch);
	}

	// print labels
	textBox->drawText(batch);

	if (textBox->indicatorOn) {
		indicator->setPosition(textBox->indicatorPos);
		indicator->setRotation(textBox->indicatorRot);
		indicator->draw(batch);
	}
}
