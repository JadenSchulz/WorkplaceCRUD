using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.DepartmentViewModels
{
    internal class DepartmentsMainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelFactory _viewModelFactory;
        public DepartmentsMainViewModel(NavigationStore navigationStore, ViewModelFactory viewModelFactory)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
        }
    }
}
