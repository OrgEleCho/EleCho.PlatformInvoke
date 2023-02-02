#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string>
#include <vector>
#include <iostream>

using namespace std;

extern "C" __declspec(dllexport) void char_next_w(char* str)
{
    printf("%s\n", str);
}

extern "C" __declspec(dllexport) void TestString(wchar_t* str)
{
    wprintf(L"%s\n", str);
}

extern "C" __declspec(dllexport) void Check_DEVMODE(DEVMODEW * ptr)
{
    wprintf(L"DeviceName: %s", ptr->dmDeviceName);
    wprintf(L"FormName: %s", ptr->dmFormName);
    printf("Reserved2: %d", ptr->dmReserved2);
}

extern "C" __declspec(dllexport) void TestGuid(GUID* ptr)
{
    printf("Pointer value: %p\n", ptr);
    printf("Data1: %d\n", ptr->Data1);
    printf("Data2: %d\n", ptr->Data2);
    printf("Data3: %d\n", ptr->Data3);
    printf("Data4: %d\n", ptr->Data4);
}

struct SomeIntegers
{
    union {
        int A;
        struct {
            short Higer;
            short Lower;
        };
    };
};

struct StringWrapper
{
    wchar_t* StrPtr;
    int Length;
};

extern "C" __declspec(dllexport) void print(StringWrapper * str)
{
    for (int i = 0; i < str->Length; i++) {
        putwchar(str->StrPtr[i]);
    }

    putwchar(L'\n');
}


void test()
{
    CopyIcon;
    CopyImage;
}
