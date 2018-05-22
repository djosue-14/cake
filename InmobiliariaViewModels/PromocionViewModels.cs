using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Lotificadora;

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

        public List<LotificadoraViewModels> Lotificadoras { get; set; }
    }

    public class PromoViewModels
    {
        public List<PromocionViewModels> Promociones { get; set; }
        public List<LotificadoraViewModels> Lotificadoras { get; set; }
    }
}
