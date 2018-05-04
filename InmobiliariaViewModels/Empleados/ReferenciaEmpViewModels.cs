using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Empleados
{
    public class ReferenciaEmpViewModels
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int tel { get; set; }
        public string direccion { get; set; }

        public int id_emp { get; set; }
    }
}
