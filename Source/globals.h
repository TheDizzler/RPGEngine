#pragma once


/* Global variables and includes */
#include <comdef.h>



namespace Globals {

	const int WINDOW_WIDTH = 1000;	// in pixels
	const int WINDOW_HEIGHT = 800;	// in pixels

	const int TEXTBOX_MARGIN = 32;
	const int LISTBOX_WIDTH = 384; // in pixels
	const int LISTBOX_HEIGHT = 252; // in pixels

	const int DIALOGBOX_WIDTH = 768; // in pixels
	const int DIALOGBOX_HEIGHT = 252;

	const int ALPHA_INPUT_WIDTH = 480;
	const int ALPHA_INPUT_HEIGHT = 126;

	const float LETTER_DELAY = 0.025;
	const float LETTER_DELAY_FAST = .000001;

	static const int MAX_CHARACTERS = 10;
	

	inline bool reportError(HRESULT hr) {

		if (FAILED(hr)) {
			_com_error err(hr);
			MessageBox(NULL, err.ErrorMessage(), TEXT("This is SRS Error"), MB_OK | MB_ICONERROR);
			return true;
		}

		return false;
	}

};
