using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Lotificadora
{
    public class LotificadoraViewModels
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public double tasa_interes { get; set; }
        public double tasa_mora { get; set; }
    }
}
