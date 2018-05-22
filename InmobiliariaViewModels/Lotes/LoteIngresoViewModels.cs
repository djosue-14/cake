using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Lotes;
using InmobiliariaViewModels.Lotificadora;

namespace InmobiliariaViewModels.Lotes
{
    public class LoteIngresoViewModels
    {
        public int id { get; set; }
        public int numero { get; set; }
        public double largo { get; set; }
        public double ancho { get; set; }
        public double mts_cuadrados { get; set; }
        public double precio_lote { get; set; }
        public int manzana_id { get; set; }
        public int lotificadora_id { get; set; }
        public int estado_id { get; set; }

        public List<LotificadoraViewModels> lotificadoras { get; set; }
        public List<ManzanaLoteViewModels> manzanas { get; set; }
        public List<EstadoLoteViewModels> estados { get; set; }
    }

    
    public class LoteViewModels
    {
        public int id { get; set; }
        public int numero { get; set; }
        public double largo { get; set; }
        public double ancho { get; set; }
        public double mts_cuadrados { get; set; }
        public double precio { get; set; }
        public string manzana { get; set; }
        public string lotificadora { get; set; }
        public string estado { get; set; }
       
       
    }
   

}
