using System.Runtime.CompilerServices;
using System;
using System.Runtime.InteropServices;
namespace EleCho.PlatformInvoke.Windows;

#region Delegates

[NativeType("WNDPROC")]
[return: NativeType("LRESULT")]
public delegate nint WndProc([NativeType("HWND")] nint hwnd, uint msg, [NativeType("WPARAM")] nuint wParam, [NativeType("LPARAM")] nint lParam);

[NativeType("DLGPROC")]
[return: NativeType("INT_PTR")]
public delegate nint DlgProc([NativeType("HWND")] nint hwnd, uint msg, [NativeType("WPARAM")] nuint wParam, [NativeType("LPARAM")] nint lParam);
#endregion

#region Point
[NativeType("POINT")]
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
[NativeType("SIZE")]
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
[NativeType("RECT")]
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
[NativeType("PAINTSTRUCT")]
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
[NativeType("LUID")]
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
[NativeType("BSMINFO")]
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
[NativeType("DEVMODEW")]
[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public unsafe struct DeviceMode
{
    [FieldOffset(0)]
    fixed char dmDeviceName[Constants.DeviceNameSize];

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
[NativeType("CHANGEFILTERSTRUCT")]
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

#region VideoParameters
[NativeType("VIDEOPARAMETERS")]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VideoParameters
{
    Guid guid;                         // GUID for this structure
    uint dwOffset;                     // leave it 0 for now.
    VideoParametersCommand dwCommand;                    // VP_COMMAND_*            SET or GET
    VideoParametersFlag dwFlags;                      // bitfield, defined below SET or GET
    VideoParametersMode dwMode;                       // bitfield, defined below SET or GET
    VideoParametersTvStandard dwTVStandard;                 // bitfield, defined below SET or GET
    VideoParametersMode dwAvailableModes;             // bitfield, defined below GET
    VideoParametersTvStandard dwAvailableTVStandard;        // bitfield, defined below GET
    uint dwFlickerFilter;              // value                   SET or GET
    uint dwOverScanX;                  // value                   SET or GET
    uint dwOverScanY;                  //                         SET or GET
    uint dwMaxUnscaledX;               // value                   SET or GET
    uint dwMaxUnscaledY;               //                         SET or GET
    uint dwPositionX;                  // value                   SET or GET
    uint dwPositionY;                  //                         SET or GET
    uint dwBrightness;                 // value                   SET or GET
    uint dwContrast;                   // value                   SET or GET
    VideoParametersCopyProtectionType dwCPType;                     // copy protection type    SET or GET
    VideoParametersCopyProtectionCommand dwCPCommand;                  // VP_CP_CMD_
    VideoParametersTvStandard dwCPStandard;                 // what TV standards CP is available on. GET
    uint dwCPKey;
    uint bCP_APSTriggerBits;           // (a dword for alignment) SET(bits 0 and 1 valid).
    
    fixed byte bOEMCopyProtection[256];      // oem specific copy protection data SET or GET

    public Guid Guid { get => guid; set => guid = value; }
    public uint Offset { get => dwOffset; set => dwOffset = value; }
    public VideoParametersCommand Command { get => dwCommand; set => dwCommand = value; }
    public VideoParametersFlag Flags { get => dwFlags; set => dwFlags = value; }
    public VideoParametersMode Mode { get => dwMode; set => dwMode = value; }
    public VideoParametersTvStandard TvStandard { get => dwTVStandard; set => dwTVStandard = value; }
    public VideoParametersMode AvailableModes { get => dwAvailableModes; set => dwAvailableModes = value; }
    public VideoParametersTvStandard AvailableTvStandard { get => dwAvailableTVStandard; set => dwAvailableTVStandard = value; }
    public uint FlickerFilter { get => dwFlickerFilter; set => dwFlickerFilter = value; }
    public uint OverScanX { get => dwOverScanX; set => dwOverScanX = value; }
    public uint OverScanY { get => dwOverScanY; set => dwOverScanY = value; }
    public uint MaxUnscaledX { get => dwMaxUnscaledX; set => dwMaxUnscaledX = value; }
    public uint MaxUnscaledY { get => dwMaxUnscaledY; set => dwMaxUnscaledY = value; }
    public uint PositionX { get => dwPositionX; set => dwPositionX = value; }
    public uint PositionY { get => dwPositionY; set => dwPositionY = value; }
    public uint Brightness { get => dwBrightness; set => dwBrightness = value; }
    public uint Contrast { get => dwContrast; set => dwContrast = value; }
    public VideoParametersCopyProtectionType CopyProtectionType { get => dwCPType; set => dwCPType = value; }
    public VideoParametersCopyProtectionCommand CopyProtectionCommand { get => dwCPCommand; set => dwCPCommand = value; }
    public VideoParametersTvStandard CopyProtectionStandard { get => dwCPStandard; set => dwCPStandard = value; }
    public uint CopyProtectionKey { get => dwCPKey; set => dwCPKey = value; }
    public uint ApsTriggerBits { get => bCP_APSTriggerBits; set => bCP_APSTriggerBits = value; }
    public Span<byte> OemCopyProtection
    {
        get
        {
            fixed (byte* ptr = bOEMCopyProtection)
            {
                return new Span<byte>(ptr, 256);
            }
        }
    }
}

[NativeType("ACCEL")]
public struct Accelerator
{
    byte     fVirt;               /* Also called the flags field */
    ushort   key;
    ushort   cmd;

    public Accelerator(byte fVirt, ushort key, ushort cmd) : this()
    {
        this.fVirt = fVirt;
        this.key = key;
        this.cmd = cmd;
    }

    public byte FVirt { get => fVirt; set => fVirt = value; }
    public ushort Key { get => key; set => key = value; }
    public ushort Cmd { get => cmd; set => cmd = value; }
}
#endregion

#region DialogTemplate
[NativeType("DLGTEMPLATE")]
[StructLayout(LayoutKind.Sequential)]
public struct DialogTemplate
{
    uint style;
    uint dwExtendedStyle;
    ushort cdit;
    short x;
    short y;
    short cx;
    short cy;

    public DialogTemplate(uint style, uint extendedStyle, ushort cdit, short x, short y, short cx, short cy)
    {
        this.style = style;
        this.dwExtendedStyle = extendedStyle;
        this.cdit = cdit;
        this.x = x;
        this.y = y;
        this.cx = cx;
        this.cy = cy;
    }

    public uint Style { get => style; set => style = value; }
    public uint ExtendedStyle { get => dwExtendedStyle; set => dwExtendedStyle = value; }
    public ushort Cdit { get => cdit; set => cdit = value; }
    public short X { get => x; set => x = value; }
    public short Y { get => y; set => y = value; }
    public short CX { get => cx; set => cx = value; }
    public short CY { get => cy; set => cy = value; }
}
#endregion

#region ImageDosHeader
[NativeType("IMAGE_DOS_HEADER")]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ImageDosHeader
{
    ushort magic;
    ushort cblp;
    ushort cp;
    ushort crlc;
    ushort cparhdr;
    ushort minalloc;
    ushort maxalloc;
    ushort ss;
    ushort sp;
    ushort csum;
    ushort ip;
    ushort cs;
    ushort lfarlc;
    ushort ovno;
    fixed ushort res[4];
    ushort oemid;
    ushort oeminfo;
    fixed ushort res2[10];
    ushort lfanew;

    public ImageDosHeader(ushort magic, ushort cblp, ushort cp, ushort crlc, ushort cparhdr, ushort minalloc, ushort maxalloc, ushort ss, ushort sp, ushort csum, ushort ip, ushort cs, ushort lfarlc, ushort ovno, Span<ushort> res, ushort oemid, ushort oeminfo, Span<ushort> res2, ushort lfanew)
    {
        this.magic = magic;
        this.cblp = cblp;
        this.cp = cp;
        this.crlc = crlc;
        this.cparhdr = cparhdr;
        this.minalloc = minalloc;
        this.maxalloc = maxalloc;
        this.ss = ss;
        this.sp = sp;
        this.csum = csum;
        this.ip = ip;
        this.cs = cs;
        this.lfarlc = lfarlc;
        this.ovno = ovno;

        fixed(void* src = res) 
        fixed(void* dest = this.res) 
        {
            int len = Math.Min(res.Length, 4);
            Buffer.MemoryCopy(src, dest, len, len);
        }

        this.oemid = oemid;
        this.oeminfo = oeminfo;

        fixed (void* src = res2)
        fixed (void* dest = this.res2)
        {
            int len = Math.Min(res2.Length, 10);
            Buffer.MemoryCopy(src, dest, len, len);
        }

        this.lfanew = lfanew;
    }

    public ushort Magic { get => magic; set => magic = value; }
    public ushort LastPageSize { get => cblp; set => cblp = value; }
    public ushort PageCount { get => cp; set => cp = value; }
    public ushort RelocationCount { get => crlc; set => crlc = value; }
    public ushort HeaderSize { get => cparhdr; set => cparhdr = value; }
    public ushort MinAllocation { get => minalloc; set => minalloc = value; }
    public ushort MaxAllocation { get => maxalloc; set => maxalloc = value; }
    public ushort SS { get => ss; set => ss = value; }
    public ushort SP { get => sp; set => sp = value; }
    public ushort Checksum { get => csum; set => csum = value; }
    public ushort IP { get => ip; set => ip = value; }
    public ushort CS { get => cs; set => cs = value; }
    public ushort RelocationTableOffset { get => lfarlc; set => lfarlc = value; }
    public ushort OverlayNumber { get => ovno; set => ovno = value; }
    public unsafe Span<ushort> Reserved
    {
        get
        {
            fixed (void* p = res)
            {
                return new Span<ushort>(p, 4);
            }
        }
    }
    public ushort OemIdentifier { get => oemid; set => oemid = value; }
    public ushort OemInformation { get => oeminfo; set => oeminfo = value; }
    public unsafe Span<ushort> Reserved2
    {
        get 
        {
            fixed(void* p = res2) 
            {
                return new Span<ushort>(p, 10);
            }
        }
    }
    public ushort NewExeHeaderOffset { get => lfanew; set => lfanew = value; }
}
#endregion

#region ImageDosHeader
[NativeType("IMAGE_FILE_HEADER")]
[StructLayout(LayoutKind.Sequential)]
public struct ImageFileHeader {
    ImageFileMachine machine;
    ushort numberOfSections;
    uint timeDateStamp;
    uint pointerToSymbolTable;
    uint numberOfSymbols;
    ushort sizeOfOptionalHeader;
    ImageFileCharacteristic characteristics;

    public ImageFileHeader(ImageFileMachine machine, ushort numberOfSections, uint timeDateStamp, uint pointerToSymbolTable, uint numberOfSymbols, ushort sizeOfOptionalHeader, ImageFileCharacteristic characteristics) {
        this.machine = machine;
        this.numberOfSections = numberOfSections;
        this.timeDateStamp = timeDateStamp;
        this.pointerToSymbolTable = pointerToSymbolTable;
        this.numberOfSymbols = numberOfSymbols;
        this.sizeOfOptionalHeader = sizeOfOptionalHeader;
        this.characteristics = characteristics;
    }

    public ImageFileMachine Machine { get => machine; set => machine = value; }
    public ushort NumberOfSections { get => numberOfSections; set => numberOfSections = value; }
    public uint TimeDateStamp { get => timeDateStamp; set => timeDateStamp = value; }
    public uint PointerToSymbolTable { get => pointerToSymbolTable; set => pointerToSymbolTable = value; }
    public uint NumberOfSymbols { get => numberOfSymbols; set => numberOfSymbols = value; }
    public ushort SizeOfOptionalHeader { get => sizeOfOptionalHeader; set => sizeOfOptionalHeader = value; }
    public ImageFileCharacteristic Characteristics { get => characteristics; set => characteristics = value; }
}
#endregion
