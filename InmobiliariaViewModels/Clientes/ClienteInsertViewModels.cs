using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Clientes
{
    public class ClienteInsertViewModels
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dpi { get; set; }
        public string telefono { get; set; }
        public DateTime fecha { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        
        public int estado { get; set; }


        // public int id { get; set; }

        //listas
        public List<EstadoCliViewModels> estados { get; set; }
        public IEnumerable<ClienteReferenciaViewModels> referencias { get; set; }
        public IEnumerable<BeneficiarioViewModels> beneficiario { get; set; }
    }
}
