namespace EleCho.PlatformInvoke.Windows;

public static class Constants
{
    /// <summary>
    /// CCHDEVICENAME (Device Name Size, count of charactors)
    /// </summary>
    public const int DeviceNameSize = 32;

    /// <summary>
    /// CCHFORMNAME (Form Name Size, count of charactors)
    /// </summary>
    public const int FormNameSize = 32;

    public static class DevMode
    {
        public const int SpecVersion = 0x0401;
    }
}

public enum KeyboardLayout : int
{
    Next = 1,
    Prev = 0,
}

[Flags]
public enum KeyboardLayoutFlag : uint
{
    Activate        = 0x00000001,
    SubtitleOk      = 0x00000002,
    Reorder         = 0x00000008,
    ReplaceLang     = 0x00000010,
    NoTellShell     = 0x00000080,
    SetForProcess   = 0x00000100,
    ShiftLock       = 0x00010000,
    Reset           = 0x40000000,
}

[Flags]
public enum WindowStyle : uint
{
    Overlapped       = 0x00000000,
    Popup            = 0x80000000,
    Child            = 0x40000000,
    Minimize         = 0x20000000,
    Visible          = 0x10000000,
    Disabled         = 0x08000000,
    ClipSiblings     = 0x04000000,
    ClipChildren     = 0x02000000,
    Maximize         = 0x01000000,
    /// <summary>
    /// Border | DlgFrame
    /// </summary>
    Caption          = 0x00C00000,     /* BORDER | DLGFRAME  */
    Border           = 0x00800000,
    /// <summary>
    /// 原名: DLGFRAME
    /// </summary>
    DialogFrame         = 0x00400000,
    VScroll          = 0x00200000,
    HScroll          = 0x00100000,
    SysMenu          = 0x00080000,
    ThickFrame       = 0x00040000,
    Group            = 0x00020000,
    TabStop          = 0x00010000,

    MinimizeBox      = 0x00020000,
    MaximizeBox      = 0x00010000,

    Tiled            = Overlapped,
    Iconic           = Minimize,
    SizeBox          = ThickFrame,
    TiledWindow      = OverlappedWindow,

    OverlappedWindow = (Overlapped     |
                        Caption        |
                        SysMenu        |
                        ThickFrame     |
                        MinimizeBox    |
                        MaximizeBox),

    PopupWindow      = (Popup          |
                        Border         |
                        SysMenu),

    ChildWindow      = (Child)
}

[Flags]
public enum WindowStyleExtened : uint
{
    /// <summary>
    /// Dialog Modal Frame
    /// </summary>
    DialogModalFrame    = 0x00000001,
    NoParentNotify      = 0x00000004,
    TopMost             = 0x00000008,
    AcceptFiles         = 0x00000010,
    Transparent         = 0x00000020,
    MdiChild            = 0x00000040,
    ToolWindow          = 0x00000080,
    WindowEdge          = 0x00000100,
    ClientEdge          = 0x00000200,
    ContextHelp         = 0x00000400,

    Right               = 0x00001000,
    Left                = 0x00000000,
    RtlReading          = 0x00002000,
    LtrReading          = 0x00000000,
    LeftScrollBar       = 0x00004000,
    RightScrollBar      = 0x00000000,

    ControlParent       = 0x00010000,
    StaticEdge          = 0x00020000,
    AppWindow           = 0x00040000,

    OverlappedWindow    = (WindowEdge | ClientEdge),
    PaletteWindow       = (WindowEdge | ToolWindow | TopMost),

    Layered             = 0x00080000,
    NoInheritLayout     = 0x00100000, // Disable inheritence of mirroring by children
    LayoutRtl           = 0x00400000, // Right to left mirroring
    Composited          = 0x02000000,
    NoActivate          = 0x08000000
}

