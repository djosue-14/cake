using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Lotes
{
  public class LoteUpdateViewModels
    {

        public int numero { get; set; }
        public double largo { get; set; }
        public double ancho { get; set; }
        public double mts_cuadrados { get; set; }
        public double precio_lote { get; set; }
        public int manzana_id { get; set; }
        public int interes_id { get; set; }
        public int estado_id { get; set; }
        public int id { get; set; }
    }
}
