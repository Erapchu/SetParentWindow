using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Interop;

namespace SetParentWindow
{
    class MainWindowViewModel : ViewModelBase
    {
        private static readonly Lazy<MainWindowViewModel> _lazyDesignTime = new Lazy<MainWindowViewModel>(() => new MainWindowViewModel());
        public static MainWindowViewModel DesignTimeInstance => _lazyDesignTime.Value;

        public ObservableCollection<EmbededWindowViewModel> EmbededWindows { get; }

        private EmbededWindowViewModel _selectedWindow;
        public EmbededWindowViewModel SelectedWindow
        {
            get => _selectedWindow;
            set
            {
                if (_selectedWindow == value)
                    return;

                if (_selectedWindow != null)
                    _selectedWindow.Hide();

                _selectedWindow = value;
                RaisePropertyChanged();
                _selectedWindow.Show();
            }
        }

        private MainWindowViewModel()
        {
        }

        public MainWindowViewModel(List<EmbededWindowViewModel> tempHandleList)
        {
            EmbededWindows = new ObservableCollection<EmbededWindowViewModel>(tempHandleList);
            SelectedWindow = tempHandleList.LastOrDefault();
        }
    }
}
