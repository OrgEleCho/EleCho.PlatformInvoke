#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string>
#include <vector>
#include <iostream>

using namespace std;

struct StringWrapper
{
    wchar_t str[32];
};


extern "C" __declspec(dllexport) void char_next_w(char* str)
{
    printf("%s\n", str);
}

extern "C" __declspec(dllexport) void Check_DEVMODE(DEVMODEW * ptr)
{
    wprintf(L"DeviceName: %s", ptr->dmDeviceName);
    wprintf(L"FormName: %s", ptr->dmFormName);
    printf("Reserved2: %d", ptr->dmReserved2);
}

extern "C" __declspec(dllexport) void CheckStringWrapper(StringWrapper * ptr)
{
    printf("Pointer value: %p\n", ptr);
    printf("Str Pointer value: %p\n", ptr->str);
    wprintf(L"%s\n", ptr->str);
}




void test()
{
    ChildWindowFromPoint;
    ChildWindowFromPointEx;
    CWP_ALL;
    ClientToScreen;
    ClipCursor;
    CloseClipboard;
    CloseDesktop;
    DEVMODEW;
    DMDO_180;
    DMDFO_CENTER;
    MSG;
    DMDUP_SIMPLEX;
    DMTT_BITMAP;
    DM_INTERLACED;
    DMNUP_SYSTEM;
    ChangeDisplaySettingsW;

    DISP_CHANGE_SUCCESSFUL;
}
