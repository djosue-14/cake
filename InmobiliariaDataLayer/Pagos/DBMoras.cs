using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaDataLayer.Connection;
using InmobiliariaViewModels.Cuotas;

namespace InmobiliariaDataLayer.Pagos
{
    public class DBMoras: ISelectForId
    {
        private PostConnection db;

        public DBMoras()
        {
            this.db = new PostConnection();
        }

        public object FindForId(int id)
        {
            var listaMoras = new List<MoraSelectViewModels>();
            string query = "SELECT monto, fecha, estado FROM moras WHERE venta_id = @id";

            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaMoras.Add(new MoraSelectViewModels() {
                                    monto = Convert.ToDouble(reader["monto"]),
                                    fecha = Convert.ToDateTime(reader["fecha"]),
                                    estado = Convert.ToInt16(reader["estado"])
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
            return listaMoras;
        }
    }
}
