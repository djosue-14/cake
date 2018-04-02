using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Lotes;

namespace InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators
{
    public class ReservaLote: LoteDecorator
    {
        private ILoteComponent lote;

        public ReservaLote(ILoteComponent lote)
        {
            this.lote = lote;
        }
        public override double calcularMonto()
        {
            return 1000;
        }

        public override double calcularSaldo()
        {
            return lote.calcularSaldo() - calcularMonto();
        }
    }
}
