using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Cuotas
{
    public class MoraViewModels
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public int VentaId { get; set; }
    }

    public class CalcularMoraViewModels
    {
        public double Saldo { get; set; }
        public DateTime Fecha { get; set; }
        public double Cuota { get; set; }
        public double TasaMora { get; set; }
    }
}