[Flags]
public enum AnimateWindowFlag : uint
{
    HorizontalPositive         = 0x00000001,
    HorizontalNegative         = 0x00000002,
    VerticalPositive         = 0x00000004,
    VerticalNegative         = 0x00000008,
    Center              = 0x00000010,
    Hide                = 0x00010000,
    Activate            = 0x00020000,
    Slide               = 0x00040000,
    Blend               = 0x00080000,
}

[Flags]
public enum MenuFlag : uint
{
    Insert           = 0x00000000,
    Change           = 0x00000080,
    Append           = 0x00000100,
    Delete           = 0x00000200,
    Remove           = 0x00001000,

    ByCommand        = 0x00000000,
    ByPosition       = 0x00000400,

    Separator        = 0x00000800,

    Enabled          = 0x00000000,
    Grayed           = 0x00000001,
    Disabled         = 0x00000002,

    Unchecked        = 0x00000000,
    Checked          = 0x00000008,
    UseCheckBitmaps  = 0x00000200,

    String           = 0x00000000,
    Bitmap           = 0x00000004,
    OwnerDraw        = 0x00000100,

    Popup            = 0x00000010,
    MenuBarBreak     = 0x00000020,
    MenuBreak        = 0x00000040,

    Unhilite         = 0x00000000,
    Hilite           = 0x00000080,

    Default          = 0x00001000,
    SystemMenu          = 0x00002000,
    Help             = 0x00004000,
    RightJustify     = 0x00004000,

    MouseSelect      = 0x00008000,
    End              = 0x00000080  /* Obsolete -- only used by old RES files */,
}

[Flags]
public enum MenuTypeFlag : uint
{
    String          = MenuFlag.String,
    Bitmap          = MenuFlag.Bitmap,
    MenuBarBreak    = MenuFlag.MenuBarBreak,
    MenuBreak       = MenuFlag.MenuBreak,
    OwnerDraw       = MenuFlag.OwnerDraw,
    RadioCheck      = 0x00000200,
    Separator       = MenuFlag.Separator,
    RightOrder      = 0x00002000,
    RightJustify    = MenuFlag.RightJustify,
}

[Flags]
public enum MenuStateFlag : uint
{
    /* Menu flags for Add/Check/EnableMenuItem() */
    Grayed          = 0x00000003,
    Disabled        = Grayed,
    Checked         = MenuFlag.Checked,
    Hilite          = MenuFlag.Hilite,
    Enabled         = MenuFlag.Enabled,
    Unchecked       = MenuFlag.Unchecked,
    Unhilite        = MenuFlag.Unhilite,
    Default         = MenuFlag.Default,
}

[Flags]
public enum BroadcastSystemMessageFlag : uint
{
    //Broadcast Special Message Flags
    Query              = 0x00000001,
    IgnoreCurrentTask  = 0x00000002,
    FlushDisk          = 0x00000004,
    NoHang             = 0x00000008,
    PostMessage        = 0x00000010,
    ForceIfHung        = 0x00000020,
    NoTimeoutIfNotHung = 0x00000040,

    AllowSfw           = 0x00000080,
    SendNotifyMessage  = 0x00000100,


    ReturnHDesk        = 0x00000200,
    Luid               = 0x00000400,
}

[Flags]
public enum BradcastSystemMessageRecipient : uint
{
    //Broadcast Special Message Recipient list
    AllComponents      = 0x00000000,
    Vxds               = 0x00000001,
    NetDriver          = 0x00000002,
    InstallableDrivers = 0x00000004,
    Applications       = 0x00000008,
    AllDesktops        = 0x00000010,
}

[Flags]
public enum TrackPopupMenuFlag : uint
{
    LeftButton      = 0x0000,
    RightButton     = 0x0002,
    LeftAlign       = 0x0000,
    CenterAlign     = 0x0004,
    RightAlign      = 0x0008,

    TopAlign        = 0x0000,
    VerticalCenterAlign    = 0x0010,
    BottomAlign     = 0x0020,

