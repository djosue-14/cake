using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaLogicLayer.Persistence;

namespace InmobiliariaLogicLayer.Cuotas.Moras
{
    public class MoraSimple
    {
        private ISelectForId selectForId;
        private ISave save;

        public MoraSimple(ISelectForId selectForId, ISave save)
        {
            this.selectForId = selectForId;
            this.save = save;
        }

        public CalcularMoraViewModels FindForId(int id)
        {
            var ultimaCuotaCancelada = (CalcularMoraViewModels)selectForId.FindForId(1);
            return ultimaCuotaCancelada;
        }

        private int Save(MoraSaveViewModels moras)
        {
            return save.Save(moras);
        }

        public int CalcularMora(CalcularMoraViewModels datos)
        {
            int estado = -1;
            var ultimaFecha = datos.fecha;
            var fechaMora = ultimaFecha.AddDays(11);//10 dias de gracia, a partir del 11 se cobra mora.
            var fechaActual = DateTime.Today;

            var mora = new MoraSaveViewModels();

            while (fechaMora <= fechaActual)
            {
                int diasDelMes = DateTime.DaysInMonth(fechaMora.Year, fechaMora.Month);

                fechaMora = fechaMora.AddMonths(1);

                //rompe el ciclo, para evitar crear una nueva mora en el mes que aun no termina.
                if (fechaMora > fechaActual)
                {
                    break;
                }

                mora.fecha = fechaMora.AddDays(-11);
                mora.monto = ((datos.cuota * datos.tasaMora) / 30) * diasDelMes;
                estado = Save(mora);
            }

            return estado;
        }
    }
}
