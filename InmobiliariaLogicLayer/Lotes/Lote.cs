using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes
{
    public class Lote: ILoteComponent
    {
        //private double Id;
        //variable que obtiene el precio de la base de datos.

        //public Lote(double Id)
        //{
            //this.precioOne = precioOne;
        //}

        public double calcularCostoLote()
        {
            return 65000;
            //return precioOne;
        }

        public double calcularSaldoLote()
        {
            return 65000;
        }
    }
}
