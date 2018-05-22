using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Clientes
{
    public class EstadoCli
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public EstadoCli(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(EstadoCliViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(EstadoCliViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<EstadoCliViewModels> SelectAll()
        {
            return (List<EstadoCliViewModels>)persistence.FindAll();
        }

        public EstadoCliViewModels SelectForId(int id)
        {
            return (EstadoCliViewModels)persistence.FindForId(id);
        }

    }
}
