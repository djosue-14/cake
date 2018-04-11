using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Cuotas.Moras
{
    public class MoraSimple: Mora
    {
        public override double MontoMora(double cuota, double tasa, int diasTranscurridos)
        {
            double mora = ((cuota * tasa) / 30) * diasTranscurridos;
            return mora;
        }

    }
}
