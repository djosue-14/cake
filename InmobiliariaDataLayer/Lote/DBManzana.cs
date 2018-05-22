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
    public class DBManzana : ISqlPersistence
    {
        private PostConnection db;

        public DBManzana()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            var lista = new List<ManzanaLoteViewModels>();
            string query = "SELECT id, manzana FROM manzana";
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
                                lista.Add(new ManzanaLoteViewModels()
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    manzana = reader["manzana"].ToString(),
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
            string query = "DELETE FROM manzana WHERE id=@id";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var lotemanzana = new ManzanaLoteViewModels();
            string query = " SELECT id, manzana FROM manzana WHERE id = " + id;
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
                                lotemanzana.id = Convert.ToInt32(reader["id"]);
                                lotemanzana.manzana = reader["manzana"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return lotemanzana;            
        }

        public int Save (object data)
        {
            int estado = -1;

            var datos = (ManzanaLoteViewModels)data;

            //INSERTAR MANZANA
            String query = "INSERT INTO manzana (manzana) VALUES (@manzana)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@manzana", datos.manzana);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE manzana SET manzana = @manzana WHERE id=@id";

            var datos = (ManzanaLoteViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", datos.id);
            command.Parameters.AddWithValue("@manzana", datos.manzana);

            estado = db.Command(command);

            return estado;
        }        
    }
}