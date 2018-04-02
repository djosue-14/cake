using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Intereses
{
    public interface IStrategyInteres
    {
        double calcularInteres(double precioSinEnganche, int tiempoDeFinanciamiento);
    }
}
