using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Empleados
{
    public class EmpleadosIngresoViewModels
    {
        public int id { get; set; }
        public string nombre_e { get; set; }
        public string apellido_e { get; set; }
        public long dpi_e { get; set; }
        public int tel_e { get; set; }
        public int sexo_e { get; set; }
        public DateTime fecha_nac_e { get; set; }
        public string dire_e { get; set; }
       
        public int cargo_e { get; set; }
        public int estado_e { get; set; }

        //
        public List<CargoEmpViewModels> cargos { get; set; }

        public List<EstadoEmpViewModels> estados { get; set; }
        public IEnumerable<ReferenciaEmpViewModels> referencias { get; set; }
    }
}