using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Cuotas
{
    public class MoraSelectViewModels
    {
        public int id { get; set; }
        public double monto { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public int venta_id { get; set; }
    }
}
