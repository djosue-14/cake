using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Lotes;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public class ReservaLote: LoteDecorator
    {
        private ILoteComponent component;

        public ReservaLote(ILoteComponent  component)
        {
            this.component = component;
        }
        public override double calcularCostoLote()
        {
            return 1000;
        }

        public override double calcularSaldoLote()
        {
            return component.calcularSaldoLote() - calcularCostoLote();
        }
    }
}