    Horizontal      = 0x0000,     /* Horz alignment matters more */
    Vertical        = 0x0040,     /* Vert alignment matters more */
    NoNotify        = 0x0080,     /* Don't send any notification msgs */
    ReturnCmd       = 0x0100,

    Recurse         = 0x0001,
    HorizontalPositiveAnimation = 0x0400,
    HorizontalNegativeAnimation = 0x0800,
    VerticalPositiveAnimation = 0x1000,
    VerticalNegativeAnimation = 0x2000,

    NoAnimation     = 0x4000,

    LayoutRtl       = 0x8000,

    WorkArea        = 0x10000,
}

/// <summary>
/// Field selection bits
/// </summary>
[Flags]
public enum DeviceModeField : uint
{
    Orientation         = 0x00000001,
    PaperSize           = 0x00000002,
    PaperLength         = 0x00000004,
    PaperWidth          = 0x00000008,
    Scale               = 0x00000010,

    Position            = 0x00000020,
    Nup                 = 0x00000040,


    DisplayOrientation  = 0x00000080,

    Copies              = 0x00000100,
    DefaultSource       = 0x00000200,
    PrintQuality        = 0x00000400,
    Color               = 0x00000800,
    Duplex              = 0x00001000,
    YResolution         = 0x00002000,
    /// <summary>
    /// TrueType Options
    /// </summary>
    TrueTypeOption      = 0x00004000,
    Collate             = 0x00008000,
    FormName            = 0x00010000,
    LogPixels           = 0x00020000,
    BitsPerPel          = 0x00040000,
    PelsWidth           = 0x00080000,
    PelsHeight          = 0x00100000,
    DisplayFlags        = 0x00200000,
    DisplayFrequency    = 0x00400000,

    ICMMethod           = 0x00800000,
    ICMIntent           = 0x01000000,
    MediaType           = 0x02000000,
    DitherType          = 0x04000000,
    PanningWidth        = 0x08000000,
    PanningHeight       = 0x10000000,


    DisplayFixedOutput  = 0x20000000,
}

public enum DeviceModeResolution : short
{
    Draft        = (-1),
    Low          = (-2),
    Medium       = (-3),
    High         = (-4),
}

/// <summary>
/// Orientation selections
/// </summary>
public enum DeviceModeOrientation : short
{
    Portrait   = 1,
    Landscape  = 2,
}

/// <summary>
/// Paper selections of DeviceMode
/// 
/// (Use Inch10x14 for DMPAPER_10X11)
/// </summary>
public enum DeviceModePaperSize : short
{
    /* paper selections */
    First              =  Letter,

