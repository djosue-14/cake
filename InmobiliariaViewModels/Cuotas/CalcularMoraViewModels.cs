using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Cuotas
{
    public class CalcularMoraViewModels
    {
        public double saldo { get; set; }
        public DateTime fecha { get; set; }
        public double cuota { get; set; }
        public double tasaMora { get; set; }
    }
}
