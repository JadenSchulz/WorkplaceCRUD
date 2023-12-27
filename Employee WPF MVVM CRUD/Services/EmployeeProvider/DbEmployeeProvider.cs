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
            DepartmentDao departmentDao = new DepartmentDao(_dbConnectorFactory);
            List <EmployeeDTO> dtos = employeeDao.GetAll();

            foreach (EmployeeDTO dto in dtos)
            {

                DepartmentDTO? departmentDTO = departmentDao.GetById(dto.DepartmentId);
                Department? department = ToDepartment(departmentDTO);
                employees.Add(ToEmployee(dto, department));
            }

            return employees;

        }

        private Department? ToDepartment(DepartmentDTO? dto)
        {
            if (dto == null) return null;
            else return new Department(dto.Id, dto.Name);
        }
        private Employee ToEmployee(EmployeeDTO dto, Department? department)
        {

            return new Employee(dto.EmployeeNumber, dto.FirstName, dto.LastName, dto.Gender, dto.Salary, department, dto.Title, dto.BirthDate, dto.HireDate);
        }
    }
}
