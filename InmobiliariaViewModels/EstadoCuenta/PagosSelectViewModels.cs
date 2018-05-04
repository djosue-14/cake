using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.EstadoCuenta
{
    public class PagosSelectViewModels
    {
        public double SaldoAnterior { get; set; }
        public double SaldoActual { get; set; }
        public double Monto { get; set; }
        public DateTime FechaPagar { get; set; }
        public DateTime FechaCancelada { get; set; }
    }
}
