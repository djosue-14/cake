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
        private double cantidadEnganche;

        public EngancheLote(ILoteComponent lote, double cantidadEnganche)
        {
            this.lote = lote;
            this.cantidadEnganche = cantidadEnganche;
        }

        public override double calcularMonto()
        {
            //return lote.calcularMonto() * 0.10; //- cantidadEnganche;
            return cantidadEnganche;
        }

        public override double calcularSaldo()
        {
            return lote.calcularSaldo() - calcularMonto();
        }
    }
}
