using System;
using System.Collections.Generic;
using InmobiliariaLogicLayer.Intereses;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaViewModels;
using InmobiliariaDataLayer.Lote;

namespace TestBussinesLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Inmobiliaria!");
            InteresRepository interes = new InteresRepository();
            var list = (List<TestInteresViewModels>)interes.FindAll();
            foreach (var item in list)
            {
                Console.WriteLine("Lotificadora: "+item.nombre);
                Console.WriteLine("Interes: "+item.interes);
            }
            Console.ReadKey();
        }
    }
}
