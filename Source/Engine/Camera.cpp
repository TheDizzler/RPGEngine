#include "Camera.h"

Camera::Camera(int vwprtWdth, int vwprtHght/*, MAPFile* mapFile*/) {

	zoom = 1.0f;

	viewportWidth = vwprtWdth;
	viewportHeight = vwprtHght;
	viewportCenter = Vector3(viewportWidth * .5, viewportHeight * .5, 0);

	position = Vector2::Zero;

	//map = mapFile;
}

Camera::~Camera() {
}

//void Camera::update(double deltaTime, Vector2* pcMovement) {
//
//	Vector2 cameraMovement = Vector2::Zero;
//
//	
//}

void Camera::adjustZoom(float amount) {

	zoom += amount;
	if (zoom < 0.25f)
		zoom = 0.25f;
	else if (zoom > 2.5)
		zoom = 2.5;
}

void Camera::moveCamera(Vector2 cameraMovement, bool clampToMap) {

	Vector2 newPos = position + cameraMovement;

	if (clampToMap)
		mapClampedPosition(newPos);

	position = newPos;
}

RECT* Camera::viewportWorldBoundary() {

	Vector2* viewportCorner = screenToWorld(Vector2::Zero);
	Vector2* viewportBottomCorner =
		screenToWorld(Vector2(viewportWidth, viewportHeight));

	RECT* rect = new RECT{(int) viewportCorner->x, (int) viewportCorner->y,
		(int) (viewportBottomCorner->x - viewportCorner->x),
		(int) (viewportBottomCorner->y - viewportCorner->y)};

	delete viewportCorner;
	delete viewportBottomCorner;

	return rect;

}

void Camera::centerOn(Vector2 pos, bool clampToMap) {

	if (clampToMap)
		mapClampedPosition(pos);

	position = pos;
}

Vector2* Camera::screenToWorld(Vector2 screenPosition) {

	Vector2* vec = new Vector2();
	Vector2::Transform(screenPosition, translationMatrix().Invert(), *vec);

	return vec;
}



void Camera::mapClampedPosition(Vector2& position) {

	Vector2 cameraMax = Vector2(
		map->mapWidth * map->tileWidth - (viewportWidth / zoom / 2),
		map->mapHeight*map->tileHeight - (viewportHeight / zoom / 2));

	position.Clamp(cameraMax, Vector2(viewportWidth / zoom / 2, viewportHeight / zoom / 2));

}



Matrix Camera::translationMatrix() {
	// casting to int prevents filtering artifacts??
	return Matrix::CreateTranslation(-(int) position.x, -(int) position.y, 0)
		* Matrix::CreateRotationZ(rotation)
		* Matrix::CreateScale(zoom, zoom, 1)
		* Matrix::CreateTranslation(viewportCenter);
}
