using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels
{
    public class PromocionViewModels
    {
        public int Id { get; set; }
        public double Cantidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int LotificadoraId { get; set; }
    }
}
