#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN 
#include <windows.h>
#include <stdio.h>
#include <stdarg.h>

void DisplayError(const char* Format,...);
const char* ConvertToHex(DWORD d);