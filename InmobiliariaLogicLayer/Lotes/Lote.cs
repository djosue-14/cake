using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotes;

namespace InmobiliariaLogicLayer.Lotes
{
    public class Lote
    {
        private ISqlPersistence persistence;

        public Lote (ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(LoteIngresoViewModels datos)
        {
            return persistence.Save(datos);
        }

     

        public List<LoteViewModels> SelectAllLote()
        {
            return (List<LoteViewModels>)persistence.FindAll();
        }
    }
}
