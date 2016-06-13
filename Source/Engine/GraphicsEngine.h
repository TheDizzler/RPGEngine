#pragma once
#pragma comment (lib, "D3D11.lib")

#include <Windows.h>
#include <memory>
#include <SimpleMath.h>

#include "SpriteBatch.h"
#include "Camera.h"
#include "../globals.h"


using namespace DirectX;
using namespace DirectX::SimpleMath;


class GraphicsEngine {
public:
	GraphicsEngine();
	~GraphicsEngine();

	bool initD3D(HWND hwnd);


	virtual void render(double time) = 0;

	std::unique_ptr<Camera> camera;
protected:

	std::unique_ptr<SpriteBatch> batch;
	std::unique_ptr<SpriteBatch> batchDialog;
	/* Changes backbuffer to front buffer. */
	IDXGISwapChain* swapChain = 0;
	/* GPU object */
	ID3D11Device* device = 0;
	/* GPU interface */
	ID3D11DeviceContext* deviceContext;
	/* The backbuffer that gets drawn to. */
	ID3D11RenderTargetView* renderTargetView = 0;

	D3D_DRIVER_TYPE driverType;
	D3D_FEATURE_LEVEL featureLevel;
	//D3D11_VIEWPORT viewports[2];

	Viewport vp;
	Viewport vpDialog;
	

};

