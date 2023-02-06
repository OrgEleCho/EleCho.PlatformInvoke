using EleCho.PlatformInvoke.Windows;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

//把Internal暴露给另外一个程序集或者项目
[assembly: InternalsVisibleTo("EleCho.PlatformInvoke.Common")]

internal unsafe class Program
{
    public const string TestDll = "C:\\Users\\slime\\source\\repos\\PlatformInvoke\\x64\\Debug\\ExportTestingViewer.dll";

    [DllImport(TestDll, EntryPoint = "plus1")]
    public static extern nint Plus1(ref int num);

    private static void Main(string[] args)
    {
        int q = 114513;
        var p = Plus1(ref q);
        ref int n = ref Unsafe.AsRef<int>((void*)p);
        Console.WriteLine(n);
        Console.WriteLine(q);
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