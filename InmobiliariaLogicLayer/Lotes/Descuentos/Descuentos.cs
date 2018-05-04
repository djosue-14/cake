using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Descuentos;

namespace InmobiliariaLogicLayer.Descuentos
{
    public class Descuentos
    {
        public double calcularDescuento(double precio)
        {
            return precio * 0.08;
        }
    }
}
