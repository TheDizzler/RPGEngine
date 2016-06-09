#pragma once


/* Global variables and includes */
#include <comdef.h>
#include <tchar.h>
#include <sstream>
#include <strsafe.h>

using namespace std;

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

	/** THIS WILL NOT WORK! Copy paste this code to where it's needed. */
	inline LPCWSTR convertStringToLPCWSTR(const string text) {

		int len;
		int slength = (int) text.length() + 1;
		len = MultiByteToWideChar(CP_ACP, 0, text.c_str(), slength, 0, 0);
		wchar_t* buf = new wchar_t[len];
		MultiByteToWideChar(CP_ACP, 0, text.c_str(), slength, buf, len);
		std::wstring r(buf);
		delete[] buf;
		return r.c_str();

	}


	inline wchar_t* convertCharStarToWCharT(const char* text) {

		const size_t cSize = strlen(text) + 1;
		wchar_t* wc = new wchar_t[cSize];
		mbstowcs(wc, text, cSize);

		return wc;
	}

	/** THIS WILL NOT WORK! Copy paste this code to where it's needed. */
	inline const wchar_t* convertStringToCWCT(string text) {

		wstring wstr = wstring(text.begin(), text.end());
		const wchar_t* text_t = wstr.c_str();
		return text_t;

	}


	inline bool reportError(HRESULT hr) {

		if (FAILED(hr)) {
			_com_error err(hr);
			MessageBox(NULL, err.ErrorMessage(), TEXT("This is SRS Error"), MB_OK | MB_ICONERROR);
			return true;
		}

		return false;
	}

};
