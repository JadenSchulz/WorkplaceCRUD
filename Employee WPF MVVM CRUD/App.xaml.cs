using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels;
using Employee_WPF_MVVM_CRUD.ViewModels.MainViewModels;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_WPF_MVVM_CRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelFactory _viewModelFactory;
        public App()
        {
            _navigationStore = new NavigationStore();
            _viewModelFactory = new ViewModelFactory(_navigationStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory.CreateLandingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
