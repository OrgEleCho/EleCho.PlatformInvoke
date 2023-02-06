using System.Runtime.InteropServices;
using System.Text;

namespace EleCho.PlatformInvoke.Windows;

public unsafe class NativeMethodsAnsi
{

    #region AnyPopup
    [DllImport("user32.dll", EntryPoint = "AppendMenuA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public static extern bool AppendMenu([In] nint hMenu, [In] MenuFlag uFlags, [In] nuint uIDNewItem, [In, Optional] string? lpNewItem);
    [DllImport("user32.dll", EntryPoint = "AppendMenuA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public static extern bool AppendMenu([In] nint hMenu, [In] MenuFlag uFlags, [In] nuint uIDNewItem, [In, Optional] byte* lpNewItem);
    #endregion

    #region BroadcastSystemMessage
    [DllImport("user32.dll", EntryPoint = "BroadcastSystemMessageA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static int BroadcastSystemMessage([In] BroadcastSystemMessageFlag flags, [In,Out,Optional] ref BradcastSystemMessageRecipient info, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    [DllImport("user32.dll", EntryPoint = "BroadcastSystemMessageExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public static extern int BroadcastSystemMessageEx([In] BroadcastSystemMessageFlag flags, [In, Out, Optional] ref BradcastSystemMessageRecipient lpInfo, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam, [Out, Optional] out BsmInfo bsmInfo);
    #endregion


    #region CallMsgFilter
    [DllImport("user32.dll", EntryPoint = "CallMsgFilterA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static bool CallMsgFilter([In] ref Message msg, [In] int nCode);
    #endregion

    #region CallWindowProc
    [DllImport("user32.dll", EntryPoint = "CallWindowProcA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    [return: NativeType("LRESULT")]
    public extern static nint CallWindowProc([In] WndProc lpPrevWndProc, [In, NativeType("HWND")] nint hWnd, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    [DllImport("user32.dll", EntryPoint = "CallWindowProcA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    [return: NativeType("LRESULT")]
    public extern static nint CallWindowProc([In] nint lpPrevWndProc, [In, NativeType("HWND")] nint hWnd, [In] uint msg, [In, NativeType("WPARAM")] nuint wParam, [In, NativeType("LPARAM")] nint lParam);
    #endregion

    #region ChangeMenu
    [DllImport("user32.dll", EntryPoint = "ChangeMenuA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static bool ChangeMenu([In, NativeType("HMENU")] nint hMenu, [In] uint cmd, [In, Optional] string? szNewItem, [In] uint cmdInsert, [In] uint flags);
    [DllImport("user32.dll", EntryPoint = "ChangeMenuA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static bool ChangeMenu([In, NativeType("HMENU")] nint hMenu, [In] uint cmd, [In, Optional] byte* szNewItem, [In] uint cmdInsert, [In] uint flags);
    #endregion

    #region CharLower
    [DllImport("user32.dll", EntryPoint = "CharLowerA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CharLower([In, Out] StringBuilder str);
    [DllImport("user32.dll", EntryPoint = "CharLowerA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CharLower([In, Out] byte* str);
    #endregion

    #region CharLowerBuff
    [DllImport("user32.dll", EntryPoint = "CharLowerBuffA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static uint CharLowerBuff([In, Out] StringBuilder str, [In] uint cchLength);
    [DllImport("user32.dll", EntryPoint = "CharLowerBuffA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static uint CharLowerBuff([In, Out] byte* str, [In] uint cchLength);
    #endregion

    #region CharNext
    [DllImport("user32.dll", EntryPoint = "CharNextA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharNext([In] byte* str);

    [DllImport("user32.dll", EntryPoint = "CharNextExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharNextEx(CodePage codePage, byte* lpCurrentChar, uint dwFlags);

    [DllImport("user32.dll", EntryPoint = "CharNextExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharNextEx(ushort codePage, byte* lpCurrentChar, uint dwFlags);
    #endregion
    
    #region CharPrev
    [DllImport("user32.dll", EntryPoint = "CharPrevA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharPrev([In] byte* lpszStart, [In] byte* lpszCurrent);
    
    [DllImport("user32.dll", EntryPoint = "CharPrevExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharPrevEx([In] CodePage codePage, [In] byte* lpStart, [In] byte* lpCurrentChar, [In] uint dwFlags);

    [DllImport("user32.dll", EntryPoint = "CharPrevExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharPrevEx([In] ushort codePage, [In] byte* lpStart, [In] byte* lpCurrentChar, [In] uint dwFlags);
    #endregion

    #region CharToOem
    [DllImport("user32.dll", EntryPoint = "CharToOemA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static bool CharToOem([In] byte* pSrc, [Out] byte* pDst);
    #endregion

    #region CharToOemBuff
    [DllImport("user32.dll", EntryPoint = "CharToOemBuffA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static bool CharToOemBuff([In] byte* lpszSrc, [Out] byte* lpszDst, [In] uint cchDstLength);
    #endregion

    #region CharUpper
    [DllImport("user32.dll", EntryPoint = "CharUpperA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static byte* CharUpper([In, Out] byte* lpsz);
    #endregion

    #region CharUpperBuff
    [DllImport("user32.dll", EntryPoint = "CharUpperBuffA",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    public extern static uint CharUpperBuff([In, Out] byte* lpsz, [In] uint cchLength);
    #endregion
    
    #region ChangeDisplaySettings
    [DllImport("user32.dll", EntryPoint = "ChangeDisplaySettingsA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static DisplayChangeResult ChangeDisplaySettings([In, Optional] ref DeviceModeA devMode);

    [DllImport("user32.dll", EntryPoint = "ChangeDisplaySettingsExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static DisplayChangeResult ChangeDisplaySettingsEx([In, Optional] string? deviceName, [In, Optional] ref DeviceModeA devMode, [Reserved, NativeType("HWND")] nint hwnd, [In] ChangeDisplaySettingsFlag dwFlags, [In, Optional] ref VideoParameters lParam);

    [DllImport("user32.dll", EntryPoint = "ChangeDisplaySettingsExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static DisplayChangeResult ChangeDisplaySettingsEx([In, Optional] char* lpszDeviceName, [In, Optional] ref DeviceModeA devMode, [Reserved, NativeType("HWND")] nint hwnd, [In] ChangeDisplaySettingsFlag dwFlags, [In, Optional] ref VideoParameters lParam);
    #endregion

    #region CopyAcceleratorTable
    [DllImport("user32.dll", EntryPoint = "CopyAcceleratorTableA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static int CopyAcceleratorTable([In, NativeType("HACCEL")] nint hAccelSrc, [Out, Optional] Accelerator[]? accelDst, [In] int cAccelEntries);
    #endregion

    #region CreateAcceleratorTable
    [DllImport("user32.dll", EntryPoint = "CopyAcceleratorTableA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CopyAcceleratorTableA([In] ref Accelerator accel, [In] int cAccel);
    #endregion

    #region CreateDesktop
    [DllImport("user32.dll", EntryPoint = "CreateDesktopA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CreateDesktop([In] string desktop, [Reserved] string device, [Reserved] ref DeviceModeA deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa);

    [DllImport("user32.dll", EntryPoint = "CreateDesktopA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CreateDesktop([In] byte* desktop, [Reserved] byte* device, [Reserved] ref DeviceModeA deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa);

    [DllImport("user32.dll", EntryPoint = "CreateDesktopExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CreateDesktopEx([In] string desktop, [Reserved] string device, [Reserved] ref DeviceModeA deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa, [In] uint heapSize, [Reserved] nint pvoid);

    [DllImport("user32.dll", EntryPoint = "CreateDesktopExA",
               ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = false)]
    public extern static nint CreateDesktopEx([In] byte* desktop, [Reserved] byte* device, [Reserved] ref DeviceModeA deviceMode, [In] DesktopControlFlags flags, [In, NativeType("ACCESS_MASK")] uint desiredAccess, [In, Optional, NativeType("LPSECURITY_ATTRIBUTES")] nint sa, [In] uint heapSize, [Reserved] nint pvoid);
    #endregion
}