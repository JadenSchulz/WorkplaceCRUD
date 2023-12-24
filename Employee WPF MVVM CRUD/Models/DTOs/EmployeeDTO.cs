using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Models.DTOs
{
    internal class EmployeeDTO
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public EmployeeDTO(int employeeNumber, string firstName, string lastName, Gender gender, DateTime birthDate, DateTime hireDate)
        {
            EmployeeNumber = employeeNumber;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            HireDate = hireDate;
        }   
    }
}
