using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace InmobiliariaDataLayer.Connection
{
    public class PostConnection
    {
        public static NpgsqlConnection Connection()
        {
            string dbString = "Server=192.168.1.10; Port=5432; Database=testinmobiliaria; User Id=postgres;" +
                            "Password = ynwa1234; ";

            return new NpgsqlConnection(dbString);
        }
        
        public NpgsqlCommand Command(string query)
        {
            return new NpgsqlCommand(query);
        }

        public void Command(NpgsqlCommand command)
        {
            using (var connection = Connection())
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    Console.WriteLine("Sentencia Sql Ejecutada Con Exito");
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
        }
    }
}
