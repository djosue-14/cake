using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public class PromocionLote: LoteDecorator
    {
        private ILoteComponent component;

        public PromocionLote(ILoteComponent component)
        {
            this.component = component;
        }

        public override double calcularCostoLote()
        {
            return component.calcularCostoLote() + 20.00;
        }

        public override double calcularSaldoLote()
        {
            throw new NotImplementedException();
        }
    }
}
