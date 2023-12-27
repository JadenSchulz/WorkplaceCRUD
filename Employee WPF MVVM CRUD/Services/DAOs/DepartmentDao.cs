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
    internal class DepartmentDAO
    {
        private readonly DbConnectorFactory _dbConnectorFactory;

        public DepartmentDAO(DbConnectorFactory dbConnectorFactory)
        {
            _dbConnectorFactory = dbConnectorFactory;
        }
        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>();
            string query = $"SELECT * FROM departments;";

            DbConnector dbConnector = _dbConnectorFactory.CreateDbConnector();
            List<Dictionary<string, object>> departmentData = dbConnector.Query(query);

            if (departmentData.Count == 0) return departmentDTOs;

            foreach (var department in departmentData)
            {
                departmentDTOs.Add(new DepartmentDTO(
                (int)department["dept_no"],
                (string)department["dept_name"]
                    ));
            }
            return departmentDTOs;
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
