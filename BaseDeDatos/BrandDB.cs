using BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public  class BrandDB : DB
    {
        public BrandDB(string server, string db, string user, string pasword) : base(server, db, user, pasword)
        {

        }


        public List<Brand> GetAllBrand()
        {
            Connect();
            List<Brand> brands = new List<Brand>();
            string query2 = "SELECT Id,Name FROM Brand";
            //SqlCommand = Representa un procedimiento almacenado o una instrucción de Transact-SQL que se ejecuta en
            //una base de datos de SQL Server. Esta clase no puede heredarse.
            SqlCommand command2 = new SqlCommand(query2, _connection);

            // SqlDataReader = Ofrece una manera de leer un flujo de filas de solo avance desde una base de datos de SQL Server.Esta clase no puede heredarse.
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                brands.Add(new Brand(id, name));

            }



            Close();

            return brands;
        }
    }
}
