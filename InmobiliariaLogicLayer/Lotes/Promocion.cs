using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels;

namespace InmobiliariaLogicLayer.Lotes
{
    public class Promocion
    {
        private ISave _save;
        private ISelectForId _selectForId;
        private IUpdate _update;
        private ISelectAll _selectAll;

        public int Save(PromocionViewModels data)
        {
            return _save.Save(data);
        }

        public int Update(PromocionViewModels data)
        {
            return _update.Update(data);
        }

        public PromocionViewModels SelectForId(int id)
        {
            var promociones = (PromocionViewModels)_selectForId.FindForId(id);
            return promociones;
        }

        public IEnumerable<PromocionViewModels> FindForLotificadora(int id)
        {
            var promociones = (List<PromocionViewModels>)_selectAll.FindAll();
            var promos = promociones.Where(x => x.LotificadoraId == id);

            return promos;
        }

        public List<PromocionViewModels> GetAll()
        {
            var promociones = (List<PromocionViewModels>)_SelectAll.FindAll();
            return promociones;
        }

        public ISave _Save
        {
            private get { return _save; }
            set { _save = value; }
        }

        public ISelectForId _SelectForId
        {
            private get { return _selectForId; }
            set { _selectForId = value; }
        }

        public IUpdate _Update
        {
            private get { return _update; }
            set { _update = value; }
        }
        public ISelectAll _SelectAll
        {
            private get { return _selectAll; }
            set { _selectAll = value; }
        }
    }
}
