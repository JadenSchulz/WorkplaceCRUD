﻿using System;
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
        
    }
}