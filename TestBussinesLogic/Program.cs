using System;
using System.Collections.Generic;
using InmobiliariaLogicLayer.Intereses.InteresStrategies;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaLogicLayer.Lotes.LoteDecorators;
using InmobiliariaViewModels.Cuotas;

namespace TestBussinesLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*InteresLotificadora interes = new InteresLotificadora(new InteresPerlas());
            Console.WriteLine("Perlas: " + interes.calcularInteres());
            interes = new InteresLotificadora(new InteresRefugio());
            Console.WriteLine("Refugio: " + interes.calcularInteres());
            interes = new InteresLotificadora(new InteresAmerica());
            Console.WriteLine("America: " + interes.calcularInteres());
            interes = new InteresLotificadora(new InteresCondado());
            Console.WriteLine("Condado: " + interes.calcularInteres());//*/


            //double[] variablesCuotas = new double[3];
            Dictionary<string, double> dictionary = new Dictionary<string, double>();
            //enum la { x};

            //ILoteComponent lote = new Lote();
            ILoteComponent lote = new PrecioLote(65000);
            Console.WriteLine("Precio Total: " + lote.calcularCostoLote());
            lote = new EngancheLote(lote);
            Console.WriteLine("Enganche: "+ lote.calcularCostoLote());
            Console.WriteLine("Precio Sin Enganche: "+ lote.calcularSaldoLote());

            dictionary.Add("TiempoDeFinanciamiento", 12);
            dictionary.Add("SaldoSinInteres", lote.calcularSaldoLote());
            //Interes
            lote = new InteresLote(lote, new InteresPerlas(), (int)dictionary["TiempoDeFinanciamiento"]);
            Console.WriteLine("Interes: "+ lote.calcularCostoLote());
            Console.WriteLine("Precio mas interes: "+lote.calcularSaldoLote());

            dictionary.Add("InteresTotal", lote.calcularCostoLote());
            dictionary.Add("SaldoConInteres", lote.calcularSaldoLote());
            CuotasLote cuotas = new CuotasLote(dictionary);


            foreach(CuotasViewModels cuota in cuotas.cuotas())
            {
                Console.WriteLine(cuota.CuotaSinInteres + "       " + cuota.InteresPorMes + "       " 
                    + cuota.CuotaConInteres + "        " + cuota.SaldoPrecioSinInteres
                        + "         " + cuota.SaldoInteresTotal + "      " + cuota.SaldoPrecioConInteres);
            }
            //Console.WriteLine("Cuotas De: "+cuotas.cuotas());
            //cuotas.cuotas();

            //lote = new DescuentoLote(lote, new DescuentoPerlas());
            //Console.WriteLine("Descueto: "+lote.calcularCostoLote());
            //Console.WriteLine("Precio menos descuento: " + lote.calcularSaldoLote());

            Console.ReadKey();
        }
    }
}
