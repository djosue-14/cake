using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Venta
{
    public class DetalleVentaViewModels
    {
        public int Id { get; set; }
        public double PrecioInicial { get; set; }
        public double PrecioFinal { get; set; }
        public int LoteId { get; set; }
        public int VentaId { get; set; }
    }
}
