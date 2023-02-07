using EleCho.PlatformInvoke.Windows;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

//把Internal暴露给另外一个程序集或者项目
[assembly: InternalsVisibleTo("EleCho.PlatformInvoke.Common")]

internal unsafe class Program
{
    public record struct MyStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Name;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string Description;

        public int Qwq;
    }

    public const string TestDll = "C:\\Users\\slime\\source\\repos\\PlatformInvoke\\x64\\Debug\\ExportTestingViewer.dll";

    [DllImport(TestDll, EntryPoint = "plus1")]
    public static extern nint Plus1(ref int num);

    [DllImport(TestDll, EntryPoint = "print_info")]
    public static extern void PrintInfo(ref MyStruct myStruct);


    private static void Main(string[] args)
    {
        MyStruct myStruct = new MyStruct()
        {
            Name = "Hello world, this is a very large string, the length is even greater than 32, so it will be truncated",
            Description = "QWQ",
            Qwq = 114000,
        };

        Console.WriteLine(myStruct);
        PrintInfo(ref myStruct);
        Console.WriteLine(myStruct);
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