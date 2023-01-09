using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.PlatformInvoke.Windows
{

    [StructLayout(LayoutKind.Sequential, Size = 32)]
    struct PlaceholderByte32 { }

    [StructLayout(LayoutKind.Sequential, Size = 64)]
    struct PlaceholderByte64 { }
}
