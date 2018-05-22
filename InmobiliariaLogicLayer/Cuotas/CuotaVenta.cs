using InmobiliariaLogicLayer.Decimales;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaLogicLayer.Lotes.PrecioLoteDecorators;
using InmobiliariaViewModels.Cuotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Cuotas
{
    public class CuotaVenta
    {
        private PuntoDecimal punto;
        
        public CuotaVenta()
        {
            punto = new PuntoDecimal();
        }
        
        public CuotaVentaViewModels CalcularDescuento(CuotaVentaViewModels datos)
        {
            var cuota = new CuotaVentaViewModels();
            ILoteComponent lote = new PrecioLote(datos.cantidad);
            //cuota.cantidad = datos.cantidad;

            lote = new DescuentoLote(lote, datos.descuento, 0);
            cuota.descuento = lote.calcularMonto();

            lote = new EngancheLote(lote, datos.enganche);
            cuota.enganche = lote.calcularMonto();

            cuota.cantidad = lote.calcularSaldo();

            lote = new InteresLote(lote, datos.interes, datos.tiempo);
            cuota.interes = punto.dosDecimales(lote.calcularMonto());

            cuota.tiempo = datos.tiempo;
            cuota.cuota = (cuota.cantidad + cuota.interes)/ datos.tiempo;

            return cuota;
        }

        public CuotaVentaViewModels CalcularSinDescuento(CuotaVentaViewModels datos)
        {
            var cuota = new CuotaVentaViewModels();
            ILoteComponent lote = new PrecioLote(datos.cantidad);
            //cuota.cantidad = lote.calcularMonto();

            lote = new EngancheLote(lote, datos.enganche);
            cuota.enganche = lote.calcularMonto();

            cuota.cantidad = lote.calcularSaldo();

            lote = new InteresLote(lote, datos.interes, datos.tiempo);
            cuota.interes = punto.dosDecimales(lote.calcularMonto());

            cuota.tiempo = datos.tiempo;
            cuota.cuota = (cuota.cantidad + cuota.interes) / datos.tiempo;

            return cuota;
        }
    }
}
