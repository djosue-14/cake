using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public class EngancheLote: LoteDecorator
    {
        private ILoteComponent component;

        public EngancheLote(ILoteComponent component)
        {
            this.component = component;
        }

        public override double calcularCostoLote()
        {
            return component.calcularCostoLote() * 0.10;
        }

        public override double calcularSaldoLote()
        {
            return component.calcularCostoLote() - calcularCostoLote();
        }
    }
}
