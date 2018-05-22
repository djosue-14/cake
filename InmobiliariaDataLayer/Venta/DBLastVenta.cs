using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaDataLayer.Venta
{
    public class DBLastVenta: ISelectAll
    {
        private PostConnection db;
        public DBLastVenta()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            string query = "SELECT id FROM venta ORDER BY id DESC LIMIT 1";
            int ventaId = 0;

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
                                ventaId = Convert.ToInt32(reader["id"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return ventaId;
        }
    }
}
