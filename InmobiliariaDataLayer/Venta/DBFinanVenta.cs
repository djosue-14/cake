using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaDataLayer.Venta
{
    public class DBFinanVenta: ISave
    {
        private PostConnection db;
        public DBFinanVenta()
        {
            db = new PostConnection();
        }

        public int Save(object data)
        {
            int estado = -1;
            var finan_venta = (FinanVentaViewModels)data;
            string query = "INSERT INTO finan_venta(tiempo, cuota, tasa_interes, mora, venta_id)" +
                "VALUES(@tiempo,@cuota,@tasa_interes,@mora,@venta_id)";

            var command = db.Command(query);

            command.Parameters.AddWithValue("@tiempo", finan_venta.Tiempo);
            command.Parameters.AddWithValue("@cuota", finan_venta.Cuota);
            command.Parameters.AddWithValue("@tasa_interes", finan_venta.TasaInteres);
            command.Parameters.AddWithValue("@mora", finan_venta.Mora);
            command.Parameters.AddWithValue("@venta_id",finan_venta.VentaId);

            estado = db.Command(command);

            return estado;
        }
    }
}
