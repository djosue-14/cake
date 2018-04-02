using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Decimales
{
    public class PuntoDecimal
    {
        public double dosDecimales(double cantidad)
        {
            string dosDecimales = String.Format("{0:0.00}", cantidad);
            return Convert.ToDouble(dosDecimales);
        }
    }
}
