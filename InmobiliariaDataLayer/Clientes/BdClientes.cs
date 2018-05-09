using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;

  //namespace InmobiliariaDataLayer.Clientes

  namespace InmobiliariaDataLayer.Clientes
{
    public class BdClientes : ISqlPersistence //ISave , IUpdate , ISelectAll, ISelectForId, IDelete
    {
        private PostConnection db;  

        public BdClientes (){
            db = new PostConnection();
                         }

        public int Save (Object data)
        {
            int estado = -1;
            String query = "INSERT INTO Cliente(nombre, apellido, dpi, telefono, fecha, sexo, direccion,  estado_id)" +
                "values (@nombre, @apellido, @dpi, @telefono, @fecha, @sexo, @direccion,  @estado)";
            var datos = (ClienteInsertViewModels)data;
        

            var command = db.Command(query);

            command.Parameters.AddWithValue("@nombre", datos.nombre);
            command.Parameters.AddWithValue("@apellido", datos.apellido);
            command.Parameters.AddWithValue("@dpi", datos.dpi);
            command.Parameters.AddWithValue("@telefono", datos.telefono);
            command.Parameters.AddWithValue("@fecha", datos.fecha);
            command.Parameters.AddWithValue("@sexo", datos.sexo);
            command.Parameters.AddWithValue("@direccion", datos.direccion);
         
            command.Parameters.AddWithValue("@estado", datos.estado);
          

            estado = db.Command(command);
            return estado;
        }

         public int Update (object data)
    {
        int estado = -1;
        string query = "UPDATE Cliente SET nombre = @nombre, apellido = @apellido, dpi = @dpi, telefono = @telefono, fecha = @fecha, sexo = @sexo, direccion = @direccion, estado_id = @estado " +
            "where id = @id";


        //     update Cliente set nombre = 'Cristian', apellido = 'Vásquez', dpi = '2168088040920', telefono = '42438165',
        // fecha = '23/12/1992', sexo = 'M', direccion = 'Coatepeque', beneficiario_id = 1, estado_id = 1, referencia_id = 1
        //   where id = '1';

            var datos = (ClienteInsertViewModels)data;
        var command = db.Command(query);
        command.Parameters.AddWithValue("@id", datos.id);
        command.Parameters.AddWithValue("@nombre", datos.nombre);
        command.Parameters.AddWithValue("@apellido", datos.apellido);
        command.Parameters.AddWithValue("@dpi", datos.dpi);
        command.Parameters.AddWithValue("@telefono", datos.telefono);
        command.Parameters.AddWithValue("@fecha", datos.fecha);
        command.Parameters.AddWithValue("@sexo", datos.sexo);
        command.Parameters.AddWithValue("@direccion", datos.direccion);
        
        command.Parameters.AddWithValue("@estado", datos.estado);
        

        estado = db.Command(command);

        return estado;
    }

        //public int FindForId (int id)
        //{
        //    var listaclientes = new List<ListaClientViewModels>();
        //    string query = "SELECT nombre, apellido, dpi, telefono, sexo,  direccion from cliente where id = @ id";

        //    using (var connection = PostConnection.Connection())
        //    {
        //        using (var command = db.Command(query))
        //            try
        //            {
        //                connection.Open();
        //                command.Connection = connection;
        //                command.Parameters.AddWithValue("@id", id);



        //                using (var reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        listaclientes.Add(new ListaClientViewModels()
        //                        {
        //                            nombre = Convert.ToDouble(reader["nombre"]),
        //                            apellido = Convert.ToDouble(reader["apellido"]),
        //                            dpi = Convert.ToDouble(reader["dpi"]),
        //                            telefono = Convert.ToDouble(reader["telefono"]),
        //                            sexo = Convert.ToDouble(reader["sexo"]),
        //                            direccion = Convert.ToDouble(reader["direccion"]),


        //                        });
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }

        //    }
        //    return listaclientes;


        //}

        public object FindAll()
        {
            var lista = new List<ClienteInsertViewModels>();
            string query = "SELECT id, nombre, apellido, dpi, telefono, fecha,sexo, direccion, estado_id  from cliente";
            using (var conection = PostConnection.Connection ())
            {
                using (var command = db.Command (query))
                    {
                    try
                    {
                        conection.Open();
                        command.Connection = conection;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new ClienteInsertViewModels()
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    nombre = Convert.ToString(reader["nombre"]),
                                    apellido = Convert.ToString(reader["apellido"]),
                                    dpi = Convert.ToString(reader["dpi"]),
                                    telefono = Convert.ToString(reader["telefono"]),
                                    fecha = Convert.ToDateTime(reader["fecha"]),
                                    sexo = Convert.ToString(reader["sexo"]),
                                    direccion = Convert.ToString(reader["direccion"]),
                                   
                                    estado = Convert.ToInt32(reader["estado_id"]),
                                    
                                });
                            }
                        }

                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            // select nombre, apellido, dpi, telefono, fecha, sexo, direccion, beneficiario_id, estado_id, referencia_id from Cliente

            return lista;

        }

        public object FindForId (int id)
        {
            var cliente = new ClienteInsertViewModels();
            string query = "SELECT nombre, apellido, dpi, telefono, fecha,sexo, direccion, estado_id  from cliente where id= @id";
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


                                cliente.nombre = Convert.ToString(reader["nombre"]);
                               cliente.apellido = Convert.ToString(reader["apellido"]);
                                cliente.dpi = Convert.ToString(reader["dpi"]);
                                cliente.telefono = Convert.ToString(reader["telefono"]);
                                cliente.fecha = Convert.ToDateTime(reader["fecha"]);
                                cliente.sexo = Convert.ToString(reader["sexo"]);
                                cliente.direccion = Convert.ToString(reader["direccion"]);
                                
                                    cliente.estado = Convert.ToInt32(reader["estado"]);
                                   

                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return cliente;
        }

        public int Delete(int id)
        {
            int estado = -1;
            string query = "DELETE FROM cliente where id = @id";
            var command = db.Command(query);
            command.Parameters.AddWithValue("@id", id);
            estado = db.Command(command);
            return estado; 

        }

    }
}
