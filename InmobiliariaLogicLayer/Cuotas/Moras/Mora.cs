using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Cuotas.Moras
{
    public abstract class Mora
    {
        public abstract double MontoMora(double cuota, double tasa, int diasTranscurridos);
        
        public int DiasTranscurridos(DateTime fechaUltimoPago)
        {
            DateTime fechaActual = DateTime.Today;
            int diasTranscurridos;

            /*  Resta a la fecha actual la fecha del ultimo mes cancelado
                Toma solo los dias con la funcion ToString("dd")
                Convierte a entero.
            */
            diasTranscurridos = Convert.ToInt16(fechaActual.Subtract(fechaUltimoPago).ToString("dd"));

            return diasTranscurridos;
        }

        
    }
}
