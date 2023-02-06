using System.Runtime.InteropServices;
namespace EleCho.PlatformInvoke.Windows;

[NativeType("DEVMODEA")]
[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
public unsafe struct DeviceModeA
{
    [FieldOffset(0)]
    fixed byte dmDeviceName[Constants.DeviceNameSize];

    [FieldOffset(Constants.DeviceNameSize)]
    ushort dmSpecVersion;

    [FieldOffset(Constants.DeviceNameSize + 2)]
    ushort dmDriverVersion;

    [FieldOffset(Constants.DeviceNameSize + 4)]
    ushort dmSize;

    [FieldOffset(Constants.DeviceNameSize + 6)]
    ushort dmDriverExtra;

    [FieldOffset(Constants.DeviceNameSize + 8)]
    DeviceModeField dmFields;

    // printer only fields: here offset 44

    [FieldOffset(Constants.DeviceNameSize + 12)]
    DeviceModeOrientation dmOrientation;

    [FieldOffset(Constants.DeviceNameSize + 14)]
    DeviceModePaperSize dmPaperSize;

    [FieldOffset(Constants.DeviceNameSize + 16)]
    short dmPaperLength;

    [FieldOffset(Constants.DeviceNameSize + 18)]
    short dmPaperWidth;

    [FieldOffset(Constants.DeviceNameSize + 20)]
    short dmScale;

    [FieldOffset(Constants.DeviceNameSize + 22)]
    short dmCopies;

    [FieldOffset(Constants.DeviceNameSize + 24)]
    DeviceModeBin dmDefaultSource;

    [FieldOffset(Constants.DeviceNameSize + 26)]
    DeviceModeResolution dmPrintQuality;

    // display only fields: here offset 44

    [FieldOffset(Constants.DeviceNameSize + 12)]
    Point dmPosition;

    [FieldOffset(Constants.DeviceNameSize + 20)]
    DeviceModeDisplayOrientation dmDisplayOrientation;

    [FieldOffset(Constants.DeviceNameSize + 24)]
    DeviceModeDisplayFixedOutput dmDisplayFixedOutput;


    [FieldOffset(Constants.DeviceNameSize + 28)]
    DeviceModeColor dmColor;

    [FieldOffset(Constants.DeviceNameSize + 30)]
    DeviceModeDuplex dmDuplex;

    [FieldOffset(Constants.DeviceNameSize + 32)]
    short dmYResolution;

    [FieldOffset(Constants.DeviceNameSize + 34)]
    DeviceModeTrueTypeOption dmTTOption;

    [FieldOffset(Constants.DeviceNameSize + 36)]
    DeviceModeCollation dmCollate;

    [FieldOffset(Constants.DeviceNameSize + 38)]
    fixed byte dmFormName[Constants.FormNameSize];

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 38)]
    ushort dmLogPixels;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 40)]
    uint dmBitsPerPel;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 44)]
    uint dmPelsWidth;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 48)]
    uint dmPelsHeight;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 52)]
    DeviceModeDisplayFlag dmDisplayFlags;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 52)]
    DeviceModeNup dmNup;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 56)]
    uint dmDisplayFrequency;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 60)]
    DeviceModeIcmMethod dmICMMethod;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 64)]
    DeviceModeIcmIntent dmICMIntent;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 68)]
    DeviceModeMediaType dmMediaType;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 72)]
    DeviceModeDitherType dmDitherType;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 76)]
    uint dmReserved1;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 80)]
    uint dmReserved2;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 84)]
    uint dmPanningWidth;

    [FieldOffset(Constants.DeviceNameSize + Constants.FormNameSize + 88)]
    uint dmPanningHeight;

    public DeviceModeA(string dmDeviceName, ushort dmSpecVersion, ushort dmDriverVersion, ushort dmSize, ushort dmDriverExtra, DeviceModeField dmFields,
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

    public DeviceModeA(string dmDeviceName, ushort dmSpecVersion, ushort dmDriverVersion, ushort dmSize, ushort dmDriverExtra, DeviceModeField dmFields,
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
            fixed (byte* p = dmDeviceName)
            {
                return Marshal.PtrToStringAnsi((nint)p)!;
            }
        }
        set
        {
            fixed (byte* p = dmDeviceName)
            {
                if (value.Length >= Constants.DeviceNameSize)
                    throw new ArgumentException($"The string is too large and it cannot be greater than or equal to {Constants.DeviceNameSize}");

                char* ptr = (char*)Marshal.StringToHGlobalUni(value);
                int maxcopy = Constants.DeviceNameSize - 1;

                Buffer.MemoryCopy(ptr, p, maxcopy, maxcopy);
                p[maxcopy] = 0;

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
            fixed (byte* p = dmFormName)
            {
                return Marshal.PtrToStringAnsi((nint)p)!;
            }
        }
        set
        {
            fixed (byte* p = dmFormName)
            {
                if (value.Length >= Constants.FormNameSize)
                    throw new ArgumentException($"The string is too large and it cannot be greater than or equal to {Constants.FormNameSize}");

                char* ptr = (char*)Marshal.StringToHGlobalUni(value);
                int maxcopy = Constants.FormNameSize - 1;

                Buffer.MemoryCopy(ptr, p, maxcopy, maxcopy);
                p[maxcopy] = 0;

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
