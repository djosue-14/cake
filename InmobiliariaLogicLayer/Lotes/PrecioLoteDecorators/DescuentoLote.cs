using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Descuentos;

namespace InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators
{
    public class DescuentoLote: LoteDecorator
    {
        private ILoteComponent lote;
        private IStrategyDescuento lotificadoraDescuento;

        public DescuentoLote(ILoteComponent lote, IStrategyDescuento lotificadoraDescuento)
        {
            this.lote = lote;
            this.lotificadoraDescuento = lotificadoraDescuento;
        }
        public override double calcularMonto()
        {
            double saldoLote = lote.calcularSaldo();
            return lotificadoraDescuento.calcularDescuento(saldoLote);
        }

        public override double calcularSaldo()
        {
            return lote.calcularSaldo() - calcularMonto();
        }
    }
}
