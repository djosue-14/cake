using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;

namespace InmobiliariaDataLayer.Cuenta
{
    public class Financiamiento//: ISqlPersistence
    {
        private PostConnection db;

        public Financiamiento()
        {
            db = new PostConnection();
        }

        public void testPost()
        {
            string query = "INSERT INTO venta VALUES(null, @total, now())";

            var command = db.Command(query);
            //command.Parameters.AddWithValue("0", "null");
            command.Parameters.AddWithValue("total", 65000);
            //command.Parameters.AddWithValue("2", "now()");

            db.Command(command);
        }

        public void getVenta()
        {
            string query = "SELECT * FROM venta";
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Id: "+reader["Id"].ToString()+" Total: "+reader["Total"].ToString()
                                        +" Fecha Venta: "+reader["Fecha_Venta"].ToString());
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public bool save()
        {
            return true;
        }

        public bool update()
        {
            return false;
        }
        
    }
}
