#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string>
#include <vector>
#include <iostream>

using namespace std;

struct MyStruct
{
    char name[32];
    char description[128];
    int qwq;
};

extern "C" __declspec(dllexport) void print_info(MyStruct* pMyStruct)
{
    printf("%p\n", pMyStruct);
    printf("%p\n", pMyStruct->name);
    printf("%p\n", &pMyStruct);
    printf("%p\n", &(pMyStruct->name));

    printf("%s\n", pMyStruct->name);
    printf("%s\n", pMyStruct->description);

    pMyStruct->description[0] = 'X';
    pMyStruct->qwq += 514;
}

extern "C" __declspec(dllexport) int* plus1(int* pnum)
{
    (*pnum)++;
    return pnum;
}


void test()
{
    CreateCaret;
    CreateCursor;
    CreateDesktopA;
    DF_ALLOWOTHERACCOUNTHOOK;
    CreateDesktopW;
    CreateDesktopExW;
    CreateDialogIndirectParamA;
    CreateDialogParamA;
    CreateDialogParamA;
    LPARAM; WPARAM;
    ShowWindow;
}
