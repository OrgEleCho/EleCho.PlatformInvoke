using System.Runtime.InteropServices;
namespace EleCho.PlatformInvoke.Windows;

#region Delegates

[return: NativeType("LRESULT")]
public delegate nint WndProc([NativeType("HWND")] nint hwnd, uint msg, [NativeType("WPARAM")] nuint wParam, [NativeType("LPARAM")] nint lParam);

#endregion

#region Point
[StructLayout(LayoutKind.Sequential)]
public struct Point : IEquatable<Point>
{
    private int x;
    private int y;

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj) => obj is Point point && Equals(point);
    public bool Equals(Point other) => x == other.x && y == other.y;
    public override int GetHashCode() => HashCode.Combine(x, y);

    public static bool operator ==(Point left, Point right) => left.Equals(right);
    public static bool operator !=(Point left, Point right) => !(left == right);
}
#endregion

#region Size
[StructLayout(LayoutKind.Sequential)]
public struct Size : IEquatable<Size>
{
    private int cx;
    private int cy;

    public int Width { get => cx; set => cx = value; }
    public int Height { get => cy; set => cy = value; }

    public Size(int width, int height)
    {
        this.cx = width;
        this.cy = height;
    }

    public override bool Equals(object? obj) => obj is Size size && Equals(size);
    public bool Equals(Size other) => cx == other.cx && cy == other.cy;
    public override int GetHashCode() => HashCode.Combine(cx, cy);

    public static bool operator ==(Size left, Size right) => left.Equals(right);
    public static bool operator !=(Size left, Size right) => !(left == right);
}
#endregion

#region Rect
[StructLayout(LayoutKind.Sequential)]
public struct Rect : IEquatable<Rect>
{
    private int left;
    private int top;
    private int right;
    private int bottom;

    public Rect(int left, int top, int right, int bottom)
    {
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
    }

    public int Left { get => left; set => left = value; }
    public int Top { get => top; set => top = value; }
    public int Right { get => right; set => right = value; }
    public int Bottom { get => bottom; set => bottom = value; }

    public Point Location => new Point(Left, Top);
    public Size Size => new Size(Right - Left, Bottom - Top);

    public override bool Equals(object? obj) => obj is Rect rect && Equals(rect);
    public bool Equals(Rect other) => left == other.left && top == other.top && right == other.right && bottom == other.bottom;
    public override int GetHashCode() => HashCode.Combine(left, top, right, bottom);

    public static bool operator ==(Rect left, Rect right) => left.Equals(right);
    public static bool operator !=(Rect left, Rect right) => !(left == right);
}
#endregion

#region PaintStruct
[StructLayout(LayoutKind.Sequential)]
public unsafe struct PaintStruct : IEquatable<PaintStruct>
{
    private nint hdc;
    private uint fErase; //
    private Rect rcPaint;
    private uint fRestore;
    private uint fIncUpdate;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    private fixed byte rgbReserved[32];

    public PaintStruct(nint hdc, bool fErase, Rect rcPaint, bool fRestore, bool fIncUpdate)
    {
        this.hdc = hdc;
        this.fErase = fErase ? 1u : 0u;
        this.rcPaint = rcPaint;
        this.fRestore = fRestore ? 1u : 0u;
        this.fIncUpdate = fIncUpdate ? 1u : 0u;
    }

    public nint Hdc { get => hdc; set => hdc = value; }
    public bool Erase { get => fErase != 0; set => fErase = value ? 1u : 0u; }
    public Rect Paint { get => rcPaint; set => rcPaint = value; }
    public bool Restore { get => fRestore != 0; set => fRestore = value ? 1u : 0u; }
    public bool IncUpdate { get => fIncUpdate != 0; set => fIncUpdate = value ? 1u : 0u; }

