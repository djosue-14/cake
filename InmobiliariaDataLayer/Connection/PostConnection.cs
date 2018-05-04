using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace InmobiliariaDataLayer.Connection
{
    public class PostConnection
    {
        public static NpgsqlConnection Connection()
        {
            //string dbString = "Server=127.0.0.1; Port=5432; Database=TestInmobiliaria; User Id=postgres;" +
            //              "Password = ynwa1234; ";

            string dbString = "Server=127.0.0.1; Port=5432; Database=prueba; User Id=postgres;" +
                          "Password = reynoso; ";

            return new NpgsqlConnection(dbString);
        }
        
        public NpgsqlCommand Command(string query)
        {
            return new NpgsqlCommand(query);
        }

        public int Command(NpgsqlCommand command)
        {
            int estado = -1;
            using (var connection = Connection())
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    estado = command.ExecuteNonQuery();
                    //Console.WriteLine("Sentencia Sql Ejecutada Con Exito");
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return estado;
        }
    }
}