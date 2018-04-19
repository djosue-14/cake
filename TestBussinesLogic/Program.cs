using System;
using System.Collections.Generic;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaDataLayer.Pagos;
using InmobiliariaViewModels.EstadoCuenta;

namespace TestBussinesLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Inmobiliaria!");

            DBMoras moras = new DBMoras();
            var listMoras = (List<MoraSelectViewModels>)moras.FindForId(1);

            DBPagos pagos = new DBPagos();
            var listPagos = (List<PagosSelectViewModels>)pagos.FindForId(1);

            //foreach (var pago in listPagos)
            //{
            //    Console.WriteLine(pago.saldo_anterior+" --- "+pago.saldo_actual);
            //}
            
            foreach (var pago in listPagos)
            {
                Console.Write("\n | " + pago.saldo_anterior + " | " + pago.saldo_actual
                    + " | " + pago.monto + " | " + pago.fecha_pagar.ToString("dd/MM/yyyy") 
                    + " | " + pago.fecha_cancelada.ToString("dd/MM/yyyy"));

                foreach (var mora in listMoras)
                {
                    if (mora.fecha == pago.fecha_pagar)
                    {
                        Console.WriteLine(" | " + mora.monto);
                        listMoras.Remove(mora);
                        break;
                    }
                }
            }

            foreach (var mora in listMoras)
            {
                Console.WriteLine("                                 | "+mora.monto);
            }
            //Console.WriteLine("Sali");

            Console.ReadKey();
        }
    }
}
