using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotificadora;

namespace InmobiliariaDataLayer.Lotificadora
{
    public class DBGastos: ISqlPersistence
    {
        private PostConnection db;

        public DBGastos()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            var lista = new List<VistaGastoViewModels>();
            string query = "SELECT id, fecha, cantidad, descripcion, lotificadora, nombre, apellido FROM viewgastos";
            //string query = "SELECT id, fecha, cantidad, descripcion, id_lotifi, id_empleado FROM gastos";
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
                                lista.Add(new VistaGastoViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    Fecha = Convert.ToDateTime(reader["fecha"]),
                                    cantidad = Convert.ToDouble(reader["cantidad"]),
                                    descripcion = reader["descripcion"].ToString(),
                                    lotificadora = reader["lotificadora"].ToString(),
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
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
            return lista;
        }

        public int Delete(int id)
        {
            int estado = -1;
            string query = "DELETE FROM gastos WHERE id =@idgastos";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idgastos", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var gastos = new GastosViewModels();
            string query = "SELECT id, fecha, cantidad, descripcion, id_lotifi, id_empleado FROM gastos WHERE id = @id";
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id",id);
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                gastos.id = Convert.ToInt16(reader["id"]);
                                gastos.fecha = Convert.ToDateTime(reader["fecha"]);
                                gastos.cantidad = Convert.ToDouble(reader["cantidad"]);
                                gastos.descripcion = reader["descripcion"].ToString();
                                gastos.lotificadora_id = Convert.ToInt16(reader["id_lotifi"]);
                                gastos.empleado_id = Convert.ToInt16(reader["id_empleado"]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return gastos;
        }

        public int Save(object Create)
        {
            int estado = -1;

            var datos = (GastosViewModels)Create;

            //insertar gastos
            string query = "INSERT INTO gastos (fecha, cantidad, descripcion, id_lotifi, id_empleado)" +
             " VALUES(@fechag,@cantidadg,@descripciong,@lotig,@empleadog)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@fechag", datos.fecha);
            command.Parameters.AddWithValue("@cantidadg", datos.cantidad);
            command.Parameters.AddWithValue("@descripciong", datos.descripcion);
            command.Parameters.AddWithValue("@lotig", datos.lotificadora_id);
            command.Parameters.AddWithValue("@empleadog", datos.empleado_id);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE gastos SET cantidad = @cantidadg, descripcion = @descripciong,"+
            " id_lotifi = @lotig, id_empleado = @empleadog WHERE id = @idgastos";


            var datos = (GastosViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idgastos", datos.id);
            command.Parameters.AddWithValue("@cantidadg", datos.cantidad);
            command.Parameters.AddWithValue("@descripciong", datos.descripcion);
            command.Parameters.AddWithValue("@lotig", datos.lotificadora_id);
            command.Parameters.AddWithValue("@empleadog", datos.empleado_id);

            estado = db.Command(command);

            return estado;
        }
    }
}