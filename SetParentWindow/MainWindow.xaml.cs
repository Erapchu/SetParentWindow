using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SetParentWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Window> _embededWindows = new List<Window>();
        private readonly IntPtr _mainWindowHandle;
        private int _offset = 22;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowHandle = this.GetHandle();

            _embededWindows.Add(new TestWindow("test1"));
            _embededWindows.Add(new TestWindow("test2"));

            var tempHandleList = new List<EmbededWindowViewModel>();
            _embededWindows.ForEach(w => tempHandleList.Add(new EmbededWindowViewModel(w.GetHandle())));

            DataContext = new MainWindowViewModel(tempHandleList);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var window in _embededWindows)
            {
                window.Show();
                EmbedWindow(window.GetHandle());
            }
        }

        public void EmbedWindow(IntPtr embeddingWindowHandle)
        {
            WinAPI.SetParent(embeddingWindowHandle, _mainWindowHandle);
            WinAPI.SetWindowPos(embeddingWindowHandle, IntPtr.Zero, 0, _offset, (int)Width, (int)Height - _offset, WinAPI.SWP_NOZORDER);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var embededWindow in _embededWindows)
            {
                var embededWindowHandle = embededWindow.GetHandle();
                WinAPI.SetWindowPos(embededWindowHandle, IntPtr.Zero, 0, _offset, (int)Width, (int)Height - _offset, WinAPI.SWP_NOZORDER);
            }
        }
    }
}
