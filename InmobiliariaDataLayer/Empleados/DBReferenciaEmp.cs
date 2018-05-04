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
        public class DBReferenciaEmp : ISqlPersistence//ISave, IUpdate, IDelete, ISelectAll
        {
            private PostConnection db;

            public DBReferenciaEmp()
            {
                db = new PostConnection();
            }

            public object FindAll()
            {
                var lista = new List<ReferenciaEmpViewModels>();
                string query = "SELECT id, nombre, apellido, telefono, direccion, id_emp FROM referenciaemp";
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
                                    lista.Add(new ReferenciaEmpViewModels()
                                    {

                                        id = Convert.ToInt16(reader["id"]),
                                        nombre = reader["nombre"].ToString(),
                                        apellido = reader["apellido"].ToString(),
                                        tel = Convert.ToInt32(reader["telefono"]),
                                        direccion = reader["direccion"].ToString(),
                                        id_emp = Convert.ToInt16(reader["id_emp"]),
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
                string query = "DELETE FROM referenciaemp WHERE id =@id";

                var command = db.Command(query);
                command.Parameters.AddWithValue("@id", id);

                estado = db.Command(command);

                return estado;
            }


            public object FindForId(int id)
            {
                var referenciaemp = new ReferenciaEmpViewModels();
                string query = "SELECT id, nombre, apellido, telefono, direccion, id_emp FROM referenciaemp WHERE id = " + id;
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
                                    referenciaemp.id = Convert.ToInt16(reader["id"]);
                                    referenciaemp.nombre = reader["nombre"].ToString();
                                    referenciaemp.apellido = reader["apellido"].ToString();
                                    referenciaemp.tel = Convert.ToInt32(reader["telefono"]);
                                    referenciaemp.direccion = reader["direccion"].ToString();
                                    referenciaemp.id_emp = Convert.ToInt16(reader["id_emp"]);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                return referenciaemp;
            }

            public int Save(object Create)
            {
                int estado = -1;

                var datos = (ReferenciaEmpViewModels)Create;

                //insertar Referencia
                string query = "INSERT INTO referenciaemp (nombre, apellido, telefono,direccion, id_emp)" +
                 " VALUES(@nombre,@apellido,@tel,@direccion,@id_emp)";

                var command = db.Command(query);
                command.Parameters.AddWithValue("@nombre", datos.nombre);
                command.Parameters.AddWithValue("@apellido", datos.apellido);
                command.Parameters.AddWithValue("@tel", datos.tel);
                command.Parameters.AddWithValue("@direccion", datos.direccion);
                command.Parameters.AddWithValue("@id_emp", datos.id_emp);

            estado = db.Command(command);
            
            return estado;
            }

            public int Update(object data)
            {
                int estado = -1;



            string query = "UPDATE referenciaemp SET nombre = @nombre, apellido = @apellido, " +
                "telefono = @tel, direccion = @direccion WHERE id = @id";

            var datos = (ReferenciaEmpViewModels)data;

            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", datos.id);
            command.Parameters.AddWithValue("@nombre", datos.nombre);
                command.Parameters.AddWithValue("@apellido", datos.apellido);
                command.Parameters.AddWithValue("@tel", datos.tel);
                command.Parameters.AddWithValue("@direccion", datos.direccion);

            estado = db.Command(command);

                return estado;
            }
        }

}