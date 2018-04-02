using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators
{
    public class PromocionLote: LoteDecorator
    {
        private ILoteComponent component;

        public PromocionLote(ILoteComponent component)
        {
            this.component = component;
        }

        public override double calcularMonto()
        {
            return component.calcularMonto() + 20.00;
        }

        public override double calcularSaldo()
        {
            throw new NotImplementedException();
        }
    }
}
