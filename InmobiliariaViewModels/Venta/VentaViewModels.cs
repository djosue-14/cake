using InmobiliariaViewModels.Clientes;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaViewModels.Empleados;
using InmobiliariaViewModels.Lotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Venta
{
    public class VentaViewModels
    {
        public int Id { get; set; }
        public int EmpVentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        
        public int TipoVentaId { get; set; }


        public int LoteId { get; set; }
        //Datos pre-venta
        
        public ClienteInsertViewModels Cliente { get; set; }
        public List<EmpleadosIngresoViewModels> Empleados { get; set; }

        public IEnumerable<LoteViewModels> Lotes { get; set; }
        public EmpleadosIngresoViewModels Empleado { get; set; }

        public LoteIngresoViewModels Lote { get; set; }
        
        public CuotaVentaViewModels Cuota { get; set; }
    }
}
