using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.DbConnectors
{
    internal class DbConnector
    {
        private readonly string _connectionString;
        public DbConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Dictionary<string, object>> Query(string query)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            MySqlConnection connection = new MySqlConnection(_connectionString);

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                int rowCount = 0;
                while (reader.Read()) 
                { 
                    Dictionary<string, object> rowData = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowData[reader.GetName(i)] = reader.GetValue(i);
                    }
                    results.Add(rowData);
                    rowCount++;
                }
            }

            connection.Close();

            return results;
        }

        public long Manipulate(string commandString)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            long id = -1;

            connection.Open();
            MySqlCommand command = new MySqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            id = command.LastInsertedId;

            connection.Close();

            return id;
        }
    }
}
