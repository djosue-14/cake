using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators
{
    public class EngancheLote: LoteDecorator
    {
        private ILoteComponent lote;

        public EngancheLote(ILoteComponent lote)
        {
            this.lote = lote;
        }

        public override double calcularMonto()
        {
            return lote.calcularMonto() * 0.10;
        }

        public override double calcularSaldo()
        {
            return lote.calcularSaldo() - calcularMonto();
        }
    }
}
