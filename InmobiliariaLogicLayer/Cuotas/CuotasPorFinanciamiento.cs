using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators;
using InmobiliariaLogicLayer.Intereses;
using InmobiliariaLogicLayer.Decimales;

namespace InmobiliariaLogicLayer.Cuotas
{
    public class CuotasPorFinanciamiento
    {
        private PuntoDecimal punto;
        public CuotasPorFinanciamiento()
        {
            this.punto = new PuntoDecimal();
        }

        public List<CuotasPorFinanciamientoViewModels> listaPorFinanciamiento(CalcularCuotaViewModels data)
        {
            var listaDeCuotas = new List<CuotasPorFinanciamientoViewModels>();

            ILoteComponent lote = new PrecioLote(data.cantidad);
            lote = new EngancheLote(lote);
            ILoteComponent loteInteres = new EngancheLote(lote);
            double enganche = punto.dosDecimales(lote.calcularMonto());
            double precioNeto = punto.dosDecimales(lote.calcularSaldo());

            while (data.tiempo <= 120)
            {
                loteInteres = new InteresLote(lote, new InteresPerlas(), data.tiempo);
                listaDeCuotas.Add(
                    new CuotasPorFinanciamientoViewModels()
                    {
                        PrecioBruto = data.cantidad,
                        Meses = data.tiempo,
                        Enganche = enganche,
                        PrecioNeto = precioNeto,
                        InteresTotal = punto.dosDecimales(loteInteres.calcularMonto()),
                        PrecioTotal = punto.dosDecimales(loteInteres.calcularSaldo()),
                        Cuotas = punto.dosDecimales(loteInteres.calcularSaldo() / data.tiempo)
                    });

                data.tiempo += 12;
            }

            return listaDeCuotas;
        }

    }
}
