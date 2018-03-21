using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Cuotas;

namespace InmobiliariaLogicLayer.Lotes.LoteDecorators
{
    public class CuotasLote
    {
        Dictionary<string, double> dictionary;

        public CuotasLote(Dictionary<string, double> dictionary)
        {
            this.dictionary = dictionary;
            calcularCuotaConInteres();
            calcularCuotaSinInteres();
            calcularInteresPorMes();
        }

        public List<CuotasViewModels> cuotas()
        {
            List<CuotasViewModels> listaDeCuotas = new List<CuotasViewModels>();

            for (int i = 1; i <= (int)dictionary["TiempoDeFinanciamiento"]; i++)
            {
                dictionary["SaldoConInteres"] -= dictionary["CuotaConInteres"];
                dictionary["InteresTotal"] -= dictionary["InteresPorMes"];
                dictionary["SaldoSinInteres"] -= dictionary["CuotaSinInteres"];

                listaDeCuotas.Add(new CuotasViewModels()
                {
                    CuotaConInteres = dictionary["CuotaConInteres"],
                    CuotaSinInteres = dictionary["InteresPorMes"],
                    InteresPorMes = dictionary["CuotaSinInteres"],
                    SaldoPrecioConInteres = dictionary["SaldoConInteres"],
                    SaldoPrecioSinInteres = dictionary["SaldoSinInteres"],
                    SaldoInteresTotal = dictionary["InteresTotal"],
                });
            }

            return listaDeCuotas;
        }

        public void calcularCuotaConInteres()
        {
            double cuotaConInteres = dictionary["SaldoConInteres"] / dictionary["TiempoDeFinanciamiento"];
            dictionary.Add("CuotaConInteres", cuotaConInteres);
        }

        public void calcularCuotaSinInteres()
        {
            double cuotaSinInteres = dictionary["SaldoSinInteres"] / dictionary["TiempoDeFinanciamiento"];
            dictionary.Add("CuotaSinInteres", cuotaSinInteres);
        }

        public void calcularInteresPorMes()
        {
            double interesPorMes = dictionary["InteresTotal"] / dictionary["TiempoDeFinanciamiento"];
            dictionary.Add("InteresPorMes", interesPorMes);
        }
    }
}
