using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaDataLayer.Connection;
using InmobiliariaViewModels;

namespace InmobiliariaDataLayer.Promociones
{
    public class DBPromocion: ISave, ISelectForId, IUpdate, ISelectAll
    {
        private PostConnection _database;

        public DBPromocion()
        {
            _database = new PostConnection();
        }

        public object FindAll()
        {
            var promociones = new List<PromocionViewModels>();
            string query = "SELECT id, cantidad, descripcion, fecha_inicio, fecha_fin, loti_id "+
                    "FROM promociones WHERE now() <= fecha_fin+1";

            //select* from promociones WHERE loti_id = 1 AND(now() BETWEEN fecha_inicio AND fecha_fin + 1
            using (var connection = PostConnection.Connection())
            {
                using (var command = _database.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                promociones.Add(new PromocionViewModels()
                                {
                                    Id = Convert.ToInt16(reader["id"]),
                                    Cantidad = Convert.ToDouble(reader["cantidad"]),
                                    Descripcion = reader["descripcion"].ToString(),
                                    FechaInicio = Convert.ToDateTime(reader["fecha_inicio"]),
                                    FechaFin = Convert.ToDateTime(reader["fecha_fin"]),
                                    LotificadoraId = Convert.ToInt16(reader["loti_id"])
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
            return promociones;
        }

        public object FindForId(int id)
        {
            var promo = new PromocionViewModels();
            string query = "SELECT id, cantidad, descripcion, fecha_inicio, fecha_fin, loti_id" + 
                    " FROM promociones WHERE id = @id";

            using (var connection = PostConnection.Connection())
            {
                using (var command = _database.Command(query))
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
                                promo.Id = Convert.ToInt16(reader["id"]);
                                promo.Cantidad = Convert.ToDouble(reader["cantidad"]);
                                promo.Descripcion = reader["descripcion"].ToString();
                                promo.FechaInicio = Convert.ToDateTime(reader["fecha_inicio"]);
                                promo.FechaFin = Convert.ToDateTime(reader["fecha_fin"]);
                                promo.LotificadoraId = Convert.ToInt16(reader["loti_id"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return promo;
        }

        public int Save(object data)
        {
            int estado = -1;
            var promocion = (PromocionViewModels)data;
            string query = "INSERT INTO promociones VALUES(null, @cantidad, @descripcion, @fecha_inicio, "
                + " @fecha_fin, @loti_id)";

            var command = _database.Command(query);
            command.Parameters.AddWithValue("@cantidad", promocion.Cantidad);
            command.Parameters.AddWithValue("@descripcion", promocion.Descripcion);
            command.Parameters.AddWithValue("@fecha_inicio", promocion.FechaInicio);
            command.Parameters.AddWithValue("@fecha_fin", promocion.FechaFin);
            command.Parameters.AddWithValue("@loti_id", promocion.LotificadoraId);

            estado = _database.Command(command);
            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;
            var promocion = (PromocionViewModels)data;
            string query = "UPDATE promociones SET cantidad = @cantidad, descripcion = @descripcion, " +
                "fecha_inicio = @fecha_inicio, fecha_fin = @fecha_fin, loti_id = @ loti_id WHERE id = @id";

            var command = _database.Command(query);
            command.Parameters.AddWithValue("@cantidad", promocion.Cantidad);
            command.Parameters.AddWithValue("@descripcion", promocion.Descripcion);
            command.Parameters.AddWithValue("@fecha_inicio", promocion.FechaInicio);
            command.Parameters.AddWithValue("@fecha_fin", promocion.FechaFin);
            command.Parameters.AddWithValue("@loti_id", promocion.LotificadoraId);
            command.Parameters.AddWithValue("@id", promocion.Id);

            estado = _database.Command(command);

            return estado;
        }
    }
}
