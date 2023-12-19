using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Models
{
    internal class Department
    {
        public long DepartmentNumber { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Employee> Managers { get; set; }
    }
}
