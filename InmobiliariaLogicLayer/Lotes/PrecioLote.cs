using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes
{
    public class PrecioLote: ILoteComponent
    {
        private double capitalACalcular;

        public PrecioLote(double capitalACalcular)
        {
            this.capitalACalcular = capitalACalcular;
        }

        public double calcularCostoLote()
        {
            return capitalACalcular;
        }

        public double calcularSaldoLote()
        {
            return capitalACalcular;
        }

    }
}
