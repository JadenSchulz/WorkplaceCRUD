using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Sources
{
    internal class EmployeesSource : ObservableCollection<EmployeeViewModel>
    {
        public EmployeesSource(List<Employee> employees) :
            base(employees
                .Select(employee => new EmployeeViewModel(employee))
                .ToList()) { }
    }
}
