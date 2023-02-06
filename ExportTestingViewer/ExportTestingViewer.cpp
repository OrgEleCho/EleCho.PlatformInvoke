#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string>
#include <vector>
#include <iostream>

using namespace std;

extern "C" __declspec(dllexport) int* plus1(int* pnum)
{
    (*pnum)++;
    return pnum;
}


void test()
{
    
}