    /// <summary>
    /// Letter 8 1/2 x 11 in
    /// </summary>
    Letter             =  1,
    /// <summary>
    /// Letter Small 8 1/2 x 11 in
    /// </summary>
    LetterSmall        =  2,
    /// <summary>
    /// Tabloid 11 x 17 in
    /// </summary>
    Tabloid            =  3,
    /// <summary>
    /// Ledger 17 x 11 in
    /// </summary>
    Ledger             =  4,
    Legal              =  5,  /* Legal 8 1/2 x 14 in                */
    Statement          =  6,  /* Statement 5 1/2 x 8 1/2 in         */
    Executive          =  7,  /* Executive 7 1/4 x 10 1/2 in        */
    A3                 =  8,  /* A3 297 x 420 mm                    */
    A4                 =  9,  /* A4 210 x 297 mm                    */
    A4Small            = 10,  /* A4 Small 210 x 297 mm              */
    A5                 = 11,  /* A5 148 x 210 mm                    */
    B4                 = 12,  /* B4 (JIS) 250 x 354                 */
    B5                 = 13,  /* B5 (JIS) 182 x 257 mm              */
    Folio              = 14,  /* Folio 8 1/2 x 13 in                */
    Quarto             = 15,  /* Quarto 215 x 275 mm                */
    Inch10x14              = 16,  /* 10x14 in                           */
    Inch11x17              = 17,  /* 11x17 in                           */
    Note               = 18,  /* Note 8 1/2 x 11 in                 */
    Envelope9              = 19,  /* Envelope #9 3 7/8 x 8 7/8          */
    Envelope10             = 20,  /* Envelope #10 4 1/8 x 9 1/2         */
    Envelope11             = 21,  /* Envelope #11 4 1/2 x 10 3/8        */
    Envelope12             = 22,  /* Envelope #12 4 \276 x 11           */
    Envelope14             = 23,  /* Envelope #14 5 x 11 1/2            */
    CSheet             = 24,  /* C size sheet                       */
    DSheet             = 25,  /* D size sheet                       */
    ESheet             = 26,  /* E size sheet                       */
    EnvelopeDL             = 27,  /* Envelope DL 110 x 220mm            */
    EnvelopeC5             = 28,  /* Envelope C5 162 x 229 mm           */
    EnvelopeC3             = 29,  /* Envelope C3  324 x 458 mm          */
    EnvelopeC4             = 30,  /* Envelope C4  229 x 324 mm          */
    EnvelopeC6             = 31,  /* Envelope C6  114 x 162 mm          */
    EnvelopeC65            = 32,  /* Envelope C65 114 x 229 mm          */
    EnvelopeB4             = 33,  /* Envelope B4  250 x 353 mm          */
    EnvelopeB5             = 34,  /* Envelope B5  176 x 250 mm          */
    EnvelopeB6             = 35,  /* Envelope B6  176 x 125 mm          */
    EnvelopeItaly          = 36,  /* Envelope 110 x 230 mm              */
    EnvelopeMonarch        = 37,  /* Envelope Monarch 3.875 x 7.5 in    */
    EnvelopePersonal       = 38,  /* 6 3/4 Envelope 3 5/8 x 6 1/2 in    */
    FanfoldUS         = 39,  /* US Std Fanfold 14 7/8 x 11 in      */
    FanfoldStdGerman = 40,  /* German Std Fanfold 8 1/2 x 12 in   */
    FanfoldLglGerman = 41,  /* German Legal Fanfold 8 1/2 x 13 in */

    IsoB4             = 42,  /* B4 (ISO) 250 x 353 mm              */
    JapanesePostcard  = 43,  /* Japanese Postcard 100 x 148 mm     */
    Inch9x11               = 44,  /* 9 x 11 in                          */
    Inch10x11              = 45,  /* 10 x 11 in                         */
    Inch15x11              = 46,  /* 15 x 11 in                         */
    EnvelopeInvite         = 47,  /* Envelope Invite 220 x 220 mm       */
    Reserved48        = 48,  /* RESERVED--DO NOT USE               */
    Reserved49        = 49,  /* RESERVED--DO NOT USE               */
    LetterExtra       = 50,  /* Letter Extra 9 \275 x 12 in        */
    LegalExtra        = 51,  /* Legal Extra 9 \275 x 15 in         */
    TabloidExtra      = 52,  /* Tabloid Extra 11.69 x 18 in        */
    A4Extra           = 53,  /* A4 Extra 9.27 x 12.69 in           */
    LetterTransverse  = 54,  /* Letter Transverse 8 \275 x 11 in   */
    A4Transverse      = 55,  /* A4 Transverse 210 x 297 mm         */
    LetterExtraTransverse = 56, /* Letter Extra Transverse 9\275 x 12 in */
    APlus             = 57,  /* SuperA/SuperA/A4 227 x 356 mm      */
    BPlus             = 58,  /* SuperB/SuperB/A3 305 x 487 mm      */
    LetterPlus        = 59,  /* Letter Plus 8.5 x 12.69 in         */
    A4Plus            = 60,  /* A4 Plus 210 x 330 mm               */
    A5Transverse      = 61,  /* A5 Transverse 148 x 210 mm         */
    B5Transverse      = 62,  /* B5 (JIS) Transverse 182 x 257 mm   */
    A3Extra           = 63,  /* A3 Extra 322 x 445 mm              */
    A5Extra           = 64,  /* A5 Extra 174 x 235 mm              */
    B5Extra           = 65,  /* B5 (ISO) Extra 201 x 276 mm        */
    A2                 = 66,  /* A2 420 x 594 mm                    */
    A3Transverse      = 67,  /* A3 Transverse 297 x 420 mm         */
    A3ExtraTransverse= 68,  /* A3 Extra Transverse 322 x 445 mm   */

