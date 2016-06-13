#include "GameEngine.h"


GameEngine::GameEngine() {

}


GameEngine::~GameEngine() {


}


bool GameEngine::initEngine(HWND hw, HINSTANCE hInstance) {

	hwnd = hw;

	if (!initD3D(hwnd)) {
		MessageBox(0, L"Direct3D Initialization Failed", L"Error", MB_OK);
		return false;
	}

	/*if (!initDirectInput(hInstance, hwnd)) {
		MessageBox(0, L"Input Init failed", L"Error", MB_OK);
		return false;
	}*/

	if (!initRawInput(hwnd)) {
		MessageBox(0, L"Raw Input Init failed", L"Error", MB_OK);
		return false;
	}
	

	if (!initStage()) {
		MessageBox(0, L"Stage Initialization Failed", L"Error", MB_OK);
		return false;
	}

	SetCursorPos(200, 200);

	return true;
}

bool GameEngine::initStage() {


	game.reset(new Game(this));
	if (!game->initializeGame(device, mouse.get()))
		return false;


	return true;
}






void GameEngine::run(double deltaTime, int fps) {

	//detectInput(deltaTime);


	//if (GetKeyState(VK_ESCAPE) & 0x8000)
		//exit();

	update(deltaTime);
	render(deltaTime);

}


void GameEngine::detectInput(double deltaTime) {



/* This is DirectInput junk! Deprecated!!
	inputKB->Acquire();
	inputMouse->Acquire();
	//inputMouse->GetDeviceState(sizeof(DIMOUSESTATE), (LPVOID) &mouse->setCurrentState());
	inputKB->GetDeviceState(sizeof(keyboardState), (LPVOID) &keyboardState);
	*/



	//POINT cursorPos;
	//GetCursorPos(&cursorPos);

	//mouse->setPosition(Vector2(cursorPos.x, cursorPos.y));
}


void GameEngine::update(double deltaTime) {

	if (keys->keyDown[ESC])
		exit();

	game->update(deltaTime, keys);
}

float xScale = 2.2;
float yScale = 2.2;
XMMATRIX zoomMatrix = {xScale, 0, 0, 0, 0, yScale, 0, 0, 0, 0, 1, 0, -1, 1, 0, 1};
XMMATRIX matrix = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, -1, 1, 0, 1};

void GameEngine::render(double deltaTime) {


	deviceContext->ClearRenderTargetView(renderTargetView, Colors::BlueViolet);


	//batch->SetViewport(viewports[0]);
	deviceContext->RSSetViewports(1, vp.Get11());
	batch->Begin(SpriteSortMode_Deferred, NULL, NULL, NULL, NULL, NULL, zoomMatrix);
	{
		game->draw(batch.get());

		//batch->SetViewport(viewports[1]);
		//game->drawTextBoxes(batch.get());
		//mouse->draw(batch.get());
	}
	batch->End();

	deviceContext->RSSetViewports(1, vpDialog.Get11());
	//batchDialog->SetViewport(viewports[1]);
	batchDialog->Begin(SpriteSortMode_Deferred);
	{
		game->drawTextBoxes(batchDialog.get());

	}
	batchDialog->End();


	swapChain->Present(0, 0);
}

void GameEngine::exit() {

	if (MessageBox(0, L"Are you sure you want to exit?",
		L"Really?", MB_YESNO | MB_ICONQUESTION) == IDYES)
		DestroyWindow(hwnd);
}

