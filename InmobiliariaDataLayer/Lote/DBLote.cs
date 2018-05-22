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

    
    public class DBLote: ISqlPersistence //ISave, IUpdate, ISelectForId, ISelectAll, IDelete
    {
        private PostConnection db;

        public DBLote()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            var lista = new List<LoteViewModels>();
            string query = "select id, numero, largo, ancho, mts_cuadrados, precio, manzana, lotificadora, estado from viewlote";
            //   string query = "SELECT no_lote, largo, ancho, mts_cuadrados, precio_lote, manzana_id, lotificadora_id, estado_id from lote ";
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
                                lista.Add(new LoteViewModels()
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    numero = Convert.ToInt32(reader["numero"]),
                                    largo = Convert.ToDouble(reader["largo"]),
                                    ancho = Convert.ToDouble(reader["ancho"]),
                                    mts_cuadrados = Convert.ToDouble(reader["mts_cuadrados"]),
                                    precio = Convert.ToDouble(reader["precio"]),
                                    manzana = Convert.ToString(reader["manzana"]),
                                    lotificadora = Convert.ToString(reader["lotificadora"]),
                                    estado = Convert.ToString(reader["estado"]),


                                    // @no_lote,@largo,@ancho,@mts_cuadrados,@precio_lote,@manzana_id,@interes_id,@estado_id 
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
            string query = "DELETE FROM lote WHERE id =@id";
            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", id);

            estado = db.Command(command);

            return estado;
        }

        public object FindForId(int id)
        {
            var lotify = new LoteIngresoViewModels();
            string query = "SELECT id, no_lote, largo, ancho, mts_cuadrados, precio_lote, manzana_id, lotificadora_id, estado_id  FROM lote  WHERE id = @id";
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
                                lotify.id = Convert.ToInt32(reader["id"]);
                                lotify.numero = Convert.ToInt32(reader["no_lote"]);
                                lotify.largo = Convert.ToDouble(reader["largo"]);
                                lotify.ancho = Convert.ToDouble(reader["ancho"]);
                                lotify.mts_cuadrados = Convert.ToDouble(reader["mts_cuadrados"]);
                                lotify.precio_lote = Convert.ToDouble(reader["precio_lote"]);
                                lotify.manzana_id = Convert.ToInt32(reader["manzana_id"]);
                                lotify.lotificadora_id = Convert.ToInt32(reader["lotificadora_id"]);
                                lotify.estado_id = Convert.ToInt32(reader["estado_id"]);
                            }
                        }

                    }


                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return lotify;
        }


        public int Save(object Create)
        {
            int estado = -1;

            var datos = (LoteIngresoViewModels)Create;

            string query = "INSERT INTO lote (no_lote, largo, ancho, mts_cuadrados, precio_lote, manzana_id, lotificadora_id, estado_id)" +
             " VALUES ( @no_lote, @largo,@ancho, @mts_cuadrados, @precio_lote, @manzana_id, @lotificadora_id, @estado_id)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@no_lote",datos.numero);
            command.Parameters.AddWithValue("@largo", datos.largo);
            command.Parameters.AddWithValue("@ancho", datos.ancho);
            command.Parameters.AddWithValue("@mts_cuadrados", datos.mts_cuadrados);
            command.Parameters.AddWithValue("@precio_lote", datos.precio_lote);
            command.Parameters.AddWithValue("@manzana_id", datos.manzana_id);
            command.Parameters.AddWithValue("@lotificadora_id", datos.lotificadora_id);
            command.Parameters.AddWithValue("@estado_id", datos.estado_id);

            estado = db.Command(command);

            return estado;
        }

        public int Update (object data)
        {
            int estado = -1;
            string query = "update lote set no_lote = @no_lote, largo = @largo, ancho = @ancho, mts_cuadrados = @mts_cuadrados, " +
                "precio_lote = @precio_lote, manzana_id = @manzana_id, lotificadora_id = @lotificadora_id, estado_id = @estado_id" +
             " where id = @id";

            var datos = (LoteIngresoViewModels)data;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@Id", datos.id);
            command.Parameters.AddWithValue("@no_lote", datos.numero);
            command.Parameters.AddWithValue("@largo", datos.largo);
            command.Parameters.AddWithValue("@ancho", datos.ancho);
            command.Parameters.AddWithValue("@mts_cuadrados", datos.mts_cuadrados);
            command.Parameters.AddWithValue("@precio_lote", datos.precio_lote);
            command.Parameters.AddWithValue("@manzana_id", datos.manzana_id);
            command.Parameters.AddWithValue("@lotificadora_id", datos.lotificadora_id);
            command.Parameters.AddWithValue("@estado_id", datos.estado_id);

            estado = db.Command(command);

            return estado;
        }
    }
}