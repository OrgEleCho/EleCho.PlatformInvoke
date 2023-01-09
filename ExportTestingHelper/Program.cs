using EleCho.PlatformInvoke.Windows;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

//把Internal暴露给另外一个程序集或者项目
[assembly: InternalsVisibleTo("EleCho.PlatformInvoke.Common")]

internal unsafe class Program
{
    public const string Dll = "C:\\Users\\slime\\source\\repos\\PlatformInvoke\\x64\\Debug\\ExportTestingViewer.dll";

    [DllImport(Dll, EntryPoint = "char_next_w",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    private extern static void CharNext(byte* str);


    [DllImport(Dll, EntryPoint = "Check_DEVMODE",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    private extern static void Check_DEVMODE(DeviceMode* str);


    [DllImport(Dll, EntryPoint = "Check_DEVMODE",
               ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = false)]
    private extern static void Check_DEVMODE([In]ref DeviceMode str);
    private static void Main(string[] args)
    {
        DeviceMode deviceMode = new DeviceMode();
        deviceMode.DeviceName = "Fuck you world";
        deviceMode.FormName = "Fuck you world";
        deviceMode.Reserved2 = 114514;

        Check_DEVMODE(&deviceMode);
    }

    private static void TestAllApis(Type defineType)
    {

    }
}