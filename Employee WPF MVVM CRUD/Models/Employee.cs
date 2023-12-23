using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Models
{
    public enum Gender
    {
        F,
        M
    }
    internal class Employee
    {
        public long EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Employed { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public string Title { set; get; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public List<Department> WorksIn { get; set; }
        public List<Department> Manages { get; set; }
        public List<EmploymentRecord>? EmploymentHistory { get; set; }
        public List<ManagementRecord>? ManagementHistory { get; set; }
        public List<SalaryRecord>? SalaryHistory { get; set; }
        public List<TitleRecord>? TitleHistory { get; set; }

        public Employee(
            long employeeNumber, 
            string firstName, 
            string lastName, 
            bool employed, 
            Gender gender, 
            int salary, 
            string title, 
            DateTime birthDate, 
            DateTime hireDate, 
            List<Department> worksIn, 
            List<Department> manages, 
            List<EmploymentRecord>? employmentHistory, 
            List<ManagementRecord>? managementHistory, 
            List<SalaryRecord>? salaryHistory, 
            List<TitleRecord>? titleHistory)
        {
            EmployeeNumber = employeeNumber;
            FirstName = firstName;
            LastName = lastName;
            Employed = employed;
            Gender = gender;
            Salary = salary;
            Title = title;
            BirthDate = birthDate;
            HireDate = hireDate;
            WorksIn = worksIn;
            Manages = manages;
        }

        public override string ToString()
        {
            return $"{FirstName} + {LastName}";
        }
    }
}
