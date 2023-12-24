using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Models.DTOs;
using Employee_WPF_MVVM_CRUD.Services.DbConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.DAOs
{
    internal class EmployeeDao
    {
        private readonly DbConnectorFactory _dbConnectorFactory;

        public EmployeeDao(DbConnectorFactory dbConnectorFactory)
        {
            _dbConnectorFactory = dbConnectorFactory;
        }

        public List<EmployeeDTO> GetAll()
        {

            List<EmployeeDTO> employees = new List<EmployeeDTO>(); 
            string query = "SELECT * FROM curr_employee_data LIMIT 250;";

            DbConnector dbConnector = _dbConnectorFactory.CreateDbConnector();
            List<Dictionary<string, object>> employeeData = dbConnector.Query(query);

            foreach (var employee in employeeData)
            {
                employees.Add(new EmployeeDTO(
                    (int)employee["emp_no"],
                    (string)employee["first_name"],
                    (string)employee["last_name"],
                    (Gender)Enum.Parse(typeof(Gender), (string)employee["gender"]),
                    (int)employee["salary"],
                    (int)employee["dept_no"],
                    (string)employee["title"],
                    (DateTime)employee["birth_date"],
                    (DateTime)employee["hire_date"]
                    ));
            }

            return employees;


        }
        public EmployeeDTO? GetById(int id, int first, int last)
        {
            EmployeeDTO? employeeDTO = null;
            string query = $"SELECT * FROM employees WHERE emp_no={id} LIMIT {first}, {last};";

            DbConnector dbConnector = _dbConnectorFactory.CreateDbConnector();
            List<Dictionary<string, object>> employeeData = dbConnector.Query(query);

            if (employeeData.Count == 0) return employeeDTO;

            var employee = employeeData[0];
            employeeDTO = new EmployeeDTO(
                    (int)employee["emp_no"],
                    (string)employee["first_name"],
                    (string)employee["last_name"],
                    (Gender)employee["gender"],
                    (int)employee["salary"],
                    (int)employee["dept_no"],
                    (string)employee["title"],
                    (DateTime)employee["birth_date"],
                    (DateTime)employee["hire_date"]
                    );

            return employeeDTO;
        }
        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
