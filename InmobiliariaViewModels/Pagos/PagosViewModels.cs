using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Pagos
{
    public class PagosViewModels
    {
        public int Id { get; set; }
        public double SaldoAnterior { get; set; }
        public double SaldoActual { get; set; }
        public double Monto { get; set; }
        public DateTime FechaPagar { get; set; }
        public DateTime FechaCancelada { get; set; }
        public int VentaId { get; set; }
    }
}
