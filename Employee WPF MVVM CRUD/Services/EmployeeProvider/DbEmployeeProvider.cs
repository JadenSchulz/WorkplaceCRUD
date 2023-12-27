using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Models.DAOs;
using Employee_WPF_MVVM_CRUD.Models.DTOs;
using Employee_WPF_MVVM_CRUD.Services.DAOs;
using Employee_WPF_MVVM_CRUD.Services.DbConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.EmployeeProvider
{
    internal class DbEmployeeProvider : IEmployeeProvider
    {
        private readonly DbConnectorFactory _dbConnectorFactory;
        
        public DbEmployeeProvider(DbConnectorFactory dbConnectorFactory)
        {
            _dbConnectorFactory = dbConnectorFactory;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            EmployeeDao employeeDao = new EmployeeDao(_dbConnectorFactory);
            DepartmentDAO departmentDao = new DepartmentDAO(_dbConnectorFactory);


            List <EmployeeDTO> EmployeeDTOs = employeeDao.GetAll();
            List <DepartmentDTO> departmentDTOs = departmentDao.GetAll();

            List<Department> departments = departmentDTOs.Select(ToDepartment).ToList();

            foreach (EmployeeDTO dto in EmployeeDTOs)
            {
                Department? department = departments.FirstOrDefault(x => x.Id == dto.DepartmentId);
                employees.Add(ToEmployee(dto, department));
            }

            return employees;

        }

        private Department ToDepartment(DepartmentDTO dto)
        {
             return new Department(dto.Id, dto.Name);
        }
        private Employee ToEmployee(EmployeeDTO dto, Department? department)
        {
            return new Employee(dto.EmployeeNumber, dto.FirstName, dto.LastName, dto.Gender, dto.Salary, department, dto.Title, dto.BirthDate, dto.HireDate);
        }
    }
}
