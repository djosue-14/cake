using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Pagos
{
    public class EstadoPagosViewModels
    {
        public double saldo_anterior { get; set; }
        public double saldo_actual { get; set; }
        public double monto_pago { get; set; }
        public DateTime fecha_pagar { get; set; }
        public DateTime fecha_cancelada { get; set; }
        public double monto_mora { get; set; }
        public int estado { get; set; }
    }
}
