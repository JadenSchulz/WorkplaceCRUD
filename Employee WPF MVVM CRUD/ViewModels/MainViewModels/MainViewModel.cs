using Employee_WPF_MVVM_CRUD.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.MainViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        private MenuViewModel _menu;
        public MenuViewModel Menu
        {
            get { return _menu; }
            set { ChangeBoundProperty(ref _menu, value); }
        }

        private StatusBarViewModel _statusBar;
        public StatusBarViewModel StatusBar
        {
            get { return _statusBar; }
            set { ChangeBoundProperty(ref _statusBar, value); }
        }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
            Menu = new MenuViewModel();
            StatusBar = new StatusBarViewModel();
        }
    }
}
