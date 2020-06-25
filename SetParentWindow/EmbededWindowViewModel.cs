using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetParentWindow
{
    public class EmbededWindowViewModel : ViewModelBase
    {
        public IntPtr WindowHandle { get; }
        public string Title { get; }

        public void Show()
        {
            WinAPI.ShowWindow(WindowHandle, WinAPI.SW_SHOW);
        }

        public void Hide()
        {
            WinAPI.ShowWindow(WindowHandle, WinAPI.SW_HIDE);
        }

        public EmbededWindowViewModel(IntPtr windowHandle)
        {
            WindowHandle = windowHandle;
            Title = WinAPI.GetWindowTitle(WindowHandle);
            WinAPI.SetChildWindowStyle(WindowHandle);
        }
    }
}
