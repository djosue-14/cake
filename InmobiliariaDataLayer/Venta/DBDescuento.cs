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
    public class DBDescuento: ISave
    {
        private PostConnection db;

        public DBDescuento()
        {
            db = new PostConnection();
        }

        public int Save(object data)
        {
            int estado = -1;
            var venta = (DescuentoViewModels)data;
            string query = "INSERT INTO descuentos(cantidad, venta_id) " +
                "VALUES(@cantidad, @venta_id)";

            var command = db.Command(query);

            command.Parameters.AddWithValue("@cantidad", venta.Cantidad);
            command.Parameters.AddWithValue("@venta_id", venta.VentaId);

            estado = db.Command(command);

            return estado;
        }
    }
}
