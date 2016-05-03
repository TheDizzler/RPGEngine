#pragma once


//#include <libxml/parser.h>
//#include <libxml/tree.h>

#include "pugixml.hpp"

#include "TextBox.h"


using namespace std;
using namespace pugi;

class TextBoxManager {
public:
	TextBoxManager(xml_document* xmlDoc);
	~TextBoxManager();

	bool load(ID3D11Device* device);

	/** RECT should be a multiple of border sprite length/height
		(currently 16x16). */
	void draw(SpriteBatch* batch, TextBox* textBox);


	vector<xml_node> getDialogList();
private:


	xml_document* xmlDoc;
	xml_node rootNode;

	unique_ptr<Sprite> indicator;
	unique_ptr<Sprite> corner;
	unique_ptr<Sprite> side;
	unique_ptr<Sprite> bg;

	
};