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
    public class DBBeneficiario : ISqlPersistence
    {
        private PostConnection db;

        public DBBeneficiario()
        {
            db = new PostConnection();
        }

        public int Save (Object data)
        {
            int estado = 1;
            String query = " insert into benefIciario (nombre, apellido, dpi, telefono, direccion, sexo, id_cliente) " +
                "values (@nombre, @apellido, @dpi, @telefono, @direccion, @sexo, @id_cliente )";
            //  nombre, apellido, dpi, telefono, direccion, sexo, id_cliente
            var datos = (BeneficiarioViewModels)data;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@nombre", datos.Nombre);
            command.Parameters.AddWithValue("@apellido", datos.Apellido);
            command.Parameters.AddWithValue("@dpi", datos.Dpi);
            command.Parameters.AddWithValue("@telefono", datos.Telefono);
            command.Parameters.AddWithValue("@direccion", datos.Direccion);
            command.Parameters.AddWithValue("@sexo", datos.Sexo);
            command.Parameters.AddWithValue("@id_cliente", datos.ClienteId);

            estado = db.Command(command);
            return estado;
        }

        public int Update (object data)
        {
            int estado = 1;
            string query = "update beneficiario set nombre=@Nombre, apellido=@Apellido, dpi=@Dpi, telefono=@Telefono, direccion=@Direccion, sexo=@sexo, id_cliente=@ClienteId where id=@Id";

            var datos = (BeneficiarioViewModels)data;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", datos.Id);
            command.Parameters.AddWithValue("@nombre", datos.Nombre);
            command.Parameters.AddWithValue("dpi", datos.Dpi);
            command.Parameters.AddWithValue("telefono", datos.Telefono);
            command.Parameters.AddWithValue("direccion", datos.Direccion);
            command.Parameters.AddWithValue("sexo", datos.Sexo);
            command.Parameters.AddWithValue("id_cliente", datos.ClienteId);

            estado = db.Command(command);
            return estado;

        }
        public object FindAll()
        {
            var lista = new List<BeneficiarioViewModels>();
            string query = " select  nombre, apellido, dpi, telefono, direccion, sexo, id_cliente from beneficiario ";

            using (var conection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        conection.Open();
                        command.Connection = conection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new BeneficiarioViewModels()
                                {
                                    // id= Convert.ToInt32(reader["id"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    Dpi = reader["dpi"].ToString(),
                                    Telefono = Convert.ToInt32(reader["telefono"]),
                                    Direccion = reader["direccion"].ToString(),
                                    Sexo = reader["sexo"].ToString(),
                                    ClienteId = Convert.ToInt32(reader["id_cliente"]),

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
        public  int Delete (int id)
        {
            int estado = 1;
            string query = "delete from beneficiario where id=@Id";
            var command = db.Command(query);
            estado = db.Command(command);
            return estado;
        }

        public object FindForId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
