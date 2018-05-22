using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotificadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotificadora
{
    public class Lotificadora
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public Lotificadora(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(LotificadoraViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(LotificadoraViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<LotificadoraViewModels> SelectAll()
        {
            return (List<LotificadoraViewModels>)persistence.FindAll();
        }

        public LotificadoraViewModels SelectForId(int id)
        {
            return (LotificadoraViewModels)persistence.FindForId(id);
        }
    }
}
