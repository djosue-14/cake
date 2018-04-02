using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Cuotas
{
    public class CuotasPorMesViewModels
    {
        public double CuotaConInteres { get; set; }
        public double CuotaSinInteres { get; set; }
        public double InteresPorMes { get; set; }
        public double SaldoPrecioConInteres { get; set; }
        public double SaldoPrecioSinInteres { get; set; }
        public double SaldoInteresTotal { get; set; }
    }

    public class CuotasPorFinanciamientoViewModels
    {
        public double PrecioBruto { get; set; }
        public int Meses { get; set; }
        public double Enganche { get; set; }
        public double PrecioNeto { get; set; }
        public double InteresTotal { get; set; }
        public double PrecioTotal { get; set; }
        public double Cuotas { get; set; }
    }
}
