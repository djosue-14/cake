using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.EstadoCuenta
{
    public class PagosSelectViewModels
    {
        public double saldo_anterior { get; set; }
        public double saldo_actual { get; set; }
        public double monto { get; set; }
        public DateTime fecha_pagar { get; set; }
        public DateTime fecha_cancelada { get; set; }
    }
}
