using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;

namespace InmobiliariaDataLayer.Clientes
{
    public class DBEstadoCli: ISqlPersistence
    {
        private PostConnection db;

        public DBEstadoCli()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            var lista = new List<EstadoCliViewModels>();
            string query = "SELECT id, estado FROM estado_cliente";
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
                                lista.Add(new EstadoCliViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    estado = reader["estado"].ToString(),
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
            string query = "DELETE FROM estado_cliente WHERE id =@ides";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@ides", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var cargo = new EstadoCliViewModels();
            string query = "SELECT id, estado FROM estado_cliente WHERE id = " + id;
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
                                cargo.id = Convert.ToInt16(reader["id"]);
                                cargo.estado = reader["estado"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return cargo;
        }

        public int Save(object Create)
        {
            int estado = -1;

            var datos = (EstadoCliViewModels)Create;

            //insertar estado
            string query = "INSERT INTO estado_cliente (estado) VALUES (@estado)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@estado", datos.estado);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE estado_cliente SET estado = @estado WHERE id = @ides";


            var datos = (EstadoCliViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@ides", datos.id);
            command.Parameters.AddWithValue("@estado", datos.estado);

            estado = db.Command(command);

            return estado;
        }
    }
}
