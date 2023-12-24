using Employee_WPF_MVVM_CRUD.Services.DbConnectors;
using Employee_WPF_MVVM_CRUD.Services.EmployeeProvider;
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
        private readonly DbConnectorFactory _dbConnectorFactory;

        private readonly IEmployeeProvider _employeeProvider;
        public App()
        {
            _navigationStore = new NavigationStore();
            _dbConnectorFactory = new DbConnectorFactory("127.0.0.1", 3306, "root", "Pwd12345", "employees");
            _employeeProvider = new DbEmployeeProvider(_dbConnectorFactory);

            _viewModelFactory = new ViewModelFactory(_navigationStore, _employeeProvider);
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
