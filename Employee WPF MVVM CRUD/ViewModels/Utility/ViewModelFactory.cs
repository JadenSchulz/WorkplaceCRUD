using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.DepartmentViewModels;
using Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels;
using Employee_WPF_MVVM_CRUD.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Utility
{
    internal class ViewModelFactory
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelFactory(NavigationStore navigationStore) 
        { 
            _navigationStore = navigationStore;
        }

        public BaseViewModel CreateLandingViewModel()
        {
            return new LandingViewModel(_navigationStore, this);
        }

        public BaseViewModel CreateEmployeesViewModel()
        {
            return new EmployeesMainViewModel(_navigationStore, this);
        }
        public BaseViewModel CreateDepartmentsViewModel()
        {
            return new DepartmentsMainViewModel(_navigationStore, this);
        }
    }
}
