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
        private double cantidadDescuento;
        private double porcentajeDescuento;

        public DescuentoLote(ILoteComponent lote, double cantidadDescuento, double porcentajeDescuento)
        {
            this.lote = lote;
            this.cantidadDescuento = cantidadDescuento;
            this.porcentajeDescuento = porcentajeDescuento;
        }

        public override double calcularMonto()
        {
            double montoDescuento = 0;
            double saldoLote = lote.calcularSaldo();

            if (cantidadDescuento != 0 && porcentajeDescuento == 0)
            {
                montoDescuento = cantidadDescuento;
            }
            if(porcentajeDescuento != 0 && cantidadDescuento == 0)
            {
                montoDescuento = saldoLote * porcentajeDescuento;
            }

            return montoDescuento;;
        }

        public override double calcularSaldo()
        {
            return lote.calcularSaldo() - calcularMonto();
        }
    }
}
