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


class SpriteSheet {
public:
	struct SpriteFrame {
		RECT sourceRect;
		int gid = -1;
		//XMFLOAT2 size;
		XMFLOAT2 origin;
		Color tint;
		Vector2 scale = Vector2(0, 0);
		float alpha;
		float rotation = 0;
		float layerDepth;

		SpriteSheet* sheet;
	};

	bool load(ID3D11Device* device, pugi::xml_node tilesetNode);

	map<int, SpriteFrame*> spriteMap;

	string name;
	Microsoft::WRL::ComPtr<ID3D11ShaderResourceView> texture;
	//void draw(SpriteBatch* batch, int gid, Vector2 pos);
private:

	
	Microsoft::WRL::ComPtr<ID3D11Resource> resource;

	

	int firstGID = -1;

};