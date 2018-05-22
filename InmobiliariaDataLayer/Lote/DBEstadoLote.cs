using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotes;

namespace InmobiliariaDataLayer.Lote
{
    public class DBEstadoLote: ISqlPersistence
    {
        private PostConnection db;
        public DBEstadoLote()
        {
            db = new PostConnection();
        }


        public object FindAll()
        {
            var lista = new List<EstadoLoteViewModels>();
            string query = "SELECT id, estado FROM estado_lote";
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
                                lista.Add(new EstadoLoteViewModels()
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    estado = Convert.ToString(reader["estado"]),
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

        public int Save (object Create)
        {
            int estado = -1;
            String query = "INSERT INTO estado_lote (estado) VALUES (@estado)";
            var datos = (EstadoLoteViewModels)Create;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@estado", datos.estado);
            estado = db.Command(command);
            return estado;

        }
        
            public int Update (object data)
            {
            int estado = -1;
            string query = "UPDATE estado_lote SET estado = @estado WHERE id=@id";
            var datos = (EstadoLoteViewModels)data;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", datos.id);
            command.Parameters.AddWithValue("@estado", datos.estado);

            estado = db.Command(command);
            return estado;
        }
            public object FindForId (int id)
            {
            var lotestado = new EstadoLoteViewModels();
            string query = " SELECT id, estado FROM estado_lote WHERE id= " + id;
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try {
                        connection.Open();
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lotestado.id = Convert.ToInt32(reader["id"]);
                                lotestado.estado = Convert.ToString(reader["estado"]);
                            }
                        }
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            return lotestado;
            //asdf
           }
            
        //
        public int Delete (int id)
            {
            int estado = -1;
            string query = "DELETE FROM estado_lote WHERE id=@id";
            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", id);
            estado = db.Command(command);
            return estado;
            }
    }
}
