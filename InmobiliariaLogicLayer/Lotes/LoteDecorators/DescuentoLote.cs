using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Descuentos;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public class DescuentoLote: LoteDecorator
    {
        private ILoteComponent component;
        private IStrategyDescuento lotificadoraDescuento;

        public DescuentoLote(ILoteComponent component, IStrategyDescuento lotificadoraDescuento)
        {
            this.component = component;
            this.lotificadoraDescuento = lotificadoraDescuento;
        }
        public override double calcularCostoLote()
        {
            double precio = component.calcularSaldoLote();
            return lotificadoraDescuento.calcularDescuento(precio);
        }

        public override double calcularSaldoLote()
        {
            return component.calcularSaldoLote() - calcularCostoLote();
        }
    }
}
