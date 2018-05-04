using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaDataLayer.Cuotas
{
    public class DBCuota: ISelectForId
    {
        private PostConnection _database;

        public DBCuota()
        {
            this._database = new PostConnection();
        }

        public object FindForId(int id)
        {
            string query = "SELECT cuota FROM finan_venta WHERE venta_id = @id";
            double cuota = 0;

            using (var connection = PostConnection.Connection())
            {
                using (var command = _database.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            cuota = Convert.ToDouble(reader["cuota"]);   
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return cuota;
        }
    }
}
