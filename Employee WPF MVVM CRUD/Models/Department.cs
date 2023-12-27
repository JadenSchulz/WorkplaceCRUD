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

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            var dept = obj as Department;
            if (dept == null) return false;

            if (dept.Id != Id) return false;  
            if (dept.Name != Name) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
