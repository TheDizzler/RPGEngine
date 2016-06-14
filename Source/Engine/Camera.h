#pragma once

#include <SimpleMath.h>

#include "SimpleKeyboard.h"
#include "../GameScreens/MapData/MAPFile.h"

using namespace DirectX;
using namespace DirectX::SimpleMath;

/** Based on https://roguesharp.wordpress.com/2014/07/13/tutorial-5-creating-a-2d-camera-with-pan-and-zoom-in-monogame/ */
class Camera {
public:
	Camera(int viewportWidth, int viewportHeight);
	~Camera();

	
	Viewport* viewport = NULL;
	Vector2 position;

	float rotation = 0.0f;

	int viewportWidth;
	int viewportHeight;
	Vector3 viewportCenter;


	void setMap(MAPFile* mapFile);
	void adjustZoom(float amount);
	/** Move the camera in an X and Y amount based on the cameraMovement param.
	*	If clampToMap is true the camera will try not to pan outside of the
	*	bounds of the map. */
	void moveCamera(Vector2 cameraMovement, bool clampToMap = true);
	

	RECT* viewportWorldBoundary();

	void centerOn(Vector2 pos, bool clampToMap = true);

	Matrix translationMatrix();
private:
	float zoom;
	float mapWidth;
	float mapHeight;

	float viewX = (viewportWidth / zoom / 2);
	float viewY = (viewportHeight / zoom / 2);

	MAPFile* map = NULL;


	void mapClampedPosition(Vector2& position);
	Vector2* screenToWorld(Vector2 screenPosition);

	
};