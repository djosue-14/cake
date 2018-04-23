using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Intereses;

namespace InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators
{
    public class InteresLote : LoteDecorator
    {
        private ILoteComponent lote;
        //private IStrategyInteres lotificadoraInteres;
        private int tiempoDeFinanciamiento;
        private double tasaInteres;

        //public InteresLote(ILoteComponent lote, IStrategyInteres lotificadoraInteres, int tiempoDeFinanciamiento)
        //{
        //    this.lote = lote;
        //    this.lotificadoraInteres = lotificadoraInteres;
        //    this.tiempoDeFinanciamiento = tiempoDeFinanciamiento;
        //}
        public InteresLote(ILoteComponent lote, double tasaInteres, int tiempoDeFinanciamiento)
        {
            this.lote = lote;
            this.tasaInteres = tasaInteres;
            this.tiempoDeFinanciamiento = tiempoDeFinanciamiento;
        }

        //public override double calcularMonto()
        //{
        //    double precioSinEnganche = lote.calcularSaldo();
        //    return lotificadoraInteres.calcularInteres(precioSinEnganche, tiempoDeFinanciamiento) - precioSinEnganche;
        //}

        public override double calcularMonto()
        {
            double precioSinEnganche = lote.calcularSaldo();
            var interes = new Interes(precioSinEnganche, tasaInteres, tiempoDeFinanciamiento);
            return interes.CalcularInteres() - precioSinEnganche;
        }

        public override double calcularSaldo()
        {
            return lote.calcularSaldo() + calcularMonto();
        }
    }
}
