namespace EleCho.PlatformInvoke.Common
{
    public static class Utils
    {
        public static unsafe Span<T> NewSpanByReference<T>(ref T value, int length) where T : unmanaged
        {
            fixed (void* p = &value)
            {
                return new(p, length);
            }
        }
    }
}
