using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Intereses.InteresStrategies
{
    public class InteresRefugio: IStrategyInteres
    {
        public double calcularInteres(double precioSinEnganche, int tiempoDeFinanciamiento)
        {
            double tasaDeInteres = 0.12;
            double monto = precioSinEnganche * (1 + tasaDeInteres * (tiempoDeFinanciamiento / 12));
            return monto;
        }
    }
}
