using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;
using InmobiliariaViewModels.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InmobiliariaDataLayer.Clientes
{
    public class DBPagar: ISelectForId
    {
        private PostConnection db;

        public DBPagar() {
            db = new PostConnection();
        }

        public object FindForId(int id)
        {
            var pagar = new List<ClientesPagarViewModels>();
            string query = "SELECT a.nombre, a.apellido, b.id FROM Cliente a, Venta b WHERE a.id = b.cliente_id AND a.id = @id";

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
                                pagar.Add(new ClientesPagarViewModels() {
                                    nombre = Convert.ToString(reader["nombre"]),
                                    apellido = Convert.ToString(reader["apellido"]),
                                    idventa = Convert.ToInt32(reader["id"])
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
            return pagar;
        }

        public object UltimoPago(int id)
        {
            var pagar = new UltimoPagoViewModels();
            string query = "SELECT A.saldo_anterior, A.saldo_actual, A.monto, A.fecha_pagar, A.fecha_cancelada, A.venta_id, B.cuota FROM pagos A"
            +" INNER JOIN finan_venta B ON A.venta_id = B.venta_id WHERE A.venta_id = @id ORDER BY A.id DESC LIMIT 1";

            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pagar.Saldo_Anterior = Convert.ToDouble(reader["saldo_anterior"]);
                                pagar.Saldo_Actual = Convert.ToDouble(reader["saldo_actual"]);
                                pagar.Monto = Convert.ToDouble(reader["monto"]);
                                pagar.Fecha_Pagar = Convert.ToDateTime(reader["fecha_pagar"]);
                                pagar.Fecha_Cancelada = Convert.ToDateTime(reader["fecha_cancelada"]);
                                pagar.Venta_id = Convert.ToInt16(reader["venta_id"]);
                                pagar.Cuota = Convert.ToDouble(reader["cuota"]);
                            }
                        }
                    }
                   
                }
            return pagar;
        }

        public int Save(Object data)
        {
            int estado = -1;

            var datos = (UltimoPagoViewModels)data;

            //insertar clientes
            String query = "INSERT INTO pagos(saldo_anterior, saldo_actual, monto, fecha_pagar, fecha_cancelada, venta_id)" +
                "VALUES (@saldoanterior, @saldoactual, @monto, @fecha_pagar, now(), @ventaid)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@saldoanterior", datos.Saldo_Anterior);
            command.Parameters.AddWithValue("@saldoactual", datos.Saldo_Actual);
            command.Parameters.AddWithValue("@monto", datos.Monto);
            command.Parameters.AddWithValue("@fecha_pagar", datos.Fecha_Pagar);
            command.Parameters.AddWithValue("@ventaid", datos.Venta_id);
            

            estado = db.Command(command);

            return estado;
        }
    }
}