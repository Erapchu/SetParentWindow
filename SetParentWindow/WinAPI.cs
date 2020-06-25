using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SetParentWindow
{
    public static class WinAPI
    {
        public const uint SWP_NOZORDER = 0x0004;
        public const int SW_SHOW = 5;
        public const int SW_HIDE = 0;
        public const int GWL_STYLE = -16;
        /// <summary>
        /// Pop-up window style
        /// </summary>
        public const UInt32 WS_POPUP = 0x80000000;

        /// <summary>
        /// Overlapped window style (for example: main window of application)
        /// </summary>
        public const UInt32 WS_OVERLAPPEDWINDOW = 0x00CF0000;

        /// <summary>
        /// Child window style
        /// </summary>
        public const UInt32 WS_CHILD = 0x40000000;

        public static string GetWindowTitle(IntPtr hWnd)
        {
            var length = GetWindowTextLength(hWnd) + 1;
            var title = new StringBuilder(length);
            GetWindowText(hWnd, title, length);
            return title.ToString();
        }

        public static void SetChildWindowStyle(IntPtr windowHWND)
        {
            var style = GetWindowLong(windowHWND, GWL_STYLE);
            style &= ~WS_POPUP;
            style &= ~WS_OVERLAPPEDWINDOW;
            style |= WS_CHILD;
            SetWindowLong(windowHWND, GWL_STYLE, style);
        }

        [DllImport("user32.dll")]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern uint SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
        /// <summary>
        /// Set a new parent for the given window handle
        /// </summary>
        /// <param name="hWndChild">The handle of the target window</param>
        /// <param name="hWndNewParent">The window handle of the parent window</param>
        [DllImport("user32", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
