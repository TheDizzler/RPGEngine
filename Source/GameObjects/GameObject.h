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
	Vector2 position;
	int width, height;


private:


};