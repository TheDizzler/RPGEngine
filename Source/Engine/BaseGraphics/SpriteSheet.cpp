#include "SpriteSheet.h"


#include "../../assets.h"
#include "../../globals.h"
#include "DDSTextureLoader.h"

bool SpriteSheet::load(ID3D11Device* device, pugi::xml_node tilesetNode) {

	string source = tilesetNode.first_child().attribute("source").as_string();

	const wchar_t* spriteSheetFile =
		Globals::convertCharStarToWCharT(
			tilesetNode.first_child().attribute("source").as_string());


	if (Globals::reportError(CreateDDSTextureFromFile(device, spriteSheetFile,
		resource.GetAddressOf(), texture.GetAddressOf()))) {
		MessageBox(0, Globals::convertCharStarToWCharT(
			tilesetNode.first_child().attribute("source").as_string()),
			L"Error loading sprite sheet", MB_OK);
		return false;
	}

	//Assets::getTextureDimensions(resource.Get(), &width, &height);
	//

	firstGID = tilesetNode.attribute("firstgid").as_int();
	name = tilesetNode.attribute("name").as_string();

	const int tilewidth = tilesetNode.attribute("tilewidth").as_int();
	const int tileheight = tilesetNode.attribute("tileheight").as_int();
	const int columns = tilesetNode.attribute("columns").as_int();

	const int rows = tilesetNode.attribute("tilecount").as_int() / columns;

	for (int h = 0; h < rows; ++h) {
		for (int w = 0; w < columns; ++w) {

			SpriteFrame* frame = new SpriteFrame();
			frame->sourceRect = {w * tilewidth, h * tileheight,
									w * tilewidth + tilewidth,
									h * tileheight + tileheight};
			// gameobjects seem to be drawn from bottom left
			// but tiles are drawn from top left
			frame->origin = Vector2(0, 0);
			frame->gid = firstGID;
			frame->sheet = this;
			spriteMap[firstGID++] = frame;
		}
	}
	return true;
}
