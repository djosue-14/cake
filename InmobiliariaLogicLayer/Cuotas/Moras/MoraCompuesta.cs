using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaLogicLayer.Persistence;

namespace InmobiliariaLogicLayer.Cuotas.Moras
{
    public class MoraCompuesta: Mora
    {
        private ISelectForId selectForId;
        private ISave save;

        public MoraCompuesta(ISelectForId selectForId, ISave save)
            :base(selectForId, save)
        {
            this.selectForId = selectForId;
            this.save = save;
        }
        public override double MontoMora(CalcularMoraViewModels datos)
        {
            double mora = ((datos.cuota * datos.tasaMora) / 30); //* datos.dias;
            return mora;
        }
    }
}
