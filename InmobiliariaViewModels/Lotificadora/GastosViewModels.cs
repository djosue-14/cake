using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Empleados;

namespace InmobiliariaViewModels.Lotificadora
{
    public class GastosViewModels
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public double cantidad { get; set; }
        public string descripcion { get; set; }
        public int lotificadora_id { get; set; }
        public int empleado_id { get; set; }

        public List<LotificadoraViewModels> lotificadoras { get; set; }
        public List<EmpleadosIngresoViewModels> empleados { get; set; }
    }

    public class VistaGastoViewModels
    {
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public double cantidad { get; set; }
        public string descripcion { get; set; }
        public string lotificadora { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
