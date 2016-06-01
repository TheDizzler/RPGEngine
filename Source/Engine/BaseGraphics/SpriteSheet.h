#pragma once

#include <map>
#include <string>
#include <wrl.h>


#include <SimpleMath.h>
#include "SpriteBatch.h"
#include <pugixml.hpp>

using namespace std;
using namespace DirectX;
using namespace DirectX::SimpleMath;
using namespace pugi;

class SpriteSheet {
public:
	struct SpriteFrame {
		RECT sourceRect;
		int gid = -1;
		XMFLOAT2 origin;
		Color tint = DirectX::Colors::White.v;
		Vector2 scale = Vector2(1, 1);
		float alpha = 1.0f;
		float rotation = 0.0f;
		float layerDepth = 0.0f;

		SpriteSheet* sheet;
	};

	bool load(ID3D11Device* device, pugi::xml_node tilesetNode);

	map<int, SpriteFrame*> spriteMap;

	string name;
	Microsoft::WRL::ComPtr<ID3D11ShaderResourceView> texture;
	
private:

	
	Microsoft::WRL::ComPtr<ID3D11Resource> resource;

	

	int firstGID = -1;

};