#include "Sprite.h"
#include "DDSTextureLoader.h"
#include "../../globals.h"


Sprite::Sprite() {

	alpha = 1.0f;
	rotation = 0.0f;
	scale = Vector2(1, 1);
	tint = DirectX::Colors::White.v;
	layerDepth = 0.0f;
}

Sprite::Sprite(const Vector2& pos) {

	position = pos;
	alpha = 1.0f;
	rotation = 0.0f;
	scale = Vector2(1, 1);
	tint = DirectX::Colors::White.v;
	layerDepth = 0.0f;

}

Sprite::~Sprite() {

	if (texture)
		texture->Release();
	if (resource)
		resource->Release();
}


bool Sprite::load(ID3D11Device* device, const wchar_t* textureFile) {


	if (Globals::reportError(CreateDDSTextureFromFile(device, textureFile, &resource, &texture))) {
		//MessageBox(NULL, L"Failed to load sprite", L"ERROR", MB_OK);
		return false;
	}

	Assets::getTextureDimensions(resource, &width, &height);
	origin = Vector2(width / 2.0f, height / 2.0f);
	sourceRect.left = 0;
	sourceRect.top = 0;
	sourceRect.bottom = height;
	sourceRect.right = width;

	hitArea = new HitArea(Vector2(position.x - width / 2, position.y - height / 2),
		Vector2(width, height));


	return true;
}



void Sprite::draw(SpriteBatch* batch) {

	batch->Draw(texture, position, &sourceRect, tint, rotation, origin, scale, SpriteEffects_None, layerDepth);

}


void Sprite::update(double deltaTime) {

	hitArea->position = Vector2(position.x - width / 2, position.y - height / 2);


}


const HitArea* Sprite::getHitArea() const {
	return hitArea;
}

const Vector2& Sprite::getPosition() const {

	return position;
}


const Vector2& Sprite::getOrigin() const {

	return origin;
}

const Vector2& Sprite::getScale() const {

	return scale;
}

const float Sprite::getRotation() const {
	return rotation;
}


const Color& Sprite::getTint() const {

	return tint;
}


const float Sprite::getAlpha() const {

	return alpha;
}

const RECT Sprite::getRect() const {
	return sourceRect;
}

UINT Sprite::getSpriteWidth() const {
	return width;
}

UINT Sprite::getSpriteHeight() const {
	return height;
}


//void Sprite::setHitArea(const HitArea* hitarea) {
//
//	hitArea = new HitArea(Vector2(position.x - width / 2, position.y - height / 2),
//		Vector2(hitarea->size.x - 2, hitarea->size.y - 2));
//}

void Sprite::setDimensions(Sprite* baseSprite) {

	width = baseSprite->width;
	height = baseSprite->height;

	hitArea = new HitArea(
		Vector2(position.x - width*scale.x / 2, position.y - height*scale.y / 2),
		Vector2(width*scale.x, height*scale.y));
}

void Sprite::setPosition(const Vector2& pos) {

	position = pos;
	hitArea->position = Vector2(position.x - width*scale.x / 2,
		position.y - height*scale.y / 2);
	hitArea->size = Vector2(width*scale.x, height*scale.y);
}


void Sprite::setOrigin(const Vector2& orgn) {

	origin = orgn;
}


void Sprite::setScale(const Vector2& scl) {

	scale = scl;
	setPosition(position);
}


void Sprite::setRotation(const float rot) {

	rotation = rot;
}


void Sprite::setTint(const Color& colr) {

	tint = colr;
}


void Sprite::setAlpha(const float alph) {

	alpha = alph;
}


