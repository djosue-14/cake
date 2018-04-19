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
    public class DBMora: ISelectForId, ISave
    {
        private PostConnection db;

        public DBMora()
        {
            this.db = new PostConnection();
        }

        public object FindForId(int id)
        {
            var paramsMora = new CalcularMoraViewModels();

            string query = "SELECT saldo, fecha, cuota, mora FROM calc_mora";//falta el WHERE para filtrar una venta
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
                                paramsMora.saldo = Convert.ToDouble(reader["saldo"]);
                                paramsMora.fecha = Convert.ToDateTime(reader["fecha"]);
                                paramsMora.cuota = Convert.ToDouble(reader["cuota"]);
                                paramsMora.tasaMora = Convert.ToDouble(reader["mora"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return paramsMora;
        }

        public int Save(object data)
        {
            int estado = -1;
            var mora = (MoraSaveViewModels)data;
            string query = "INSERT INTO moras VALUES(null, @monto, @fecha, @estado, @venta_id)";
            var command = db.Command(query);

            command.Parameters.AddWithValue("@monto", mora.monto);
            command.Parameters.AddWithValue("@fecha", mora.fecha);
            command.Parameters.AddWithValue("@estado", 0);
            command.Parameters.AddWithValue("@venta_id", 1);
            estado = db.Command(command);

            return estado;
        }


        //private int ConvertToDays(string intervalo)
        //{
        //    int cantidadDias = 0;
        //    var subintervalo = intervalo.Substring(0, intervalo.IndexOf("."));
        //    cantidadDias = Convert.ToInt16(subintervalo);
        //    return cantidadDias;
        //}
    }
}
