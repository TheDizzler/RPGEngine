#pragma once

#include <string>
#include <vector>
#include <map>
#include "../globals.h"


using namespace std;

/** NOT USING THIS! (It didn't work :( ) */
namespace GameVariables {

	static const enum EscapeStrings {
		hero, temp1, temp2
	};

	static const wchar_t* heroStoredName = L"0123456789";
	static wstring escapeStrings[3] = {L"hero", L"temp1", L"temp2"};
	//static const wchar_t* storedVariables[3] = {heroStoredName, L"0123456789", L"0123456789"};

	namespace {
		map<wstring, wstring> storedVariables;
		wstring tempA = L"Temp 1!";
		wstring tempB = L"Temp 2!";
	}
	static wstring getStoredVariable(wstring escape) {

		MessageBox(0, storedVariables[escapeStrings[hero]].c_str(), escapeStrings[hero].c_str(), MB_OK);
		MessageBox(0, storedVariables[escapeStrings[temp1]].c_str(), escapeStrings[temp1].c_str(), MB_OK);
		MessageBox(0, storedVariables[escapeStrings[temp2]].c_str(), escapeStrings[temp2].c_str(), MB_OK);

		if (escape == escapeStrings[hero])
			return storedVariables[escape];
	}


	static void storeVariable(wstring escape, wstring* store) {

		//MessageBox(0, store->c_str(), escape.c_str(), MB_OK);
		if (escape == escapeStrings[hero])
			storedVariables[escape] = *store;

		
		storedVariables[escapeStrings[temp1]] = tempA;
		storedVariables[escapeStrings[temp2]] = tempB;
		MessageBox(0, storedVariables[escapeStrings[hero]].c_str(), escapeStrings[hero].c_str(), MB_OK);
		MessageBox(0, storedVariables[escapeStrings[temp1]].c_str(), escapeStrings[temp1].c_str(), MB_OK);
		MessageBox(0, storedVariables[escapeStrings[temp2]].c_str(), escapeStrings[temp2].c_str(), MB_OK);
	}



};