    DoubleJapanesePostcard = 69, /* Japanese Double Postcard 200 x 148 mm */
    A6                 = 70,  /* A6 105 x 148 mm                 */
    JapaneseEnvelopeKaku2         = 71,  /* Japanese Envelope Kaku #2       */
    JapaneseEnvelopeKaku3         = 72,  /* Japanese Envelope Kaku #3       */
    JapaneseEnvelopeChou3         = 73,  /* Japanese Envelope Chou #3       */
    JapaneseEnvelopeChou4         = 74,  /* Japanese Envelope Chou #4       */
    LetterRotated     = 75,  /* Letter Rotated 11 x 8 1/2 11 in */
    A3Rotated         = 76,  /* A3 Rotated 420 x 297 mm         */
    A4Rotated         = 77,  /* A4 Rotated 297 x 210 mm         */
    A5Rotated         = 78,  /* A5 Rotated 210 x 148 mm         */
    B4JisRotated     = 79,  /* B4 (JIS) Rotated 364 x 257 mm   */
    B5JisRotated     = 80,  /* B5 (JIS) Rotated 257 x 182 mm   */
    JapanesePostcardRotated = 81, /* Japanese Postcard Rotated 148 x 100 mm */
    DoubleJapanesePostcardRotated = 82, /* Double Japanese Postcard Rotated 148 x 200 mm */
    A6Rotated         = 83,  /* A6 Rotated 148 x 105 mm         */
    JapaneseEnvelopeKaku2Rotated = 84,  /* Japanese Envelope Kaku #2 Rotated */
    JapaneseEnvelopeKaku3Rotated = 85,  /* Japanese Envelope Kaku #3 Rotated */
    JapaneseEnvelopeChou3Rotated = 86,  /* Japanese Envelope Chou #3 Rotated */
    JapaneseEnvelopeChou4Rotated = 87,  /* Japanese Envelope Chou #4 Rotated */
    B6Jis             = 88,  /* B6 (JIS) 128 x 182 mm           */
    B6JisRotated     = 89,  /* B6 (JIS) Rotated 182 x 128 mm   */
    Inch12x11              = 90,  /* 12 x 11 in                      */
    JapaneseEnvelopeYou4          = 91,  /* Japanese Envelope You #4        */
    JapaneseEnvelopeYou4Rotated  = 92,  /* Japanese Envelope You #4 Rotated*/
    Chinese16K               = 93,  /* PRC 16K 146 x 215 mm            */
    Chinese32K               = 94,  /* PRC 32K 97 x 151 mm             */
    Chinese32KBIG            = 95,  /* PRC 32K(Big) 97 x 151 mm        */
    ChineseEnvelope1             = 96,  /* PRC Envelope #1 102 x 165 mm    */
    ChineseEnvelope2             = 97,  /* PRC Envelope #2 102 x 176 mm    */
    ChineseEnvelope3             = 98,  /* PRC Envelope #3 125 x 176 mm    */
    ChineseEnvelope4             = 99,  /* PRC Envelope #4 110 x 208 mm    */
    ChineseEnvelope5             = 100, /* PRC Envelope #5 110 x 220 mm    */
    ChineseEnvelope6             = 101, /* PRC Envelope #6 120 x 230 mm    */
    ChineseEnvelope7             = 102, /* PRC Envelope #7 160 x 230 mm    */
    ChineseEnvelope8             = 103, /* PRC Envelope #8 120 x 309 mm    */
    ChineseEnvelope9             = 104, /* PRC Envelope #9 229 x 324 mm    */
    ChineseEnvelope10            = 105, /* PRC Envelope #10 324 x 458 mm   */
    Chinese16KRotated       = 106, /* PRC 16K Rotated                 */
    Chinese32KRotated       = 107, /* PRC 32K Rotated                 */
    Chinese32KBigRotated    = 108, /* PRC 32K(Big) Rotated            */
    ChineseEnvelope1Rotated     = 109, /* PRC Envelope #1 Rotated 165 x 102 mm */
    ChineseEnvelope2Rotated     = 110, /* PRC Envelope #2 Rotated 176 x 102 mm */
    ChineseEnvelope3Rotated     = 111, /* PRC Envelope #3 Rotated 176 x 125 mm */
    ChineseEnvelope4Rotated     = 112, /* PRC Envelope #4 Rotated 208 x 110 mm */
    ChineseEnvelope5Rotated     = 113, /* PRC Envelope #5 Rotated 220 x 110 mm */
    ChineseEnvelope6Rotated     = 114, /* PRC Envelope #6 Rotated 230 x 120 mm */
    ChineseEnvelope7Rotated     = 115, /* PRC Envelope #7 Rotated 230 x 160 mm */
    ChineseEnvelope8Rotated     = 116, /* PRC Envelope #8 Rotated 309 x 120 mm */
    ChineseEnvelope9Rotated     = 117, /* PRC Envelope #9 Rotated 324 x 229 mm */
    ChineseEnvelope10Rotated    = 118, /* PRC Envelope #10 Rotated 458 x 324 mm */

