using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Clientes
{
    public class ListaClientViewModels
    {

        public double nombre { get; set; }
        public double apellido { get; set; }
        public double dpi { get; set; }
        public double telefono { get; set; }
        public DateTime fecha { get; set; }
        public double sexo { get; set; }
        public double direccion { get; set; }
        
        public int estado { get; set; }
     

        public int id { get; set; }
        //  select nombre, apellido, dpi, telefono, sexo, direccion  from Cliente
        //
        //               where id = '1'
    }

}
