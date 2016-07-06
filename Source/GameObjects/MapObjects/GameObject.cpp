#include "GameObject.h"

GameObject::GameObject() {
}

GameObject::~GameObject() {
}

void GameObject::setName(string name) {

	name_string = name;

	int len;
	int slength = (int) name.length() + 1;
	len = MultiByteToWideChar(CP_ACP, 0, name.c_str(), slength, 0, 0);
	wchar_t* buf = new wchar_t[len];
	MultiByteToWideChar(CP_ACP, 0, name.c_str(), slength, buf, len);
	name_wstring = wstring(buf);
	delete[] buf;


}

void GameObject::setRect() {

	rect = {(long) position.x, (long) position.y,
		(long) position.x + width, (long) position.y + height};
}

void GameObject::move(Vector2 moveAmount) {

	/*x += moveAmount.x;
	y += moveAmount.y;
	rect = {x, y, x + width, y + height};*/
	position += moveAmount;
	rect = {(long) position.x, (long) position.y,
		(long) position.x + width, (long) position.y + height};
}

void GameObject::update(double deltaTime) {

}