    Last               = ChineseEnvelope10Rotated
}

public enum DeviceModeBin : short
{
    /* bin selections */
    First         = Upper,

    Upper         = 1,
    OnlyOne       = 1,
    Lower         = 2,
    Middle        = 3,
    Manual        = 4,
    Envelope      = 5,
    EnvManual     = 6,    // TODO: 弄清楚这个全称
    Auto          = 7,
    Tractor       = 8,
    SmallFmt      = 9,
    LargeFmt      = 10,
    LargeCapacity = 11,
    Cassette      = 14,
    FormSource    = 15,

    Last          = FormSource,

    User          = 256,     /* device specific bins start here */
}

public enum DeviceModeDisplayOrientation : uint
{
    /* DEVMODE dmDisplayOrientation specifiations */
    Default          = 0,
    Degree90         = 1,
    Degree180        = 2,
    Degree270        = 3,
}

public enum DeviceModeColor : short
{
    /* color enable/disable for color printers */
    MonoChrome  = 1,
    Color       = 2,
}

public enum DeviceModeDisplayFixedOutput : uint
{
    /* DEVMODE dmDisplayFixedOutput specifiations */
    Default   = 0,
    Stretch   = 1,
    Center    = 2,
}

public enum DeviceModeCollation : short
{
    /* Collation selections */
    False  = 0,
    True   = 1,
}

public enum DeviceModeDuplex : short
{
    /* duplex enable */
    Simplex    = 1,
    Vertical   = 2,
    Horizontal = 3,
}

public enum DeviceModeTrueTypeOption : short
{
    /* TrueType options */
    Bitmap             = 1,       /* print TT fonts as graphics */
    Download           = 2,       /* download TT fonts as soft fonts */
    SubstituteDevice   = 3,       /* substitute device fonts for TT fonts */
    DownloadOutline    = 4,       /* download TT fonts as outline soft fonts */
}

public enum DeviceModeDisplayFlag : uint
{
    Grayscale        = 0x00000001, /* This flag is no longer valid */
    Interlaced       = 0x00000002,
    TextMode         = 0x00000004,
}

public enum DeviceModeNup : uint
{
    /* dmNup , multiple logical page per physical page options */
    System     = 1,
    OneUp      = 2,
}

