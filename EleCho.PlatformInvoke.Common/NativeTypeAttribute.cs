using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.PlatformInvoke
{
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter | AttributeTargets.Struct | AttributeTargets.Delegate, Inherited = false, AllowMultiple = false)]
    public sealed class NativeTypeAttribute : Attribute
    {
        public NativeTypeAttribute(string type)
        {
            TypeName = type;
        }

        public string TypeName { get; }
    }
}
