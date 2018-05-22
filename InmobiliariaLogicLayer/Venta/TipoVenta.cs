using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Venta
{
    public class TipoVenta
    {
        private ISelectAll _select;

        public TipoVenta(ISelectAll _select) {

            this._select = _select;

        }

        public int GetId(string dato) {
            var tiposventa = (List<TipoVentaViewModels>)_select.FindAll();
            var tipov = tiposventa.Where(x => x.Descripcion == dato);
            int id = 0;
            foreach (var item in tipov) {
                id = item.Id;
            }

            return id;
        }
    }
}
