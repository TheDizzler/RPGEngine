#include "TextBoxManager.h"

using namespace Globals;

TextBoxManager::TextBoxManager(pugi::xml_document* doc) {

	//gameTextRootNode = rootNode;
	xmlDoc = doc;
	rootNode = xmlDoc->child("root");



}

TextBoxManager::~TextBoxManager() {

	/*for (int i = textBoxes.size() - 1; i >= 0; --i) {

		delete textBoxes[i];
	}*/

}

bool TextBoxManager::load(ID3D11Device* device) {


	guiFont.reset(new FontSet());
	if (!guiFont->load(device, Assets::battleFontFile))
		return false;
	guiFont->setTint(DirectX::Colors::White.v);

	dialogBox.reset(new TextBox(WINDOW_HEIGHT - DIALOGBOX_HEIGHT, TEXTBOX_MARGIN,
		DIALOGBOX_WIDTH + TEXTBOX_MARGIN, WINDOW_HEIGHT, guiFont.get()));

	commandBox.reset(new CommandBox(TEXTBOX_MARGIN, WINDOW_WIDTH - (LISTBOX_WIDTH + TEXTBOX_MARGIN),
		WINDOW_WIDTH - TEXTBOX_MARGIN, LISTBOX_HEIGHT + TEXTBOX_MARGIN, guiFont.get()));

	alphaBox.reset(new AlphaInputBox(TEXTBOX_MARGIN, TEXTBOX_MARGIN, guiFont.get()));

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


void TextBoxManager::update(double deltaTime, SimpleKeyboard* keys) {

	if (currentBox && currentBox->update(deltaTime, keys)) {

		if (currentBox->isQuery()) // close box
			textBoxes.pop_back();

		if (currentBox->isAlphaInput()) {
			wstring  userInput = ((AlphaInputBox*) currentBox)->getUserInput();
			textBoxes.pop_back();
		}


		xml_node nextNode = currentBox->getSelectedNode();

		const char_t* type = nextNode.name();
		string type_s = type;
		//string node_type_s = nodeTypes[0];
		/*wstringstream wss;
		wss << type;
		MessageBox(0,  wss.str().c_str(), L"Hi", MB_OK);*/

		if (!nextNode) {
			// Dialog done?
			textBoxes.pop_back();
			if (!textBoxes.empty())
				currentBox = textBoxes.back();
			else
				currentBox = NULL;

		} else if (type_s == nodeTypes[DIALOG_TEXT]) {

			dialogBox->loadNode(nextNode);
			currentBox = dialogBox.get();

		} else if (nodeTypes[QUERY] == type_s) {

			vector<xml_node> nodes;
			for (xml_node child = nextNode.child("answer"); child; child = child.next_sibling("answer"))
				nodes.push_back(child);

			commandBox->loadNodes(nextNode, nodes);
			textBoxes.push_back(commandBox.get());
			currentBox = commandBox.get();

		} else if (nodeTypes[ALPHA_INPUT]) {

			alphaBox->loadNode(nextNode);
			textBoxes.push_back(alphaBox.get());
			currentBox = alphaBox.get();
		}
	}
}



void TextBoxManager::draw(SpriteBatch* batch) {

	for (TextBox* textBox : textBoxes) {
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
}



void TextBoxManager::startDialogTest() {


	dialogBox->loadNode(rootNode.find_child_by_attribute("speaker", "Name Input").child("dialogText"));

	currentBox = dialogBox.get();
	textBoxes.push_back(currentBox);
}

