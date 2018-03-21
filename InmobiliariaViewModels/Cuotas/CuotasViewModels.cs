using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Cuotas
{
    public class CuotasViewModels
    {
        public double CuotaConInteres { get; set; }
        public double CuotaSinInteres { get; set; }
        public double InteresPorMes { get; set; }
        public double SaldoPrecioConInteres { get; set; }
        public double SaldoPrecioSinInteres { get; set; }
        public double SaldoInteresTotal { get; set; }
    }
}
