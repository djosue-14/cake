using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotes;

namespace InmobiliariaLogicLayer.Lotes
{
    public class Manzana
    {
        private ISqlPersistence persistence;
        public Manzana (ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save (ManzanaLoteViewModels datos)
        {
            return persistence.Save(datos);
        }

        public List<ManzanaLoteViewModels> SelectAll()
        {
            return (List < ManzanaLoteViewModels >) persistence.FindAll();
        }

        public ManzanaLoteViewModels SelectForId (int id)
        {
            return (ManzanaLoteViewModels)persistence.FindForId(id);
        }

        public int Update (ManzanaLoteViewModels datos)
        {
            return persistence.Update(datos);
        }
        public int Delete (int id)
        {
            return persistence.Delete(id);
        }

        public IEnumerable<ManzanaLoteViewModels> ManzanaForLote(int id)
        {
            var _manzana = (List<ManzanaLoteViewModels>)persistence.FindAll();
            var manzana = _manzana.Where(x => x.id == id);
            return manzana;
        }

    }
}
