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

        public Lote(ISqlPersistence persistence)
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

        public int Delete(int id)
        {
            return persistence.Delete(id);
        }

        public int Update(LoteIngresoViewModels datos)
        {
            return persistence.Update(datos);
        }

        public LoteIngresoViewModels SelectForId(int id)
        {
            return (LoteIngresoViewModels)persistence.FindForId(id);
        }

        public IEnumerable<LoteViewModels> FindLoti(string lotificadora)
        {
            var _lotes = (List<LoteViewModels>)persistence.FindAll();
            var lote = _lotes.Where(x => x.lotificadora == lotificadora);
            return lote;
        }

        public IEnumerable<LoteViewModels> FindEstadoLoti()
        {
            var _lotes = (List<LoteViewModels>)persistence.FindAll();
            var lote = _lotes.Where(x => x.estado == "Disponible");
            return lote;
        }
    }
}
