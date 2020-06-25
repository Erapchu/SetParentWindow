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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SetParentWindow
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private readonly string _text;

        public TestWindow(string text)
        {
            InitializeComponent();
            _text = text;
            textElement.Text = _text;
            Title = _text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