public enum DeviceModeIcmMethod : uint
{
    /* ICM methods */
    None    = 1,   /* ICM disabled */
    System  = 2,   /* ICM handled by system */
    Driver  = 3,   /* ICM handled by driver */
    Device  = 4,   /* ICM handled by device */

    User    = 256,
}

public enum DeviceModeIcmIntent : uint
{
    /* ICM Intents */
    Saturate           = 1,   /* Maximize color saturation */
    Contrast           = 2,   /* Maximize color contrast */
    ColorIMetric       = 3,   /* Use specific color metric */
    AbsColorIMetric    = 4,   /* Use specific color metric */

    User               = 256,   /* Device-specific intents start here */
}

public enum DeviceModeMediaType : uint
{
    /* Media types */

    Standard      = 1,   /* Standard paper */
    Transparency  = 2,   /* Transparency */
    Glossy        = 3,   /* Glossy paper */

    User          = 256,   /* Device-specific media start here */
}

public enum DeviceModeDitherType : uint
{
    /* Dither types */
    None           = 1,      /* No dithering */
    Coarse         = 2,      /* Dither with a coarse brush */
    Fine           = 3,      /* Dither with a fine brush */
    LineArt        = 4,      /* LineArt dithering */
    ErrorDiffusion = 5,      /* LineArt dithering */
    Reserved6      = 6,      /* LineArt dithering */
    Reserved7      = 7,      /* LineArt dithering */
    Reserved8      = 8,      /* LineArt dithering */
    Reserved9      = 9,      /* LineArt dithering */
    Grayscale      = 10,     /* Device does grayscaling */

    User           = 256,   /* Device-specific dithers start here */
}

public enum DisplayChangeResult : int
{
    /* Return values for ChangeDisplaySettings */
    Successful      =  0,
    Restart         =  1,
    Failed          = -1,
    BadMode         = -2,
    NotUpdated      = -3,
    BadFlags        = -4,
    BadParam        = -5,
    BadDualView     = -6,
}

/// <summary>
/// Flags for ChangeDisplaySettings
/// </summary>
public enum ChangeDisplaySettingsFlag : uint
{
    UpdateRegistry           = 0x00000001,
    Test                     = 0x00000002,
    FullScreen               = 0x00000004,
    Global                   = 0x00000008,
    SetPrimary               = 0x00000010,
    VideoParameters          = 0x00000020,
    EnableUnsafeModes        = 0x00000100,
    DisableUnsafeModes       = 0x00000200,
    Reset                    = 0x40000000,
    ResetExtened             = 0x20000000,
    NoReset                  = 0x10000000,
}

public enum VideoParametersFlag : uint
{
    TvMode         = 0x0001,
    TvStandard     = 0x0002,
    Flicker        = 0x0004,
    Overscan       = 0x0008,
    MaxUnscaled    = 0x0010,   // do not use on SET
    Position       = 0x0020,
    Brightness     = 0x0040,
    Contrast       = 0x0080,
    CopyProtect    = 0x0100,
}

public enum VideoParametersCommand : uint
{
    Get          = 0x0001,  // size set, return caps.
    // returned Flags = 0 if not supported.
    Set          = 0x0002,  // size and params set.
}

public enum VideoParametersMode : uint
{
    /// <summary>
    /// WIN_GRAPHICS
    /// </summary>
    WinGraphics    = 0x0001,
    TvPlayback     = 0x0002,  // optimize for TV video playback
}

public enum VideoParametersTvStandard : uint
{
    NtscM   = 0x0001,  //        75 IRE Setup
    NtscMJ  = 0x0002,  // Japan,  0 IRE Setup
    PalB    = 0x0004,
    PalD    = 0x0008,
    PalH    = 0x0010,
    PalI    = 0x0020,
    PalM    = 0x0040,
    PalN    = 0x0080,
    SecamB  = 0x0100,
    SecamD  = 0x0200,
    SecamG  = 0x0400,
    SecamH  = 0x0800,
    SecamK  = 0x1000,
    SecamK1 = 0x2000,
    SecamL  = 0x4000,
    WinVga  = 0x8000,
    // and the rest
    Ntsc433 = 0x00010000,
    PalG    = 0x00020000,
    Pal60   = 0x00040000,
    SecamL1 = 0x00080000,
}

