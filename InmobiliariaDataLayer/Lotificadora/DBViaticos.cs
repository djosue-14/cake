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
    public class DBViaticos: ISqlPersistence
    {
        private PostConnection db;

        public DBViaticos()
        {
            db = new PostConnection();
        }
        
        public object FindAll()
        {
            var lista = new List<VistaViaticosViewModels>();
            string query = "SELECT id, fecha, cantidad, descripcion, lotificadora, nombre, apellido FROM viewviaticos";
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
                                lista.Add(new VistaViaticosViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    fecha = Convert.ToDateTime(reader["fecha"]),
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
            string query = "DELETE FROM viaticos WHERE id =@id";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var viaticos = new ViaticosViewModels();
            string query = "SELECT id, fecha, cantidad, descripcion, id_lotifi, id_empleado FROM viaticos WHERE id = @id";
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

                                viaticos.id = Convert.ToInt16(reader["id"]);
                                viaticos.fecha = Convert.ToDateTime(reader["fecha"]);
                                viaticos.cantidad = Convert.ToDouble(reader["cantidad"]);
                                viaticos.descripcion = reader["descripcion"].ToString();
                                viaticos.lotificadora_id = Convert.ToInt16(reader["id_lotifi"]);
                                viaticos.empleado_id = Convert.ToInt16(reader["id_empleado"]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return viaticos;
        }

        public int Save(object Create)
        {
            int estado = -1;

            var datos = (ViaticosViewModels)Create;

            //insertar viaticos
            string query = "INSERT INTO viaticos (fecha, cantidad, descripcion, id_lotifi, id_empleado)" +
             " VALUES(@fechav,@cantidadv,@descripcionv,@lotiv,@empleadov)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@fechav", datos.fecha);
            command.Parameters.AddWithValue("@cantidadv", datos.cantidad);
            command.Parameters.AddWithValue("@descripcionv", datos.descripcion);
            command.Parameters.AddWithValue("@lotiv", datos.lotificadora_id);
            command.Parameters.AddWithValue("@empleadov", datos.empleado_id);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE viaticos SET cantidad = @cantidadv, descripcion = @descripcionv," +
            " id_lotifi = @lotiv, id_empleado = @empleadov WHERE id = @id";


            var datos = (ViaticosViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", datos.id);
            command.Parameters.AddWithValue("@cantidadv", datos.cantidad);
            command.Parameters.AddWithValue("@descripcionv", datos.descripcion);
            command.Parameters.AddWithValue("@lotiv", datos.lotificadora_id);
            command.Parameters.AddWithValue("@empleadov", datos.empleado_id);

            estado = db.Command(command);

            return estado;
        }
    }
}