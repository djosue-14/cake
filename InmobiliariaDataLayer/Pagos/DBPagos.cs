using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.EstadoCuenta;
using InmobiliariaDataLayer.Connection;
using InmobiliariaViewModels.Pagos;

namespace InmobiliariaDataLayer.Pagos
{
    public class DBPagos: ISelectForId, ISave
    {
        private PostConnection db;

        public DBPagos()
        {
            this.db = new PostConnection();
        }

        public object FindForId(int id)
        {
            var listaMoras = new List<PagosSelectViewModels>();
            string query = "SELECT saldo_anterior, saldo_actual, monto, fecha_a_pagar, fecha_cancelada " +
                        "FROM pagos WHERE venta_id = @id";

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
                                listaMoras.Add(new PagosSelectViewModels()
                                {
                                    SaldoAnterior = Convert.ToDouble(reader["saldo_anterior"]),
                                    SaldoActual = Convert.ToDouble(reader["saldo_actual"]),
                                    Monto = Convert.ToDouble(reader["monto"]),
                                    FechaPagar = Convert.ToDateTime(reader["fecha_a_pagar"]),
                                    FechaCancelada = Convert.ToDateTime(reader["fecha_cancelada"])
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
        
        public int Save(object data)
        {
            int estado = -1;
            var pagos = (PagosViewModels)data;
            string query = "INSERT INTO pagos(saldo_anterior, saldo_actual, monto, fecha_pagar, fecha_cancelada, venta_id) " +
                "VALUES(@saldo_anterior, @saldo_actual, @monto, now(), now(), @venta_id)";

            var command = db.Command(query);

            command.Parameters.AddWithValue("@saldo_anterior", pagos.SaldoAnterior);
            command.Parameters.AddWithValue("@saldo_actual", pagos.SaldoActual);
            command.Parameters.AddWithValue("@monto", pagos.Monto);
            //command.Parameters.AddWithValue("@fecha_pagar", pagos.FechaPagar);
            //command.Parameters.AddWithValue("@fecha_cancelada",pagos.FechaCancelada);
            command.Parameters.AddWithValue("@venta_id", pagos.VentaId);

            estado = db.Command(command);

            return estado;
        }
    }
}
