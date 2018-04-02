using System;
using System.Collections.Generic;
using System.Linq;

namespace InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators
{
    public abstract class LoteDecorator: ILoteComponent
    {
        public abstract double calcularMonto();

        public abstract double calcularSaldo();
    }
}
