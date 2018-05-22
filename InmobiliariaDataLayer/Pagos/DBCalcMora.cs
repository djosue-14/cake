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
    public class DBCalcMora: ISelectForId, ISave
    {
        private PostConnection db;

        public DBCalcMora()
        {
            this.db = new PostConnection();
        }

        public object FindForId(int id)
        {
            var paramsMora = new CalcularMoraViewModels();
            string query = "SELECT saldo, fecha, cuota, mora FROM calc_demorados WHERE venta_id = @venta_id"
                + " ORDER BY fecha DESC LIMIT 1";
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@venta_id", id);
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                paramsMora.Saldo = Convert.ToDouble(reader["saldo"]);
                                paramsMora.Fecha = Convert.ToDateTime(reader["fecha"]);
                                paramsMora.Cuota = Convert.ToDouble(reader["cuota"]);
                                paramsMora.TasaMora = Convert.ToDouble(reader["mora"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }
                }
            }
            DateTime fechaUltimaMora = FechaUltimaMora(id);
            paramsMora.Fecha = paramsMora.Fecha < fechaUltimaMora ? fechaUltimaMora : paramsMora.Fecha;
            return paramsMora;
        }

        private DateTime FechaUltimaMora(int id)
        {
            DateTime fechaUltimaMora = new DateTime();
            string query = "SELECT fecha FROM moras WHERE venta_id = @venta_id" +
                " ORDER BY fecha DESC LIMIT 1";
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@venta_id", id);
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fechaUltimaMora = Convert.ToDateTime(reader["fecha"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            return fechaUltimaMora;
        }

        public int Save(object data)
        {
            int estado = -1;
            var mora = (MoraViewModels)data;
            string query = "INSERT INTO moras VALUES(null, @monto, @fecha, @estado, @venta_id)";
            var command = db.Command(query);

            command.Parameters.AddWithValue("@monto", mora.Monto);
            command.Parameters.AddWithValue("@fecha", mora.Fecha);
            command.Parameters.AddWithValue("@estado", 0);
            command.Parameters.AddWithValue("@venta_id", mora.VentaId);
            estado = db.Command(command);

            return estado;
        }
    }
}
