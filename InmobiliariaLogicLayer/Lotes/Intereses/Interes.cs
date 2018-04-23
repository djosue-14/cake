using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Intereses
{
    public class Interes
    {
        private double precioSinEnganche;
        private double tasaInteres;
        private int tiempoDeFinanciamiento;

        public Interes(double precioSinEnganche, double tasaInteres, int tiempoDeFinanciamiento)
        {
            this.precioSinEnganche = precioSinEnganche;
            this.tasaInteres = tasaInteres;
            this.tiempoDeFinanciamiento = tiempoDeFinanciamiento;
        }

        public double CalcularInteres()
        {
            double monto = precioSinEnganche * (1 + tasaInteres * (tiempoDeFinanciamiento / 12));
            return monto;
        }
    }
}
