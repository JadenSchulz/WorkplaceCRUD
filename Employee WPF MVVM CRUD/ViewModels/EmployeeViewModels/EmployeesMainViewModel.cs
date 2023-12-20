using Employee_WPF_MVVM_CRUD.Commands;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels
{
    internal class EmployeesMainViewModel : BaseViewModel
    {
        private readonly NavigationStore _parentNavigationStore;
        private readonly ViewModelFactory _viewModelFactory;
        private readonly NavigationStore _employeesNavigationStore;

        public EmployeesMainViewModel(NavigationStore navigationStore, ViewModelFactory viewModelFactory)
        {
            _parentNavigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _employeesNavigationStore = new NavigationStore();
        }
        
    }
}
