using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;

namespace InmobiliariaLogicLayer.Clientes
{
    public class Referencia
    {
        private ISqlPersistence persistence;

        public Referencia (ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save (ClienteReferenciaViewModels datos)
        {
            return persistence.Save(datos);
        }

        public List<ClienteReferenciaViewModels> SelectAllReferencia ()
        {
            return (List<ClienteReferenciaViewModels>)persistence.FindAll();
        }

        public int Update (ClienteReferenciaViewModels datos)
        {
            return persistence.Update(datos);
        }

        public IEnumerable<ClienteReferenciaViewModels> RefForCliente(int id)
        {
            var _referencias = (List<ClienteReferenciaViewModels>)persistence.FindAll();
            var referencias = _referencias.Where(x => x.ClienteId == id);
            return referencias;
        }
    }
}
