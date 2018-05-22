using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Lotes;
namespace InmobiliariaLogicLayer.Lotes
{
    public class EstadoLote
    {
        private ISqlPersistence persistence;
        public EstadoLote (ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save (EstadoLoteViewModels datos)
        {
            return persistence.Save(datos);
        }

        public List<EstadoLoteViewModels> SelectAll()
        {
            return (List<EstadoLoteViewModels>)persistence.FindAll();
        }

        public EstadoLoteViewModels SelectForId(int id)
        {
            return (EstadoLoteViewModels)persistence.FindForId(id);
        }

        public int Update(EstadoLoteViewModels datos)
        {
            return persistence.Update(datos);
        }

        public int Delete (int id)
        {
            return persistence.Delete(id);
        }
    }
}
