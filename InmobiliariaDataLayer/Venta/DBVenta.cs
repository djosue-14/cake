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
    public class DBVenta: ISave, IUpdate
    {
        private PostConnection db;

        public DBVenta()
        {
            db = new PostConnection();
        }

        public int Save(object data)
        {
            int estado = -1;
            var venta = (VentaViewModels)data;
            string query = "INSERT INTO venta(fecha, cliente_id, empventa_id, empingreso_id, tipoventa_id) "+
                "VALUES(now(), @cliente_id, @empventa_id, @tipoventa_id)";

            var command = db.Command(query);

            command.Parameters.AddWithValue("@cliente_id",venta.ClienteId);
            command.Parameters.AddWithValue("@empventa_id", venta.EmpVentaId);
            command.Parameters.AddWithValue("@tipoventa_id", venta.TipoVentaId);

            estado = db.Command(command);

            return estado;
        }

        public int Update(object data)
        {
            int estado = -1;
            var venta = (VentaViewModels)data;
            string query = "UPDATE venta SET estado = 0";

            var command = db.Command(query);

            estado = db.Command(command);

            return estado;
        }
    }
}