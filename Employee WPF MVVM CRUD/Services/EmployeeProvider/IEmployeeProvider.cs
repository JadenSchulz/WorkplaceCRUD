using Employee_WPF_MVVM_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.EmployeeProvider
{
    internal interface IEmployeeProvider
    {
        public List<Employee> GetAllEmployees();
    }
}
