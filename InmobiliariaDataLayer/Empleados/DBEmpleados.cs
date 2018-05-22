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
    public class DBEmpleados: ISqlPersistence//ISave, IUpdate, IDelete, ISelectAll
    {
        private PostConnection db;

        public DBEmpleados()
        {
            db = new PostConnection();
        }

        public object FindAll()
        {
            var lista = new List<EmpleadosIngresoViewModels>();

            string query = "SELECT id, nombre, apellido, dpi, telefono, sexo, fecha_nac, direccion, id_cargo, id_estadoemp FROM empleados";
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
                                lista.Add(new EmpleadosIngresoViewModels()
                                {

                                    id = Convert.ToInt16(reader["id"]),
                                    nombre_e = reader["nombre"].ToString(),
                                    apellido_e = reader["apellido"].ToString(),
                                    dpi_e = Convert.ToInt64(reader["dpi"]),
                                    tel_e = Convert.ToInt32(reader["telefono"]),
                                    sexo_e = Convert.ToInt16(reader["sexo"]),
                                    fecha_nac_e = Convert.ToDateTime(reader["fecha_nac"]),
                                    dire_e = reader["direccion"].ToString(),
                                    cargo_e = Convert.ToInt16(reader["id_cargo"]),
                                    estado_e = Convert.ToInt16(reader["id_estadoemp"]),
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
            string query = "DELETE FROM empleados WHERE id =@idemp";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@idemp", id);

            estado = db.Command(command);

            return estado;
        }

        public object FindForId(int id)
        {
            var empleado = new EmpleadosIngresoViewModels();
            string query = "SELECT id, nombre, apellido, dpi, telefono, sexo, fecha_nac, direccion, id_cargo, id_estadoemp FROM empleados WHERE id = "+id;
            using (var connection = PostConnection.Connection())
            {
                using (var command = db.Command(query))
                {
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@idemp", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empleado.id = Convert.ToInt16(reader["id"]);
                                empleado.nombre_e = reader["nombre"].ToString();
                                empleado.apellido_e = reader["apellido"].ToString();
                                empleado.dpi_e = Convert.ToInt64(reader["dpi"]);
                                empleado.tel_e = Convert.ToInt32(reader["telefono"]);
                                empleado.sexo_e = Convert.ToInt16(reader["sexo"]);
                                empleado.fecha_nac_e = Convert.ToDateTime(reader["fecha_nac"]);
                                empleado.dire_e = reader["direccion"].ToString();
                                empleado.cargo_e = Convert.ToInt16(reader["id_cargo"]);
                                empleado.estado_e = Convert.ToInt16(reader["id_estadoemp"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return empleado;
        }

        public int Save(object Create)
        {
            int estado = -1;

            var datos = (EmpleadosIngresoViewModels)Create;

            //insertar empleado
            string query = "INSERT INTO empleados (nombre, apellido, dpi, telefono, sexo, fecha_nac, direccion, id_cargo, id_estadoemp)" +
             " VALUES(@nombreemp,@apellidoemp,@dpiemp,@telemp,@sexoemp,@fecha_nacemp,@diremp,@cargoemp, @estadoemp)";

            var command = db.Command(query);
            command.Parameters.AddWithValue("@nombreemp", datos.nombre_e);
            command.Parameters.AddWithValue("@apellidoemp", datos.apellido_e);
            command.Parameters.AddWithValue("@dpiemp", datos.dpi_e);
            command.Parameters.AddWithValue("@telemp", datos.tel_e);
            command.Parameters.AddWithValue("@sexoemp", datos.sexo_e);
            command.Parameters.AddWithValue("@fecha_nacemp", datos.fecha_nac_e);
            command.Parameters.AddWithValue("@diremp", datos.dire_e);
            command.Parameters.AddWithValue("@cargoemp", datos.cargo_e);
            command.Parameters.AddWithValue("@estadoemp", datos.estado_e);            

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;

            string query = "UPDATE empleados SET nombre = @nombreemp, apellido = @apellidoemp, dpi = @dpiemp, telefono = @telemp, sexo = @sexoemp,"+
            " fecha_nac = @fecha_nacemp, direccion = @diremp, id_cargo = @cargoemp, id_estadoemp = @estadoemp WHERE id = @idemp";
            
            var datos = (EmpleadosIngresoViewModels)data;
            var command = db.Command(query);
            command.Parameters.AddWithValue("@idemp", datos.id);
            command.Parameters.AddWithValue("@nombreemp", datos.nombre_e);
            command.Parameters.AddWithValue("@apellidoemp", datos.apellido_e);
            command.Parameters.AddWithValue("@dpiemp", datos.dpi_e);
            command.Parameters.AddWithValue("@telemp", datos.tel_e);
            command.Parameters.AddWithValue("@sexoemp", datos.sexo_e);
            command.Parameters.AddWithValue("@fecha_nacemp", datos.fecha_nac_e);
            command.Parameters.AddWithValue("@diremp", datos.dire_e);
            command.Parameters.AddWithValue("@cargoemp", datos.cargo_e);
            command.Parameters.AddWithValue("@estadoemp", datos.estado_e);

            estado = db.Command(command);

            return estado;
        }
    }
}