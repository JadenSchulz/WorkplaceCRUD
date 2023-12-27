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
    internal class DepartmentsSource : ObservableCollection<DepartmentViewModel>
    {
        public DepartmentsSource(List<Department> departments) 
            : base(departments
               .Select(department => new DepartmentViewModel(department))
               .ToList()) { }
    }
}
