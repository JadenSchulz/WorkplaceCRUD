using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Models.DAOs;
using Employee_WPF_MVVM_CRUD.Models.DTOs;
using Employee_WPF_MVVM_CRUD.Services.DbConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.DepartmentProvider
{
    internal class DbDepartmentProvider : IDepartmentProvider
    {
        private readonly DbConnectorFactory _dbConnectorFactory;

        public DbDepartmentProvider(DbConnectorFactory dbConnectorFactory)
        {
            _dbConnectorFactory = dbConnectorFactory;
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            DepartmentDAO departmentDAO = new DepartmentDAO(_dbConnectorFactory);
            
            List<DepartmentDTO> departmentDTOs = departmentDAO.GetAll();
            departments = departmentDTOs.Select(ToDepartment).ToList();

            return departments;
        }

        private Department ToDepartment(DepartmentDTO dto)
        {
            return new Department(dto.Id, dto.Name);
        }
    }
}
