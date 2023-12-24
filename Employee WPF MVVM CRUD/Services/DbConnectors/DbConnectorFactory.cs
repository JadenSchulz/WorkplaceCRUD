using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.DbConnectors
{
    internal class DbConnectorFactory
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string DbName { get; set; }
        public string ConnectionString
        {
            get { return $"server={Hostname};port={Port};user id={UserId};password={Password};database={DbName}"; }
        }
        public DbConnectorFactory(string hostname, int port, string userId, string password, string dbName)
        {
            Hostname = hostname;
            Port = port;
            UserId = userId;
            Password = password;
            DbName = dbName;
        }

        public DbConnector CreateDbConnector()
        {
            return new DbConnector(ConnectionString);
        }



    }
}
