using BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{ 
    //Heredar de la clase db
    public class BeerDB : DB
    {
        public BeerDB(string server, string db, string user, string pasword) : base(server, db, user, pasword)
        {

         
        }
        // metodo para hacer el llamado 

        public List<Beer> GetAll()
        {
            Connect();
            List<Beer> beers = new List<Beer>();
            string query = "SELECT Id,Name,BrandId  FROM Beer";
            //SqlCommand = Representa un procedimiento almacenado o una instrucción de Transact-SQL que se ejecuta en
            //una base de datos de SQL Server. Esta clase no puede heredarse.
            SqlCommand command = new  SqlCommand(query, _connection);

            // SqlDataReader = Ofrece una manera de leer un flujo de filas de solo avance desde una base de datos de SQL Server.Esta clase no puede heredarse.
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int BrandID = reader.GetInt32(2);
                //var beer = new  Beer(id,name, brandId)= objeto
                //traer la informacion
                beers.Add(new Beer(id, name, BrandID)); // beers.Add(beer)
            }
            
            Close();

            return beers;
        }

        //metodo donde nos trae solo un metodo
        public Beer Get(int id)
        {
            Connect();
            //un objeto 
            Beer beer = null;
            string query = "SELECT Id, Name, BrandId  FROM Beer " +
                "WHERE id = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);

            //sqldataadapter= vamos a poder leer los resultado
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                string name = reader.GetString(1);
                int brandId= reader.GetInt32(2);

                beer = new Beer(id, name, brandId);
            }
            Close();
            return beer;
        }


        //Metodo para agregar 

        public void Add(Beer beer)
        {
            Connect();
            List<Beer> beers = new List<Beer>();
            string query = "insert into Beer(name,BrandID) " +
                "values(@name,@brandId)";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandID);


            //ExecuteNonQuery() = Ejecuta una instrucción Transact-SQL en la conexión y devuelve el número de filas afectadas.
            command.ExecuteNonQuery();
            Close();

        }

        //metodo editar

        public void Edit(Beer beer)
        {
            Connect();

            string query = "UPDATE beer SET name=@name, brandId=@brandId " +
                "where id=@id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandID);
            command.Parameters.AddWithValue("@id", beer.Id);
            command.ExecuteNonQuery();

            Close();
        }

        //metodo para eliminar 

        public void Delete(int id)
        {
            Connect();

            string query = "delete from Beer where id=@id";
              
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            Close();
        }

    }
}
