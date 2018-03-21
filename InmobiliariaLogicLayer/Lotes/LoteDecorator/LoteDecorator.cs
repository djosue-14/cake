using System;
using System.Collections.Generic;
using System.Linq;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public abstract class LoteDecorator: ILoteComponent
    {
        public abstract double calcularCostoLote();

        public abstract double calcularSaldoLote();
    }
}
