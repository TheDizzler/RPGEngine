#pragma once


/* Global variables and includes */
#include <comdef.h>


namespace Globals {

	const int WINDOW_WIDTH = 1000;	// in pixels
	const int WINDOW_HEIGHT = 800;	// in pixels

	const int TEXTBOX_MARGIN = 32;
	const int LISTBOX_WIDTH = 384; // in pixels
	const int LISTBOX_HEIGHT = 252; // in pixels



	inline bool reportError(HRESULT hr) {

		if (FAILED(hr)) {
			_com_error err(hr);
			MessageBox(NULL, err.ErrorMessage(), TEXT("This is SRS Error"), MB_OK | MB_ICONERROR);
			return true;
		}

		return false;
	}

};