    public override bool Equals(object? obj) => obj is PaintStruct @struct && Equals(@struct);
    public bool Equals(PaintStruct other) => hdc.Equals(other.hdc) && fErase == other.fErase && EqualityComparer<Rect>.Default.Equals(rcPaint, other.rcPaint) && fRestore == other.fRestore && fIncUpdate == other.fIncUpdate;
    public override int GetHashCode() => HashCode.Combine(hdc, fErase, rcPaint, fRestore, fIncUpdate);

    public static bool operator ==(PaintStruct left, PaintStruct right) => left.Equals(right);
    public static bool operator !=(PaintStruct left, PaintStruct right) => !(left == right);
}
#endregion

#region Luid
[StructLayout(LayoutKind.Sequential)]
public struct Luid : IEquatable<Luid>
{
    private uint lowPart;
    private int highPart;

    public Luid(uint lowPart, int highPart)
    {
        this.lowPart = lowPart;
        this.highPart = highPart;
    }

    public uint LowPart { get => lowPart; set => lowPart = value; }
    public int HighPart { get => highPart; set => highPart = value; }

    public override bool Equals(object? obj) => obj is Luid luid && Equals(luid);
    public bool Equals(Luid other) => lowPart == other.lowPart && highPart == other.highPart;
    public override int GetHashCode() => HashCode.Combine(lowPart, highPart);

    public static bool operator ==(Luid left, Luid right) => left.Equals(right);
    public static bool operator !=(Luid left, Luid right) => !(left == right);
}
#endregion

#region BsmInfo
[StructLayout(LayoutKind.Sequential)]
public struct BsmInfo : IEquatable<BsmInfo>
{
    private uint cbSize;
    private nint hdesk;
    private nint hwnd;
    private Luid luid;

    public BsmInfo(uint cbSize, nint hdesk, nint hwnd, Luid luid)
    {
        this.cbSize = cbSize;
        this.hdesk = hdesk;
        this.hwnd = hwnd;
        this.luid = luid;
    }

    public uint Size { get => cbSize; set => cbSize = value; }
    public nint Hdesk { get => hdesk; set => hdesk = value; }
    public nint Hwnd { get => hwnd; set => hwnd = value; }
    public Luid Luid { get => luid; set => luid = value; }

    public override bool Equals(object? obj) => obj is BsmInfo info && Equals(info);
    public bool Equals(BsmInfo other) => cbSize == other.cbSize && hdesk.Equals(other.hdesk) && hwnd.Equals(other.hwnd) && luid.Equals(other.luid);
    public override int GetHashCode() => HashCode.Combine(cbSize, hdesk, hwnd, luid);

    public static bool operator ==(BsmInfo left, BsmInfo right) => left.Equals(right);
    public static bool operator !=(BsmInfo left, BsmInfo right) => !(left == right);
}
#endregion

#region Message
[NativeType("MSG")]
[StructLayout(LayoutKind.Sequential)]
public struct Message : IEquatable<Message>
{
    private nint hwnd;
    private uint message;
    private nuint wParam;
    private nint lParam;
    private uint time;
    private Point pt;

    public nint Hwnd { get => hwnd; set => hwnd = value; }
    public uint MessageId { get => message; set => message = value; }
    public nuint WParam { get => wParam; set => wParam = value; }
    public nint LParam { get => lParam; set => lParam = value; }
    public uint Time { get => time; set => time = value; }
    public Point Pt { get => pt; set => pt = value; }

    public override bool Equals(object? obj) => obj is Message msg && Equals(msg);
    public bool Equals(Message other) => hwnd.Equals(other.hwnd) && message == other.message && wParam.Equals(other.wParam) && lParam.Equals(other.lParam) && time == other.time && EqualityComparer<Point>.Default.Equals(pt, other.pt) && Hwnd.Equals(other.Hwnd) && MessageId == other.MessageId && WParam.Equals(other.WParam) && LParam.Equals(other.LParam) && Time == other.Time && EqualityComparer<Point>.Default.Equals(Pt, other.Pt);

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(hwnd);
        hash.Add(message);
        hash.Add(wParam);
        hash.Add(lParam);
        hash.Add(time);
        hash.Add(pt);
        hash.Add(Hwnd);
        hash.Add(MessageId);
        hash.Add(WParam);
        hash.Add(LParam);
        hash.Add(Time);
        hash.Add(Pt);
        return hash.ToHashCode();
    }

    public static bool operator ==(Message left, Message right) => left.Equals(right);
    public static bool operator !=(Message left, Message right) => !(left == right);
}

