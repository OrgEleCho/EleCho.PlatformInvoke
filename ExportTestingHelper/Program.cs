using EleCho.PlatformInvoke.Windows;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

//把Internal暴露给另外一个程序集或者项目
[assembly: InternalsVisibleTo("EleCho.PlatformInvoke.Common")]

internal unsafe class Program
{
    public const string TestDll = "C:\\Users\\slime\\source\\repos\\PlatformInvoke\\x64\\Debug\\ExportTestingViewer.dll";

    [StructLayout(LayoutKind.Sequential)]
    struct SomeIntegers
    {
        public byte A;              // 1 byte
                                    // 3 byte
        public TwoIntegers B;       // 8 bytes
        public byte C;              // 1 byte
                                    // 3 bytes
    }

    [StructLayout(LayoutKind.Sequential)]
    struct TwoIntegers
    {
        int A;    // 4 bytes
        byte B;   // 1 byte
                  // 3 bytes
    }

    public struct QWQ
    {
        byte A;
        Int128 B;
    }
    readonly struct Temp
    {
        readonly int a,b;
    }

    private static void Main(string[] args)
    {
        //foreach (var attr in typeof(MyInt128).GetCustomAttributes(true))
        //    Console.WriteLine(attr.GetType());
        Console.WriteLine(sizeof(SomeIntegers));
    }

}

static unsafe class Utils
{
    public static void SetStringUni(nint ptr, string? value)
    {
        char* p = (char*)ptr;

        if (value == null)
        {
            p[0] = '\0';
            return;
        }

        int size = value.Length * 2;
        IntPtr newptr = Marshal.StringToHGlobalUni(value);
        Buffer.MemoryCopy((void*)newptr, (void*)p, size, size);
        Marshal.FreeHGlobal(newptr);

        p[value.Length] = '\0';
    }
}