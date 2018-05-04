using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Empleados;

namespace InmobiliariaDataLayer.Empleados
{
    public class DBEstadoEmp : ISqlPersistence
    {
        private PostConnection db;

        public DBEstadoEmp()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            var lista = new List<EstadoEmpViewModels>();
            string query = "SELECT id, estadoemp FROM estadoemp";
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
                                lista.Add(new EstadoEmpViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    nestado = reader["estadoemp"].ToString(),
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
            string query = "DELETE FROM estadoemp WHERE id =@ides";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@ides", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var cargo = new EstadoEmpViewModels();
            string query = "SELECT id, estadoemp FROM estadoemp WHERE id = " + id;
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
                                cargo.nestado = reader["estadoemp"].ToString();
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

            var datos = (EstadoEmpViewModels)Create;

            //insertar cargo
            string query = "INSERT INTO estadoemp (estadoemp) VALUES (@estadoemp)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@estadoemp", datos.nestado);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE estadoemp SET estadoemp = @estadoemp WHERE id = @ides";


            var datos = (EstadoEmpViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@ides", datos.id);
            command.Parameters.AddWithValue("@estadoemp", datos.nestado);

            estado = db.Command(command);

            return estado;
        }
    }
}