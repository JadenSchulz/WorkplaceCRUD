using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Services.EmployeeProvider;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Items;
using Employee_WPF_MVVM_CRUD.ViewModels.Sources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels
{
    internal class EmployeeListingViewModel : BaseViewModel
    {
        private readonly IEmployeeProvider _employeeProvider;
        private readonly EmployeesSource _employees;
        public IEnumerable<EmployeeViewModel> Employees => _employees;
        public EmployeeListingViewModel(IEmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
            _employees = new EmployeesSource(employeeProvider.GetAllEmployees());
        }
    }
}
