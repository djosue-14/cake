using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;

namespace InmobiliariaLogicLayer.Clientes
{
   public class Cliente
    {
        private ISqlPersistence persistence;

        public Cliente (ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save (ClienteInsertViewModels datos)
        {
            return persistence.Save(datos); 
        }

        public List<ClienteInsertViewModels> SelectAllCliente ()
        {
            return (List<ClienteInsertViewModels>)persistence.FindAll();
        }

        public ClienteInsertViewModels SelectForId( int id)
        {
            return (ClienteInsertViewModels)persistence.FindForId(id);
        }

        public int Update (ClienteInsertViewModels datos)
        {
            return persistence.Update(datos);
        }

        public int Delete (int id)
        {
            return persistence.Delete(id);
        }       
    }
}