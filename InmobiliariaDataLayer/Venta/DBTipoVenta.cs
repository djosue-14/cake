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
    public class DBTipoVenta: ISelectAll
    {
        private PostConnection db;

        public DBTipoVenta()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            string query = "SELECT id, descripcion FROM tipo_venta";
            var tipo_venta = new List<TipoVentaViewModels>();

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
                                tipo_venta.Add(new TipoVentaViewModels()
                                {
                                    Id = Convert.ToInt16(reader["id"]),
                                    Descripcion = reader["descripcion"].ToString(),
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return tipo_venta;
        }

    }
}
