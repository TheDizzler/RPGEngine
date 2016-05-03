#include "MenuTest.h"

MenuTest::MenuTest() {
}

MenuTest::~MenuTest() {
}

using namespace Globals;
//#include <sstream>

bool MenuTest::initialize(ID3D11Device * device, TextBoxManager* txtBxMng) {

	guiFont.reset(new FontSet());
	if (!guiFont->load(device, Assets::battleFontFile))
		return false;
	guiFont->setTint(DirectX::Colors::White.v);

	testLabel.reset(new TextLabel(Vector2(500, 500), guiFont.get(), L"Test")); 

	textBoxManager = txtBxMng;

	listBox.reset(new ListBox(TEXTBOX_MARGIN, TEXTBOX_MARGIN,
		LISTBOX_WIDTH + TEXTBOX_MARGIN, LISTBOX_HEIGHT + TEXTBOX_MARGIN, guiFont.get()));

	vector<xml_node> list = textBoxManager->getDialogList();
	vector<TextLabel*> labels;
	for (xml_node node : list) {
		wstring name;
		const char_t* ch_name = node.attribute("speaker").as_string();
		wstringstream wss;
		wss << ch_name;
		name = wss.str();
		labels.push_back(new TextLabel(Vector2(0, 0), guiFont.get(), name));
	}
	listBox->loadList(list, labels);
	

	//wstring test = L"This is a string in a text box with a longer String. There is a lot to write here but I don't have a lot to write boohoo hoo hoo hooh ooho ohoho. Testing tester tset ete sd these aren't whole words. More Strings to test. More. Things. Even more Text to fill in here. Wow such text. So long. Wow. Please help me to test this text box.";

	/*textBox.reset(new TextBox(WINDOW_HEIGHT - LISTBOX_HEIGHT, TEXTBOX_MARGIN,
		LISTBOX_WIDTH + TEXTBOX_MARGIN, WINDOW_HEIGHT, guiFont.get()));

	textBox->loadText(test);*/

	return true;
}

void MenuTest::setGameManager(Game* gm) {
	game = gm;
}

void MenuTest::update(double deltaTime, BYTE keyboardState[256], MouseController * mouse) {

	//textBox->update(deltaTime, keyboardState);
	listBox->update(deltaTime, keyboardState);
}

void MenuTest::draw(SpriteBatch * batch) {

	textBoxManager->draw(batch, listBox.get());
	//testLabel->draw(batch);
}

