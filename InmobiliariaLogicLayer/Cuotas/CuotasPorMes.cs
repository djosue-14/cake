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
    public class CuotasPorMes
    {
        private Dictionary<string, double> cantidad;
        private PuntoDecimal punto;

        public CuotasPorMes()
        {
            this.cantidad = new Dictionary<string, double>();
            this.punto = new PuntoDecimal();
        }

        public List<CuotasPorMesViewModels> listaPorMes(CalcularCuotaViewModels data)
        {
            setDataToDictionary(data);
            var listaDeCuotas = new List<CuotasPorMesViewModels>();

            listaDeCuotas.Add(new CuotasPorMesViewModels()
            {
                CuotaConInteres = cantidad["CuotaConInteres"],
                CuotaSinInteres = cantidad["CuotaSinInteres"],
                InteresPorMes = cantidad["InteresPorMes"],
                SaldoPrecioConInteres = punto.dosDecimales(cantidad["SaldoConInteres"]),
                SaldoPrecioSinInteres = punto.dosDecimales(cantidad["SaldoSinInteres"]),
                SaldoInteresTotal = punto.dosDecimales(cantidad["InteresTotal"]),
            });

            for (int i = 1; i <= (int)cantidad["TiempoDeFinanciamiento"]; i++)
            {
                cantidad["SaldoConInteres"] -= cantidad["CuotaConInteres"];
                cantidad["InteresTotal"] -= cantidad["InteresPorMes"];
                cantidad["SaldoSinInteres"] -= cantidad["CuotaSinInteres"];

                listaDeCuotas.Add(new CuotasPorMesViewModels()
                {
                    CuotaConInteres = cantidad["CuotaConInteres"],
                    CuotaSinInteres = cantidad["CuotaSinInteres"],
                    InteresPorMes = cantidad["InteresPorMes"],
                    SaldoPrecioConInteres = punto.dosDecimales(cantidad["SaldoConInteres"]),
                    SaldoPrecioSinInteres = punto.dosDecimales(cantidad["SaldoSinInteres"]),
                    SaldoInteresTotal = punto.dosDecimales(cantidad["InteresTotal"]),
                });
            }

            return listaDeCuotas;
        }

        public void setDataToDictionary(CalcularCuotaViewModels data)
        {
            cantidad.Add("TiempoDeFinanciamiento", data.tiempo);

            ILoteComponent lote = new PrecioLote(data.cantidad);
            lote = new EngancheLote(lote, data.enganche);
            cantidad.Add("SaldoSinInteres", lote.calcularSaldo());

            //lote = new InteresLote(lote, new InteresPerlas(), (int)cantidad["TiempoDeFinanciamiento"]);
            lote = new InteresLote(lote, data.interes, data.tiempo);
            cantidad.Add("InteresTotal", lote.calcularMonto());
            cantidad.Add("SaldoConInteres", lote.calcularSaldo());

            addCuotaConInteres();
            addCuotaSinInteres();
            addInteresPorMes();
        }

        public void addCuotaConInteres()
        {
            double cuotaConInteres = cantidad["SaldoConInteres"] / cantidad["TiempoDeFinanciamiento"];
            cantidad.Add("CuotaConInteres", punto.dosDecimales(cuotaConInteres));
        }

        public void addCuotaSinInteres()
        {
            double cuotaSinInteres = cantidad["SaldoSinInteres"] / cantidad["TiempoDeFinanciamiento"];
            cantidad.Add("CuotaSinInteres", punto.dosDecimales(cuotaSinInteres));
        }

        public void addInteresPorMes()
        {
            double interesPorMes = cantidad["InteresTotal"] / cantidad["TiempoDeFinanciamiento"];
            cantidad.Add("InteresPorMes", punto.dosDecimales(interesPorMes));
        }
    }
}
