#pragma once

#include <string>

using namespace std;


namespace GameVariables {

	static const enum EscapeStrings {
		hero, temp1, temp2
	};

	static wstring escapeStrings[3] = {L"hero", L"temp1", L"temp2"};
	static wstring storedVariables[3];


	static wstring getStoredVariable(wstring escape) {

		if (escape == escapeStrings[hero])
			return storedVariables[hero];
	}


	static void storeVariable(wstring escape, wstring store) {

		if (escape == escapeStrings[hero])
			storedVariables[hero].assign(store);
	}


};