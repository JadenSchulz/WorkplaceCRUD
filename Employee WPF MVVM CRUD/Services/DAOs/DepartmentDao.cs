using Employee_WPF_MVVM_CRUD.Models.DTOs;
using Employee_WPF_MVVM_CRUD.Services.DbConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Employee_WPF_MVVM_CRUD.Models.DAOs
{
    internal class DepartmentDao
    {
        private readonly DbConnectorFactory _dbConnectorFactory;

        public DepartmentDao(DbConnectorFactory dbConnectorFactory)
        {
            _dbConnectorFactory = dbConnectorFactory;
        }
        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public DepartmentDTO? GetById(int id)
        {
            DepartmentDTO? departmentDTO = null;
            string query = $"SELECT * FROM departments WHERE dept_no={id};";

            DbConnector dbConnector = _dbConnectorFactory.CreateDbConnector();
            List<Dictionary<string, object>> departmentData = dbConnector.Query(query);

            if (departmentData.Count == 0) return departmentDTO;

            var department = departmentData[0];
            departmentDTO = new DepartmentDTO(
                (int)department["dept_no"],
                (string)department["dept_name"]
                    );

            return departmentDTO;
        }
        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
