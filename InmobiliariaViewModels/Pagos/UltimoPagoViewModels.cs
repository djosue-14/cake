using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Pagos
{
    public class UltimoPagoViewModels
    {
        public double Saldo_Anterior { get; set; }

        public double Saldo_Actual { get; set; }

        public double Monto { get; set; }

        public DateTime Fecha_Pagar { get; set; }

        public DateTime Fecha_Cancelada { get; set; }

        public int Venta_id { get; set; }

        public double Cuota { get; set; }
        //public List<UltimoPagoViewModels> Pagos { get; set; }
    }
    
}