#endregion

#region DeviceMode
[StructLayout(LayoutKind.Explicit)]
public unsafe struct DeviceMode
{
    [FieldOffset(0)]
    fixed char dmDeviceName[Constants.DeviceNameSize];
    [FieldOffset(0)]
    PlaceholderByte64 _placeholder_dmDeviceName;

    [FieldOffset(Constants.DeviceNameSize * 2)]
    ushort dmSpecVersion;

    [FieldOffset(Constants.DeviceNameSize * 2 + 2)]
    ushort dmDriverVersion;

    [FieldOffset(Constants.DeviceNameSize * 2 + 4)]
    ushort dmSize;

    [FieldOffset(Constants.DeviceNameSize * 2 + 6)]
    ushort dmDriverExtra;

    [FieldOffset(Constants.DeviceNameSize * 2 + 8)]
    DeviceModeField dmFields;

    // printer only fields: here offset 44

    [FieldOffset(Constants.DeviceNameSize * 2 + 12)]
    DeviceModeOrientation dmOrientation;

    [FieldOffset(Constants.DeviceNameSize * 2 + 14)]
    DeviceModePaperSize dmPaperSize;

    [FieldOffset(Constants.DeviceNameSize * 2 + 16)]
    short dmPaperLength;

    [FieldOffset(Constants.DeviceNameSize * 2 + 18)]
    short dmPaperWidth;

    [FieldOffset(Constants.DeviceNameSize * 2 + 20)]
    short dmScale;

    [FieldOffset(Constants.DeviceNameSize * 2 + 22)]
    short dmCopies;

    [FieldOffset(Constants.DeviceNameSize * 2 + 24)]
    DeviceModeBin dmDefaultSource;

    [FieldOffset(Constants.DeviceNameSize * 2 + 26)]
    DeviceModeResolution dmPrintQuality;

    // display only fields: here offset 44

    [FieldOffset(Constants.DeviceNameSize * 2 + 12)]
    Point dmPosition;

    [FieldOffset(Constants.DeviceNameSize * 2 + 20)]
    DeviceModeDisplayOrientation dmDisplayOrientation;

    [FieldOffset(Constants.DeviceNameSize * 2 + 24)]
    DeviceModeDisplayFixedOutput dmDisplayFixedOutput;



    [FieldOffset(Constants.DeviceNameSize * 2 + 28)]
    DeviceModeColor dmColor;

    [FieldOffset(Constants.DeviceNameSize * 2 + 30)]
    DeviceModeDuplex dmDuplex;

    [FieldOffset(Constants.DeviceNameSize * 2 + 32)]
    short dmYResolution;

    [FieldOffset(Constants.DeviceNameSize * 2 + 34)]
    DeviceModeTrueTypeOption dmTTOption;

    [FieldOffset(Constants.DeviceNameSize * 2 + 36)]
    DeviceModeCollation dmCollate;

