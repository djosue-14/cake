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
    public class DBLotificadora: ISqlPersistence
    {
        private PostConnection db;

        public DBLotificadora()
        {
            db = new PostConnection();
        }
        //        public int Delete(int id)

        public object FindAll()
        {
            var lista = new List<LotificadoraViewModels>();
            string query = "SELECT id, nombre,direccion, telefono, tasa_interes, tasa_mora FROM lotificadora";
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
                                lista.Add(new LotificadoraViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    nombre = reader["nombre"].ToString(),
                                    direccion = reader["direccion"].ToString(),
                                    telefono = Convert.ToInt32(reader["telefono"]),
                                    tasa_interes = Convert.ToDouble(reader["tasa_interes"]),
                                    tasa_mora = Convert.ToDouble(reader["tasa_mora"]),
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
            string query = "DELETE FROM lotificadora WHERE id =@idloti";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idloti", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var lotificadora = new LotificadoraViewModels();
            string query = "SELECT id, nombre, direccion, telefono, tasa_interes, tasa_mora FROM lotificadora WHERE id = " + id;
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
                                lotificadora.id = Convert.ToInt16(reader["id"]);
                                lotificadora.nombre = reader["nombre"].ToString();
                                lotificadora.direccion = reader["direccion"].ToString();
                                lotificadora.telefono = Convert.ToInt32(reader["telefono"]);
                                lotificadora.tasa_interes = Convert.ToDouble(reader["tasa_interes"]);
                                lotificadora.tasa_mora = Convert.ToDouble(reader["tasa_mora"]);                            
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return lotificadora;
        }

        public int Save(object Create)
        {
            int estado = -1;

            var datos = (LotificadoraViewModels)Create;

            //insertar empleado
            string query = "INSERT INTO lotificadora (nombre, direccion, telefono, tasa_interes, tasa_mora)" +
             " VALUES(@nombreloti,@direccionloti,@telloti, @tasainteres, @tasamora)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@nombreloti", datos.nombre);
            command.Parameters.AddWithValue("@direccionloti", datos.direccion);
            command.Parameters.AddWithValue("@telloti", datos.telefono);
            command.Parameters.AddWithValue("@tasainteres", datos.tasa_interes);
            command.Parameters.AddWithValue("@tasamora", datos.tasa_mora);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE lotificadora SET nombre = @nombreloti, direccion = @direccionloti, telefono = @telloti," +
            " tasa_interes = @tasainteres, tasa_mora = @tasamora WHERE id = @idloti";


            var datos = (LotificadoraViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idloti", datos.id);
            command.Parameters.AddWithValue("@nombreloti", datos.nombre);
            command.Parameters.AddWithValue("@direccionloti", datos.direccion);
            command.Parameters.AddWithValue("@telloti", datos.telefono);
            command.Parameters.AddWithValue("@tasainteres", datos.tasa_interes);
            command.Parameters.AddWithValue("@tasamora", datos.tasa_mora);


            estado = db.Command(command);

            return estado;
        }
    }
}