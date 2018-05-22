using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Pagos
{
    public class EstadoPagosViewModels
    {
        public double SaldoAnterior { get; set; }
        public double SaldoActual { get; set; }
        public double MontoPago { get; set; }
        public DateTime FechaPagar { get; set; }
        public DateTime FechaCancelada { get; set; }
        public double MontoMora { get; set; }
        public int Estado { get; set; }
    }

    public class ReportEstadoPagosViewModels
    {
        public double SaldoAnterior { get; set; }
        public double SaldoActual { get; set; }
        public double MontoPago { get; set; }
        public string FechaPagar { get; set; }
        public string FechaCancelada { get; set; }
        public double MontoMora { get; set; }
        public string Estado { get; set; }
    }
}
