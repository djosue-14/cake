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
    public class DBDetalleVenta: ISave
    {
        private PostConnection db;
        public DBDetalleVenta()
        {
            db = new PostConnection();
        }

        public int Save(object data)
        {
            int estado = -1;
            var venta = (DetalleVentaViewModels)data;
            string query = "INSERT INTO detalle_venta(precio_inicial, precio_final, lote_id, venta_id) " +
                "VALUES(@precio_inicial,@precio_final,@lote_id,@venta_id)";

            var command = db.Command(query);

            command.Parameters.AddWithValue("@precio_inicial", venta.PrecioInicial);
            command.Parameters.AddWithValue("@precio_final", venta.PrecioFinal);
            command.Parameters.AddWithValue("@lote_id", venta.LoteId);
            command.Parameters.AddWithValue("@venta_id", venta.VentaId);

            estado = db.Command(command);

            return estado;
        }
    }
}
