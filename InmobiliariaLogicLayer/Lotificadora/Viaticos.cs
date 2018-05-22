using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotificadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotificadora
{
    public class Viaticos
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public Viaticos(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(ViaticosViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(ViaticosViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<VistaViaticosViewModels> SelectAll()
        {
            return (List<VistaViaticosViewModels>)persistence.FindAll();
        }

        public ViaticosViewModels SelectForId(int id)
        {
            return (ViaticosViewModels)persistence.FindForId(id);
        }
    }
}