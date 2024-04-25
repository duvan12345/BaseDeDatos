using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace BD
{

    // Use el modificador abstract en una declaración de clase para indicar que una clase está diseñada
    // como clase base de otras clases, no para crear instancias por sí misma. Los miembros marcados como
    // abstractos deben implementarse con clases no abstractas derivadas de la clase abstracta.

    public abstract class DB
    {
        private string _connectionstring;

        protected SqlConnection _connection;

        public DB(string server, string db, string user, string password)
        {
            _connectionstring = $"Data Source={server}; Initial Catalog={db};" +
                $"User={user};Password={password}";

        }

        // metodo 
        public void Connect()
        {
            _connection = new SqlConnection(_connectionstring);
            _connection.Open();
        }

        public void Close()
        {
            if(_connection != null && _connection.State == System.Data.ConnectionState.Open) 
            _connection.Close();
        }

    }
}
