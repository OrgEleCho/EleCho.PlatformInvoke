using System.Runtime.InteropServices;
using System.Text;

namespace EleCho.PlatformInvoke.Windows;

public unsafe class NativeMethods
{
    #region ActiveKeyboardLayout
    [DllImport("user32.dll", EntryPoint = "ActivateKeyboardLayout",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static KeyboardLayout ActivateKeyboardLayout([In] KeyboardLayout hkl, [In] KeyboardLayoutFlag flags);
    #endregion

    #region AddClipboardFormatListener
    [DllImport("user32.dll", EntryPoint = "AddClipboardFormatListener",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AddClipboardFormatListener([In, NativeType("HWND")] nint hwnd);
    #endregion

    #region AdjustWindowRect
    [DllImport("user32.dll", EntryPoint = "AdjustWindowRect",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AdjustWindowRect([In, Out] ref Rect rect, [In] WindowStyle dwStyle, [In] bool bMenu);
    #endregion

    #region AdjustWindowRectEx
    [DllImport("user32.dll", EntryPoint = "AdjustWindowRectEx",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AdjustWindowRectEx([In, Out] ref Rect rect, [In] WindowStyle dwStyle, [In] bool bMenu, [In] WindowStyleExtened dwExStyle);
    #endregion

    #region AdjustWindowRectExForDpi
    [DllImport("user32.dll", EntryPoint = "AdjustWindowRectExForDpi",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AdjustWindowRectExForDpi([In, Out] ref Rect rect, [In] WindowStyle dwStyle, [In] bool bMenu, [In] WindowStyleExtened dwExStyle, [In] uint dpi);
    #endregion

    #region AllowSetForegroundWindow
    [DllImport("user32.dll", EntryPoint = "AllowSetForegroundWindow",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AllowSetForegroundWindow([In] uint dwProcessId);
    #endregion

    #region AnimateWindow
    [DllImport("user32.dll", EntryPoint = "AnimateWindow",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AnimateWindow([In, NativeType("HWND")] nint hwnd, [In] uint time, [In] AnimateWindowFlag flags);
    #endregion

    #region AnyPopup
    [DllImport("user32.dll", EntryPoint = "AnyPopup",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AnyPopup();
    #endregion

    #region AnyPopup
    [DllImport("user32.dll", EntryPoint = "AppendMenuW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    private static extern bool AppendMenu([In] nint hMenu, [In] MenuFlag uFlags, [In] nuint uIDNewItem, [In, Optional] string? lpNewItem);

    [DllImport("user32.dll", EntryPoint = "AppendMenuW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    private static extern bool AppendMenu([In] nint hMenu, [In] MenuFlag uFlags, [In] nuint uIDNewItem, [In, Optional] char* lpNewItem);
    #endregion

    #region AreDpiAwarenessContextsEqual
    [DllImport("user32.dll", EntryPoint = "AreDpiAwarenessContextsEqual",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool AreDpiAwarenessContextsEqual([In, NativeType("DPI_AWARENESS_CONTEXT")] nint dpiContextA, [In, NativeType("DPI_AWARENESS_CONTEXT")] nint dpiContextB);
    #endregion

    #region ArrangeIconicWindows
    [DllImport("user32.dll", EntryPoint = "ArrangeIconicWindows",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    private extern static uint ArrangeIconicWindows([In, NativeType("HWND")] nint hWnd);
    #endregion

    #region AttachThreadInput
    [DllImport("user32.dll", EntryPoint = "AttachThreadInput",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool AttachThreadInput([In] uint idAttach, [In] uint idAttachTo, [In] bool fAttach);
    #endregion

    #region BeginDeferWindowPos
    [DllImport("user32.dll", EntryPoint = "BeginDeferWindowPos",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    [return: NativeType("HDWP")]
    public extern static nint BeginDeferWindowPos([In] int nNumWindows);
    #endregion

    #region BeginPaint

    [DllImport("user32.dll", EntryPoint = "BeginPaint",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    [return: NativeType("HDC")]
    public extern static nint BeginPaint([In, NativeType("HWND")] nint hWnd, [Out] out PaintStruct paint);
    #endregion

    #region BlockInput
    [DllImport("user32.dll", EntryPoint = "BlockInput",
               ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = false)]
    public extern static bool BlockInput(bool fBlockIt);
    #endregion

    #region BringWindowToTop
    [DllImport("user32.dll", EntryPoint = "BringWindowToTop",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public static extern bool BringWindowToTop([In, NativeType("HWND")] nint hWnd);
    #endregion

    #region BroadcastSystemMessage
    [DllImport("user32.dll", EntryPoint = "BroadcastSystemMessageW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public static extern int BroadcastSystemMessage([In] BroadcastSystemMessageFlag flags, [In, Out, Optional] ref BradcastSystemMessageRecipient lpInfo, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    [DllImport("user32.dll", EntryPoint = "BroadcastSystemMessageExW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public static extern int BroadcastSystemMessageEx([In] BroadcastSystemMessageFlag flags, [In, Out, Optional] ref BradcastSystemMessageRecipient lpInfo, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam, [Out, Optional] out BsmInfo bsmInfo);
    #endregion

    #region CalculatePopupWindowPosition
    [DllImport("user32.dll", EntryPoint = "CalculatePopupWindowPosition",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CalculatePopupWindowPosition([In] ref Point anchorPoint, [In] ref Size windowSize, [In] TrackPopupMenuFlag flags, [In, Optional] ref Rect excludeRect, [Out] out Rect popupWindowPosition);
    #endregion

    #region CallMsgFilter
    [DllImport("user32.dll", EntryPoint = "CallMsgFilterW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static bool CallMsgFilter([In] ref Message msg, [In] int nCode);
    #endregion

    #region CallNextHook
    [DllImport("user32.dll", EntryPoint = "CallNextHookEx",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    [return: NativeType("LRESULT")]
    public extern static nint CallNextHookEx([In, Optional, NativeType("HHOOK")] nint hhk, [In] int nCode, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    #endregion

    #region CallWindowProc
    [DllImport("user32.dll", EntryPoint = "CallWindowProcW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    [return: NativeType("LRESULT")]
    public extern static nint CallWindowProc([In] WndProc lpPrevWndProc, [In, NativeType("HWND")] nint hWnd, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    [DllImport("user32.dll", EntryPoint = "CallWindowProcW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    [return: NativeType("LRESULT")]
    public extern static nint CallWindowProc([In] nint lpPrevWndProc, [In, NativeType("HWND")] nint hWnd, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    #endregion

    #region CancelShutdown
    [DllImport("user32.dll", EntryPoint = "CancelShutdown",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CancelShutdown();
    #endregion

    #region CascadeWindows
    [DllImport("user32.dll", EntryPoint = "CascadeWindows",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static ushort CascadeWindows([In, Optional, NativeType("HWND")] nint hwndParent, [In] uint wHow, [In, Optional] ref Rect rect, [In] uint cKids, [In, Optional, NativeType("HWND")] nint lpKids);
    #endregion

    #region ChangeClipboardChain
    [DllImport("user32.dll", EntryPoint = "ChangeClipboardChain",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool ChangeClipboardChain([In, NativeType("HWND")] nint hWndRemove, [In, NativeType("HWND")] nint hWndNewNext);
    #endregion

    #region ChangeDisplaySettings
    [DllImport("user32.dll", EntryPoint = "ChangeDisplaySettingsW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static DisplayChangeResult ChangeDisplaySettings([In, Optional] ref DeviceMode devMode);

    [DllImport("user32.dll", EntryPoint = "ChangeDisplaySettingsExW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static DisplayChangeResult ChangeDisplaySettings([In, Optional] string? deviceName, [In, Optional] ref DeviceMode devMode, [Reserved, NativeType("HWND")] nint hwnd, [In] ChangeDisplaySettingsFlag dwFlags, [In, Optional] ref VideoParameters lParam);

    [DllImport("user32.dll", EntryPoint = "ChangeDisplaySettingsExW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static DisplayChangeResult ChangeDisplaySettings([In, Optional] char* lpszDeviceName, [In, Optional] ref DeviceMode devMode, [Reserved, NativeType("HWND")] nint hwnd, [In] ChangeDisplaySettingsFlag dwFlags, [In, Optional] ref VideoParameters lParam);
    #endregion

    #region ChangeMenu
    [DllImport("user32.dll", EntryPoint = "ChangeMenuW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static bool ChangeMenu([In, NativeType("HMENU")] nint hMenu, [In] uint cmd, [In, Optional] string? szNewItem, [In] uint cmdInsert, [In] uint flags);
    #endregion

    #region ChangeWindowMessageFilter
    [DllImport("user32.dll", EntryPoint = "ChangeWindowMessageFilter",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool ChangeWindowMessageFilter([In] uint message, [In] MessageFilterFlag dwFlag);


    [DllImport("user32.dll", EntryPoint = "ChangeWindowMessageFilterEx",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool ChangeWindowMessageFilterEx([In, NativeType("HWND")] nint hwnd, [In] uint message, MessageFilterFlag action, [In, Out, Optional] ref ChangeFilterStruct changeFilterStruct);
    #endregion

    #region CharLower
    [DllImport("user32.dll", EntryPoint = "CharLowerW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CharLower([In, Out] StringBuilder str);
    [DllImport("user32.dll", EntryPoint = "CharLowerW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CharLower([In, Out] char* str);
    #endregion

    #region CharLowerBuff
    [DllImport("user32.dll", EntryPoint = "CharLowerBuffW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static uint CharLowerBuff([In, Out] StringBuilder str, [In] uint cchLength);
    [DllImport("user32.dll", EntryPoint = "CharLowerBuffW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static uint CharLowerBuff([In, Out] char* str, [In] uint cchLength);
    #endregion

    #region CharNext
    /// <summary>
    /// 返回指定字符的下一个字符的指针. (没啥用, 就是指针值 + 2, 外加判断是否是 \0 字符)
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [DllImport("user32.dll", EntryPoint = "CharNextW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static char* CharNext([In] char* str);
    #endregion

    #region CharPrev
    [DllImport("user32.dll", EntryPoint = "CharPrevW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static char* CharPrevW([In] char* lpszStart, [In] char* lpszCurrent);
    #endregion

    #region CharToOem
    [DllImport("user32.dll", EntryPoint = "CharToOemW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static bool CharToOem([In] string str, [Out] byte* pDst);

    [DllImport("user32.dll", EntryPoint = "CharToOemW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static bool CharToOem([In] char* pStr, [Out] byte* pDst);
    #endregion

    #region CharToOemBuff
    [DllImport("user32.dll", EntryPoint = "CharToOemBuffW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static bool CharToOemBuff([In] string src, [Out] byte* lpszDst, [In] uint cchDstLength);

    [DllImport("user32.dll", EntryPoint = "CharToOemBuffW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static bool CharToOemBuff([In] char* src, [Out] byte* lpszDst, [In] uint cchDstLength);
    #endregion

    #region CharUpper
    [DllImport("user32.dll", EntryPoint = "CharUpperW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static char* CharUpper([In, Out] StringBuilder lpsz);

    [DllImport("user32.dll", EntryPoint = "CharUpperW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static char* CharUpper([In, Out] char* lpsz);
    #endregion

    #region CharUpperBuff
    [DllImport("user32.dll", EntryPoint = "CharUpperBuffW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static uint CharUpperBuff([In, Out] StringBuilder lpsz, [In] uint cchLength);

    [DllImport("user32.dll", EntryPoint = "CharUpperBuffW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static uint CharUpperBuff([In, Out] char* lpsz, [In] uint cchLength);
    #endregion

    #region CheckDlgButton
    [DllImport("user32.dll", EntryPoint = "CheckDlgButton",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CheckDlgButton([In, NativeType("HWND")] nint hDlg, [In] int nIDButton, [In] ButtonState uCheck);
    #endregion

    #region CheckMenuItem
    [DllImport("user32.dll", EntryPoint = "CheckMenuItem",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static uint CheckMenuItem([In] nint hMenu, [In] uint uIDCheckItem, [In] MenuFlag uCheck);
    #endregion

    #region CheckMenuRadioItem
    [DllImport("user32.dll", EntryPoint = "CheckMenuRadioItem",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CheckMenuRadioItem([In, NativeType("HMENU")] nint hmenu, [In] uint first, [In] uint last, [In] uint check, [In] uint flags);
    #endregion

    #region CheckRadioButton
    [DllImport("user32.dll", EntryPoint = "CheckRadioButton",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CheckRadioButton([In, NativeType("HWND")] nint hDlg, [In] int nIDFirstButton, [In] int nIDLastButton, [In] int nIDCheckButton);
    #endregion

    #region ChildWindowFromPoint
    [DllImport("user32.dll", EntryPoint = "ChildWindowFromPoint",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static nint ChildWindowFromPoint([In, NativeType("HWND")] nint hWndParent, [In] Point point);
    #endregion

    #region ChildWindowFromPointEx
    [DllImport("user32.dll", EntryPoint = "ChildWindowFromPointEx",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static nint ChildWindowFromPointEx([In, NativeType("HWND")] nint hwnd, [In] Point pt, [In] uint flags);
    #endregion

    #region ClientToScreen
    [DllImport("user32.dll", EntryPoint = "ClientToScreen",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool ClientToScreen([In, NativeType("HWND")] nint hWnd, [In, Out] ref Point point);
    #endregion

    #region ClipCursor
    [DllImport("user32.dll", EntryPoint = "ClipCursor",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool ClipCursor([In, Optional] ref Rect rect);
    #endregion

    #region CloseClipboard
    [DllImport("user32.dll", EntryPoint = "CloseClipboard",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CloseClipboard();
    #endregion

    #region CloseDesktop
    [DllImport("user32.dll", EntryPoint = "CloseDesktop",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CloseDesktop([In, NativeType("HDESK")] nint hDesktop);
    #endregion

    #region CloseGestureInfoHandle
    [DllImport("user32.dll", EntryPoint = "CloseGestureInfoHandle",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CloseGestureInfoHandle([In, NativeType("HGESTUREINFO")] nint hGestureInfo);
    #endregion

    #region CloseTouchInputHandle
    [DllImport("user32.dll", EntryPoint = "CloseTouchInputHandle",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CloseTouchInputHandle([In, NativeType("HTOUCHINPUT")] nint hTouchInput);
    #endregion

    #region CloseWindow
    [DllImport("user32.dll", EntryPoint = "CloseWindow",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CloseWindow([In, NativeType("HWND")] nint hWnd);
    #endregion

    #region CloseWindowStation
    [DllImport("user32.dll", EntryPoint = "CloseWindowStation",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CloseWindowStation([In, NativeType("HWINSTA")] nint hWinSta);
    #endregion

    #region CopyAcceleratorTable
    [DllImport("user32.dll", EntryPoint = "CopyAcceleratorTableW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static int CopyAcceleratorTable([In, NativeType("HACCEL")] nint hAccelSrc, [Out, Optional] Accelerator[]? accelDst, [In] int cAccelEntries);
    #endregion

    #region CopyIcon
    [DllImport("user32.dll", EntryPoint = "CopyIcon",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    [return: NativeType("HICON")]
    public extern static nint CopyIcon([In, NativeType("HICON")] nint hIcon);
    #endregion
    
    #region CopyImage
    [DllImport("user32.dll", EntryPoint = "CopyImage",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    [return: NativeType("HANDLE")]
    public extern static nint CopyImage([In, NativeType("HANDLE")] nint h, [In] ImageType type, [In] int cx, [In] int cy, [In] LR flags);
    #endregion

    #region CopyRect
    [DllImport("user32.dll", EntryPoint = "CopyRect",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CopyRect([Out] out Rect rcDst, [In] ref Rect rcSrc);
    #endregion

    #region CountClipboardFormats
    [DllImport("user32.dll", EntryPoint = "CountClipboardFormats",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static int CountClipboardFormats();
    #endregion

    #region CreateAcceleratorTable
    [DllImport("user32.dll", EntryPoint = "CreateAcceleratorTableW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    [return: NativeType("HACCEL")]
    public extern static nint CreateAcceleratorTable([In] ref Accelerator accel, [In] int cAccel);
    #endregion

    #region ShowWindow
    [DllImport("user32.dll", EntryPoint = "ShowWindow",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool ShowWindow([In, NativeType("HWND")] nint hWnd, [In] ShowWindowFlag nCmdShow);

    #region CreateCaret
    [DllImport("user32.dll", EntryPoint = "CreateCaret",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    public extern static bool CreateCaret([In, NativeType("HWND")] nint hWnd, [In, Optional, NativeType("HBITMAP")] nint hBitmap, [In] int width, [In] int height);
    #endregion

    #region CreateCursor
    [DllImport("user32.dll", EntryPoint = "CreateCursor",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    [return: NativeType("HCURSOR")]
    public extern static nint CreateCursor([In, Optional] nint hInst, [In] int xHotSpot, [In] int yHotSpot, [In] int width, [In] int height, [In] nint pvANDPlane, [In] nint pvXORPlane);

    #endregion

    #region CreateDesktop
    [DllImport("user32.dll", EntryPoint = "CreateDesktopW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDesktop([In] string desktop, [Reserved] string device, [Reserved] ref DeviceMode deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa);

    [DllImport("user32.dll", EntryPoint = "CreateDesktopW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDesktop([In] char* desktop, [Reserved] char* device, [Reserved] ref DeviceMode deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa);


    [DllImport("user32.dll", EntryPoint = "CreateDesktopExW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDesktopEx([In] string desktop, [Reserved] string device, [Reserved] ref DeviceMode deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa, [In] uint heapSize, [Reserved] nint pvoid);

    [DllImport("user32.dll", EntryPoint = "CreateDesktopExW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDesktopEx([In] char* desktop, [Reserved] char* device, [Reserved] ref DeviceMode deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa, [In] uint heapSize, [Reserved] nint pvoid);
    #endregion

    #region CreateDialogIndirectParam
    [DllImport("user32.dll", EntryPoint = "CreateDialogIndirectParamW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDialogIndirectParam([In, Optional, NativeType("HINSTANCE")] nint hInstance, [In] ref DialogTemplate template, [In,Optional, NativeType("HWND")] nint hWndParent, [In, Optional] DlgProc dialogFunc, [In, NativeType("LPARAM")] nint dwInitParam);
    #endregion

    #region CreateDialogParam
    [DllImport("user32.dll", EntryPoint = "CreateDialogParamW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDialogParam([In, Optional, NativeType("HINSTANCE")] nint hInstance, [In] string templateName, [In, Optional, NativeType("HWND")] nint hWndParent, [In, Optional] DlgProc dialogFunc, [In, NativeType("LPARAM")] nint dwInitParam);

    [DllImport("user32.dll", EntryPoint = "CreateDialogParamW",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static nint CreateDialogParam([In, Optional, NativeType("HINSTANCE")] nint hInstance, [In] char* templateName, [In, Optional, NativeType("HWND")] nint hWndParent, [In, Optional] DlgProc dialogFunc, [In, NativeType("LPARAM")] nint dwInitParam);
    #endregion











    #region GetCurrentProcessId
    [DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId",
               ExactSpelling = true, CharSet = CharSet.None, SetLastError = false)]
    private extern static IntPtr GetCurrentProcessId();
    #endregion

    [DllImport("user32.dll", SetLastError = false)]
    public extern static KeyboardLayout GetKeyboardLayout([In] uint idThread);

    [DllImport("user32.dll", SetLastError = false)]
    public extern static uint GetWindowThreadProcessId([In] nint hWnd, [Out, Optional] out uint dwProcessId);

    [DllImport("user32.dll", SetLastError = false)]
    public extern static nint GetForegroundWindow();
}
