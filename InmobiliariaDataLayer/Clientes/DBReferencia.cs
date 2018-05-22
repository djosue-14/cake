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
    public class DBReferencia : ISqlPersistence // ISave, IUpdate, ISelectAll, IDelete
    {

        private PostConnection db;
        public DBReferencia()
        {
            db = new PostConnection();
        }

        public int Save (Object data)
        {
            int estado = 1;
            String query = "INSERT INTO referencia (nombre, apellido, telefono, direccion, id_cliente) " +
                "values (@nombre, @apellido, @telefono, @direccion, @id_cliente)";
            var datos = (ClienteReferenciaViewModels)data;
            var command = db.Command(query);

            command.Parameters.AddWithValue("@nombre", datos.Nombre);
            command.Parameters.AddWithValue("@apellido", datos.Apellido);
            command.Parameters.AddWithValue("@telefono", datos.Telefono);
            command.Parameters.AddWithValue("@direccion", datos.Direccion);
            command.Parameters.AddWithValue("@id_cliente", datos.ClienteId);

            estado = db.Command(command);
            return estado;
        }

        public int Update (object data)
        {
            int estado = 1;
            string query = "UPDATE referencia set nombre = @nombre, apellido = @apellido, telefono = @telefono, direccion = @direccion, id_cliente = @id_cliente " +
                "where id = @id";

          //  update referencia set nombre = 'Jose', apellido = 'Medina', telefono = '788547', direccion = 'la Blanca', id_cliente = '1'
      // where id = '1';
            var datos = (ClienteReferenciaViewModels)data;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", datos.Id);
            command.Parameters.AddWithValue("@nombre", datos.Nombre);
            command.Parameters.AddWithValue("@apellido", datos.Apellido);
            command.Parameters.AddWithValue("@telefono", datos.Telefono);
            command.Parameters.AddWithValue("@direccion", datos.Direccion);
            command.Parameters.AddWithValue("@id_cliente", datos.ClienteId);

            estado = db.Command(command);
            return estado;

        }

        public object FindAll()
        {
            var lista = new List<ClienteReferenciaViewModels>();
            string query = "select id, nombre, apellido, telefono, direccion, id_cliente from referencia ";

            using (var conection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try {
                        conection.Open();
                        command.Connection = conection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new ClienteReferenciaViewModels()
                                {
                                    Id= Convert.ToInt32(reader["id"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    ClienteId = Convert.ToInt32(reader["id_cliente"]),

                                });
                            }
                        }

                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return lista;
            // dlfjaslfkjsd
        }

        public int Delete (int id)
        {
            int estado = 1;
            string query = "DELETE FROM referencia where id = @Id";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@Id", id);
            estado = db.Command(command);
            return estado;


        }

        public object FindForId(int id)
        {
            var reff = new ClienteReferenciaViewModels();
            string query = "select id, nombre, apellido, telefono, direccion, id_cliente from referencia where id=@id";
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id",id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reff.Id = Convert.ToInt32(reader["id"]);
                                reff.Nombre = Convert.ToString(reader["nombre"]);
                                reff.Apellido = Convert.ToString(reader["apellido"]);
                                reff.Telefono = Convert.ToString(reader["telefono"]);
                                reff.Direccion = Convert.ToString(reader["direccion"]);
                                reff.ClienteId = Convert.ToInt32(reader["id_cliente"]);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return reff;
            //asfsdf
        }
    }
}
