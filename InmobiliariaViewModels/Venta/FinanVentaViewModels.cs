using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Venta
{
    public class FinanVentaViewModels
    {
        public int Id { get; set; }
        public int Tiempo { get; set; }
        public double Cuota { get; set; }
        public double TasaInteres { get; set; }
        public double Mora { get; set; }
        public int VentaId { get; set; }
    }
}
