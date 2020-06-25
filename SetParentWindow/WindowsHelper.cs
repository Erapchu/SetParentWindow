using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace SetParentWindow
{
    public static class WindowsHelper
    {
        public static IntPtr GetHandle(this Window window)
        {
            try
            {
                var handle = new WindowInteropHelper(window).EnsureHandle();
                return handle;
            }
            catch
            {
                return IntPtr.Zero;
            }
        }
    }
}
