using Employee_WPF_MVVM_CRUD.Models;
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
            EmployeeDao dao = new EmployeeDao(_dbConnectorFactory);
            List <EmployeeDTO> dtos = dao.GetAll();

            foreach (EmployeeDTO dto in dtos)
            {
                employees.Add(ToEmployee(dto));
            }

            return employees;

        }

        private Employee ToEmployee(EmployeeDTO dto)
        {
            return new Employee(dto.EmployeeNumber, dto.FirstName, dto.LastName, dto.Gender, dto.Salary, dto.DepartmentId, dto.Title, dto.BirthDate, dto.HireDate);
        }
    }
}
