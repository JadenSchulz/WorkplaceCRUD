using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Models
{
    internal class Department : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Employee>? Managers { get; set; }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object? obj)
        {
            return Name.CompareTo(obj);
        }
    }
}
