using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotificadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotificadora
{
    public class Gastos
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public Gastos(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(GastosViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(GastosViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<VistaGastoViewModels> SelectAll()
        {
            return (List<VistaGastoViewModels>)persistence.FindAll();
        }

        public GastosViewModels SelectForId(int id)
        {
            return (GastosViewModels)persistence.FindForId(id);
        }
    }
}