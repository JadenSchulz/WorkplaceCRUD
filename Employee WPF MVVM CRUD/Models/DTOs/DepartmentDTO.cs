using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Models.DTOs
{
    internal class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
