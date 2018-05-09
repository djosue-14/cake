using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Clientes
{
    public class ClienteUpdateViewModels
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dpi { get; set; }
        public string telefono { get; set; }
        public float fecha { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        
        public int estado { get; set; }
        
        

        //    update Cliente set nombre = 'Cristian', apellido= 'Vásquez', dpi='2168088040920', telefono = '42438165',
     //   fecha = '23/12/1992', sexo = 'M', direccion = 'Coatepeque', beneficiario_id = 1, estado_id =1, referencia_id=1
     //  where id = '1';
    }
}
