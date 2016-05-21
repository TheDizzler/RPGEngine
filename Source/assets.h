#pragma once


/* Global variables and includes */
#include <comdef.h>


namespace Assets {

	const static wchar_t* arialFontFile = L"assets/fonts/Arial.spritefont";
	const static wchar_t* battleFontFile = L"assets/fonts/Arial.spritefont";

	const static wchar_t* mouseSprite = L"assets/gfx/mouse icon.dds";
	const static wchar_t* buttonUpFile = L"assets/gfx/button up (256x64).dds";
	const static wchar_t* buttonDownFile = L"assets/gfx/button down (256x64).dds";

	const static wchar_t* indicatorFile = L"assets/gfx/gui/indicator.dds";
	const static wchar_t* borderCornerFile = L"assets/gfx/gui/border corner (16x16).dds";
	const static wchar_t* borderSideFile = L"assets/gfx/gui/border side (16x16).dds";
	const static wchar_t* blackFile = L"assets/gfx/gui/black (16x16).dds";

	const static wchar_t* blueDudeFile = L"assets/gfx/bluedude.dds";
	const static wchar_t* beetleFile = L"assets/gfx/baddies/beetle.dds";

	const static wchar_t* grassFile = L"assets/gfx/terrain/grass.dds";

	const static char* gameTextFile = "assets/text/GameText.xml";

	/*const static Vector2 aSize(121, 98);
	const static Vector2 aPos(118, 347);
	const static Vector2 bSize(87, 90);
	const static Vector2 bPos(30, 449);
	const static Vector2 cSize(133, 243);
	const static Vector2 cPos(303, 360);
	const static Vector2 dSize(97, 116);
	const static Vector2 dPos(212, 610);
	const static Vector2 eSize(131, 136);
	const static Vector2 ePos(87, 535);
	const static Vector2 fSize(146, 37);
	const static Vector2 fPos(298, 714);

	const static Vector2 gSize(26, 25);
	const static Vector2 gPos(101, 438);
	const static Vector2 hSize(26, 26);
	const static Vector2 hPos(289, 594);
	const static Vector2 iSize(310, 138);
	const static Vector2 iPos(151, 837);*/


	static void getTextureDimensions(ID3D11Resource* res, UINT* width, UINT* height) {

		D3D11_RESOURCE_DIMENSION dim;
		res->GetType(&dim);

		switch (dim) {
			case D3D11_RESOURCE_DIMENSION_TEXTURE2D:
			{

				auto texture = reinterpret_cast<ID3D11Texture2D*>(res);
				D3D11_TEXTURE2D_DESC desc;
				texture->GetDesc(&desc);
				if (width)
					*width = desc.Width; // width in pixels
				if (height)
					*height = desc.Height; // height in pixels

				break;

			}
			default:

				if (width)
					*width = 0; // width in pixels
				if (height)
					*height = 0; // height in pixels


		}
	}

};
