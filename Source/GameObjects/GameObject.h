#pragma once

#include <string>
#include <SimpleMath.h>

using namespace DirectX::SimpleMath;
using namespace std;

class GameObject {
public:
	GameObject();
	~GameObject();

	string name;
	int id = -1;
	/* ID of tile representing this object. */
	int gid = -1;
	/* Top-left coordinates of rect. */
	//int x, y;
	Vector2 position;
	int width, height;

	RECT rect;
	void setRect();

	void move(Vector2 moveAmount);
	void update(double deltaTime);

private:


};