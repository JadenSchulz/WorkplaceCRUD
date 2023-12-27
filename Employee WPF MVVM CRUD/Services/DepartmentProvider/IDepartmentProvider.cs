using Employee_WPF_MVVM_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.DepartmentProvider
{
    internal interface IDepartmentProvider
    {
        public List<Department> GetAllDepartments();
    }
}
