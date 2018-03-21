using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Intereses;
using InmobiliariaLogicLayer.Intereses.InteresStrategies;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public class InteresLote : LoteDecorator
    {
        private ILoteComponent component;
        private IStrategyInteres lotificadoraInteres;
        private int tiempoDeFinanciamiento;

        public InteresLote(ILoteComponent component, IStrategyInteres lotificadoraInteres, int tiempoDeFinanciamiento)
        {
            this.component = component;
            this.lotificadoraInteres = lotificadoraInteres;
            this.tiempoDeFinanciamiento = tiempoDeFinanciamiento;
        }

        public override double calcularCostoLote()
        {
            double precioSinEnganche = component.calcularSaldoLote();
            return lotificadoraInteres.calcularInteres(precioSinEnganche, tiempoDeFinanciamiento) - precioSinEnganche;
        }

        public override double calcularSaldoLote()
        {
            return component.calcularSaldoLote() + calcularCostoLote();
        }
    }
}