public enum VideoParametersCopyProtectionType : uint
{
    ApsTrigger   = 0x0001,  // DVD trigger bits only
    Macrovision  = 0x0002,  // full macrovision data available
}

public enum VideoParametersCopyProtectionCommand : uint
{
    Activate      = 0x0001,  // CP command type
    Deactivate    = 0x0002,
    Change        = 0x0004,
}

public enum MessageFilterFlag : uint
{
    Add     = 1,
    Remove  = 2
}

/// <summary>
/// Message filter info values (CHANGEFILTERSTRUCT.ExtStatus)
/// </summary>
public enum MessageFilterInfo : uint
{
    None                           = (0),
    AlreadyAllowedForWindow        = (1),
    AlreadyDisallowedForWindow     = (2),
    AllowedHigher                  = (3),
}

/// <summary>
/// CodePage parameter for <see cref="NativeMethodsAnsi.CharNextExA(ushort, byte*, uint)"/>
/// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charnextexa?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(WINUSER%252FCharNextExA)%3Bk(CharNextExA)%3Bk(DevLang-C%252B%252B)%3Bk(TargetOS-Windows)%26rd%3Dtrue#parameters
/// </summary>
public enum CodePage : ushort
{
    /// <summary>
    /// ANSICP
    /// </summary>
    Ansi      = 0,
    Macintosh = 2,
    Oem       = 1,
}

public enum ButtonState : uint
{
    Unchecked      = 0x0000,
    Checked        = 0x0001,
    Indeterminate  = 0x0002,
    Pushed         = 0x0004,
    Focus          = 0x0008,
}

public enum ChildWindowFromPointFlags : uint
{
    All               = 0x0000,
    SkipInvisible     = 0x0001,
    SkipDisabled      = 0x0002,
    SkipTransparent   = 0x0004,
}

public enum AcceleratorModifier : byte
{
    /*
     * Defines for the fVirt field of the Accelerator table structure.
     */
    VirtualKey   = 0x01,          /* Assumed to be == TRUE */
    NoInvert     = 0x02,
    Shift        = 0x04,
    Control      = 0x08,
    Alt          = 0x10,
}

public enum ShowWindowCommand : int
{
    Hide            = 0,
    ShowNormal      = 1,
    Normal          = 1,
    ShowMinimized   = 2,
    ShowMaximized   = 3,
    Maximize        = 3,
    ShowNoActivate  = 4,
    Show            = 5,
    Minimize        = 6,
    ShowMinNoActive = 7,
    ShowNA          = 8,
    Restore         = 9,
    ShowDefault     = 10,
    ForceMinimize   = 11,
}

public enum ImageType : uint
{
    Bitmap = 0,
    Icon   = 1,
    Cursor = 2,
    EnhMetafile = 3,
}

// TODO: what's the name
public enum LR : uint
{
    DefaultColor     = 0x00000000,
    MonoChrome       = 0x00000001,
    Color            = 0x00000002,
    CopyReturnOrg    = 0x00000004,
    CopyDeleteOrg    = 0x00000008,
    LoadFromFile     = 0x00000010,
    LoadTransparent  = 0x00000020,
    DefaultSize      = 0x00000040,
    VgaColor         = 0x00000080,
    LoadMap3DColors  = 0x00001000,
    CreateDibsection = 0x00002000,
    CopyFromResource = 0x00004000,
    Shared           = 0x00008000,
}

public enum DesktopControlFlags : uint
{
    None                     = 0x0000,
    AllowOtherAccountHook    = 0x0001,
}
