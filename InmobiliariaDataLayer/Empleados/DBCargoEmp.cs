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
    public class DBCargoEmp: ISqlPersistence
    {
        private PostConnection db;

        public DBCargoEmp()
        {
            db = new PostConnection();
        }
        //        public int Delete(int id)

        public object FindAll()
        {
            var lista = new List<CargoEmpViewModels>();
            string query = "SELECT id, nombrecargo FROM cargo";
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
                                lista.Add(new CargoEmpViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    nombrecargo = reader["nombrecargo"].ToString(),                                   
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
            string query = "DELETE FROM cargo WHERE id =@idcar";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idcar", id);

            estado = db.Command(command);

            return estado;
        }


        public object FindForId(int id)
        {
            var cargo = new CargoEmpViewModels();
            string query = "SELECT id, nombrecargo FROM cargo WHERE id = " + id;
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
                                cargo.nombrecargo = reader["nombrecargo"].ToString();
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

            var datos = (CargoEmpViewModels)Create;

            //insertar cargo
            string query = "INSERT INTO cargo (nombrecargo) VALUES (@nombrecar)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@nombrecar", datos.nombrecargo);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE cargo SET nombrecargo = @nombrecar WHERE id = @idcar";


            var datos = (CargoEmpViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idcar", datos.id);
            command.Parameters.AddWithValue("@nombrecar", datos.nombrecargo);

            estado = db.Command(command);

            return estado;
        }
    }
}