    [FieldOffset(Constants.DeviceNameSize * 2 + 38)]
    fixed char dmFormName[Constants.FormNameSize];
    [FieldOffset(Constants.DeviceNameSize * 2 + 38)]
    PlaceholderByte64 _placeholder_dmFormName;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 38)]
    ushort dmLogPixels;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 40)]
    uint dmBitsPerPel;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 44)]
    uint dmPelsWidth;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 48)]
    uint dmPelsHeight;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 52)]
    DeviceModeDisplayFlag dmDisplayFlags;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 52)]
    DeviceModeNup dmNup;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 56)]
    uint dmDisplayFrequency;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 60)]
    DeviceModeIcmMethod dmICMMethod;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 64)]
    DeviceModeIcmIntent dmICMIntent;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 68)]
    DeviceModeMediaType dmMediaType;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 72)]
    DeviceModeDitherType dmDitherType;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 76)]
    uint dmReserved1;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 80)]
    uint dmReserved2;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 84)]
    uint dmPanningWidth;

    [FieldOffset(Constants.DeviceNameSize * 2 + Constants.FormNameSize * 2 + 88)]
    uint dmPanningHeight;

    public DeviceMode(string dmDeviceName, ushort dmSpecVersion, ushort dmDriverVersion, ushort dmSize, ushort dmDriverExtra, DeviceModeField dmFields,
        Point dmPosition, DeviceModeDisplayOrientation dmDisplayOrientation, DeviceModeDisplayFixedOutput dmDisplayFixedOutput, DeviceModeColor dmColor, DeviceModeDuplex dmDuplex, short dmYResolution, DeviceModeTrueTypeOption dmTTOption, DeviceModeCollation dmCollate,
        string dmFormName, ushort dmLogPixels, uint dmBitsPerPel, uint dmPelsWidth, uint dmPelsHeight, DeviceModeDisplayFlag dmDisplayFlags,
        uint dmDisplayFrequency, DeviceModeIcmMethod dmICMMethod, DeviceModeIcmIntent dmICMIntent, DeviceModeMediaType dmMediaType, DeviceModeDitherType dmDitherType, uint dmReserved1, uint dmReserved2, uint dmPanningWidth, uint dmPanningHeight) : this()
    {
        DeviceName = dmDeviceName;
        FormName = dmFormName;

        this.dmSpecVersion = dmSpecVersion;
        this.dmDriverVersion = dmDriverVersion;
        this.dmSize = dmSize;
        this.dmDriverExtra = dmDriverExtra;
        this.dmFields = dmFields;
        this.dmPosition = dmPosition;
        this.dmDisplayOrientation = dmDisplayOrientation;
        this.dmDisplayFixedOutput = dmDisplayFixedOutput;
        this.dmColor = dmColor;
        this.dmDuplex = dmDuplex;
        this.dmYResolution = dmYResolution;
        this.dmTTOption = dmTTOption;
        this.dmCollate = dmCollate;

        this.dmLogPixels = dmLogPixels;
        this.dmBitsPerPel = dmBitsPerPel;
        this.dmPelsWidth = dmPelsWidth;
        this.dmPelsHeight = dmPelsHeight;
        this.dmDisplayFlags = dmDisplayFlags;

        this.dmDisplayFrequency = dmDisplayFrequency;
        this.dmICMMethod = dmICMMethod;
        this.dmICMIntent = dmICMIntent;
        this.dmMediaType = dmMediaType;
        this.dmDitherType = dmDitherType;
        this.dmReserved1 = dmReserved1;
        this.dmReserved2 = dmReserved2;
        this.dmPanningWidth = dmPanningWidth;
        this.dmPanningHeight = dmPanningHeight;
    }

    public DeviceMode(string dmDeviceName, ushort dmSpecVersion, ushort dmDriverVersion, ushort dmSize, ushort dmDriverExtra, DeviceModeField dmFields,
        DeviceModeOrientation dmOrientation, DeviceModePaperSize dmPaperSize, short dmPaperLength, short dmPaperWidth, short dmScale, short dmCopies,
        DeviceModeBin dmDefaultSource, DeviceModeResolution dmPrintQuality, DeviceModeColor dmColor, DeviceModeDuplex dmDuplex, short dmYResolution, DeviceModeTrueTypeOption dmTTOption, DeviceModeCollation dmCollate,
        string dmFormName, ushort dmLogPixels, uint dmBitsPerPel, uint dmPelsWidth, uint dmPelsHeight, DeviceModeNup dmNup,
        uint dmDisplayFrequency, DeviceModeIcmMethod dmICMMethod, DeviceModeIcmIntent dmICMIntent, DeviceModeMediaType dmMediaType, DeviceModeDitherType dmDitherType, uint dmReserved1, uint dmReserved2, uint dmPanningWidth, uint dmPanningHeight) : this()
    {
        DeviceName = dmDeviceName;
        FormName = dmFormName;

        this.dmSpecVersion = dmSpecVersion;
        this.dmDriverVersion = dmDriverVersion;
        this.dmSize = dmSize;
        this.dmDriverExtra = dmDriverExtra;
        this.dmFields = dmFields;
        this.dmOrientation = dmOrientation;
        this.dmPaperSize = dmPaperSize;
        this.dmPaperLength = dmPaperLength;
        this.dmPaperWidth = dmPaperWidth;
        this.dmScale = dmScale;
        this.dmCopies = dmCopies;
        this.dmDefaultSource = dmDefaultSource;
        this.dmPrintQuality = dmPrintQuality;
        this.dmColor = dmColor;
        this.dmDuplex = dmDuplex;
        this.dmYResolution = dmYResolution;
        this.dmTTOption = dmTTOption;
        this.dmCollate = dmCollate;
        this.dmLogPixels = dmLogPixels;
        this.dmBitsPerPel = dmBitsPerPel;
        this.dmPelsWidth = dmPelsWidth;
        this.dmPelsHeight = dmPelsHeight;
        this.dmNup = dmNup;

        this.dmDisplayFrequency = dmDisplayFrequency;
        this.dmICMMethod = dmICMMethod;
        this.dmICMIntent = dmICMIntent;
        this.dmMediaType = dmMediaType;
        this.dmDitherType = dmDitherType;
        this.dmReserved1 = dmReserved1;
        this.dmReserved2 = dmReserved2;
        this.dmPanningWidth = dmPanningWidth;
        this.dmPanningHeight = dmPanningHeight;
    }
    public string DeviceName
    {
        get
        {
            fixed (char* p = dmDeviceName)
            {
                return Marshal.PtrToStringUni((nint)p)!;
            }
        }
        set
        {
            fixed (char* p = dmDeviceName)
            {
                if (value.Length >= Constants.DeviceNameSize)
                    throw new ArgumentException($"The string is too large and it cannot be greater than or equal to {Constants.DeviceNameSize}");

                char* ptr = (char*)Marshal.StringToHGlobalUni(value);
                int maxcopy = Constants.DeviceNameSize - 1;
                int maxcopysize = maxcopy * sizeof(char);

                Buffer.MemoryCopy(ptr, p, maxcopysize, maxcopysize);
                p[maxcopy] = '\0';

                Marshal.FreeHGlobal((IntPtr)ptr);
            }
        }
    }
    public ushort SpecVersion { get => dmSpecVersion; set => dmSpecVersion = value; }
    public ushort DriverVersion { get => dmDriverVersion; set => dmDriverVersion = value; }
    public ushort Size { get => dmSize; set => dmSize = value; }
    public ushort DriverExtra { get => dmDriverExtra; set => dmDriverExtra = value; }
    public DeviceModeField Fields { get => dmFields; set => dmFields = value; }
    public DeviceModeOrientation Orientation { get => dmOrientation; set => dmOrientation = value; }
    public DeviceModePaperSize PaperSize { get => dmPaperSize; set => dmPaperSize = value; }
    public short PaperLength { get => dmPaperLength; set => dmPaperLength = value; }
    public short PaperWidth { get => dmPaperWidth; set => dmPaperWidth = value; }
    public short Scale { get => dmScale; set => dmScale = value; }
    public short Copies { get => dmCopies; set => dmCopies = value; }
    public DeviceModeBin DefaultSource { get => dmDefaultSource; set => dmDefaultSource = value; }
    public DeviceModeResolution PrintQuality { get => dmPrintQuality; set => dmPrintQuality = value; }
    public Point Position { get => dmPosition; set => dmPosition = value; }
    public DeviceModeDisplayOrientation DisplayOrientation { get => dmDisplayOrientation; set => dmDisplayOrientation = value; }
    public DeviceModeDisplayFixedOutput DisplayFixedOutput { get => dmDisplayFixedOutput; set => dmDisplayFixedOutput = value; }
    public DeviceModeColor Color { get => dmColor; set => dmColor = value; }
    public DeviceModeDuplex Duplex { get => dmDuplex; set => dmDuplex = value; }
    public short YResolution { get => dmYResolution; set => dmYResolution = value; }
    public DeviceModeTrueTypeOption TTOption { get => dmTTOption; set => dmTTOption = value; }
    public DeviceModeCollation Collate { get => dmCollate; set => dmCollate = value; }
    public string FormName
    {
        get
        {
            fixed (char* p = dmFormName)
            {
                return Marshal.PtrToStringUni((nint)p)!;
            }
        }
        set
        {
            fixed (char* p = dmFormName)
            {
                if (value.Length >= Constants.FormNameSize)
                    throw new ArgumentException($"The string is too large and it cannot be greater than or equal to {Constants.FormNameSize}");

                char* ptr = (char*)Marshal.StringToHGlobalUni(value);
                int maxcopy = Constants.FormNameSize - 1;
                int maxcopysize = maxcopy * sizeof(char);

                Buffer.MemoryCopy(ptr, p, maxcopysize, maxcopysize);
                p[maxcopy] = '\0';

                Marshal.FreeHGlobal((IntPtr)ptr);
            }
        }
    }
    public ushort LogPixels { get => dmLogPixels; set => dmLogPixels = value; }
    public uint BitsPerPel { get => dmBitsPerPel; set => dmBitsPerPel = value; }
    public uint PelsWidth { get => dmPelsWidth; set => dmPelsWidth = value; }
    public uint PelsHeight { get => dmPelsHeight; set => dmPelsHeight = value; }
    public DeviceModeDisplayFlag DisplayFlags { get => dmDisplayFlags; set => dmDisplayFlags = value; }
    public DeviceModeNup Nup { get => dmNup; set => dmNup = value; }
    public uint DisplayFrequency { get => dmDisplayFrequency; set => dmDisplayFrequency = value; }
    public DeviceModeIcmMethod IcmMethod { get => dmICMMethod; set => dmICMMethod = value; }
    public DeviceModeIcmIntent IcmIntent { get => dmICMIntent; set => dmICMIntent = value; }
    public DeviceModeMediaType MediaType { get => dmMediaType; set => dmMediaType = value; }
    public DeviceModeDitherType DitherType { get => dmDitherType; set => dmDitherType = value; }
    public uint Reserved1 { get => dmReserved1; set => dmReserved1 = value; }
    public uint Reserved2 { get => dmReserved2; set => dmReserved2 = value; }
    public uint PanningWidth { get => dmPanningWidth; set => dmPanningWidth = value; }
    public uint PanningHeight { get => dmPanningHeight; set => dmPanningHeight = value; }
}
#endregion

#region ChangeFilterStruct
[StructLayout(LayoutKind.Sequential)]
public struct ChangeFilterStruct
{
    uint cbSize;
    MessageFilterInfo _ExtStatus;

    public unsafe ChangeFilterStruct()
    {
        cbSize = (uint)sizeof(ChangeFilterStruct);
        _ExtStatus = default;
    }

    public unsafe ChangeFilterStruct(MessageFilterInfo extStatus)
    {
        cbSize = (uint)sizeof(ChangeFilterStruct);
        _ExtStatus = extStatus;
    }

    public ChangeFilterStruct(uint cbSize, MessageFilterInfo extStatus)
    {
        this.cbSize = cbSize;
        _ExtStatus = extStatus;
    }

    public uint Size { get => cbSize; set => cbSize = value; }
    public MessageFilterInfo ExtStatus { get => _ExtStatus; set => _ExtStatus = value; }
}
#endregion