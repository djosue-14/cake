using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaLogicLayer.Persistence;

namespace InmobiliariaLogicLayer.Cuotas.Moras
{
    public class Moras
    {
        private ISelectForId dbForId;
        private ISave dbSave;

        public ISelectForId DbForId
        {
            private get { return dbForId; }
            set { dbForId = value; }
        }

        public ISave Dbsave
        {
            private get { return dbSave; }
            set { dbSave = value; }
        }

        //obtiene la fecha de la ultima mora calculada
        //public DateTime FechaUltimaMora(int id)
        //{
        //    var list = (List<MoraViewModels>)dbForId.FindForId(id);
        //    MoraViewModels _mora;
        //     _mora = list.OrderByDescending(x => x.Fecha).First();
        //    DateTime fechaUltimaMora = _mora.Fecha;
        //    return fechaUltimaMora;
            
        //}

        public CalcularMoraViewModels FindForId(int id)
        {
            var ultimaCuotaCancelada = (CalcularMoraViewModels)dbForId.FindForId(id);
            return ultimaCuotaCancelada;
        }

        private int Save(MoraViewModels moras)
        {
            return dbSave.Save(moras);
        }

        public int CalcularMora(CalcularMoraViewModels datos)
        {
            int estado = -1;
            var mora = new MoraViewModels();
            var ultimaFecha = datos.Fecha;//fecha de la ultima cuota pagada.
            var fechaMora = ultimaFecha.AddDays(9);//10 dias de gracia, a partir del 11 se cobra mora.
            var fechaActual = DateTime.Today;
            //DateTime fecha = new DateTime(1901, 01, 01);

            if (ultimaFecha != new DateTime(0001, 1, 1))
            {
                while (fechaMora <= fechaActual)
                {
                    //cuenta los dias que tiene el mes
                    int diasDelMes = DateTime.DaysInMonth(fechaMora.Year, fechaMora.Month);
                    fechaMora = fechaMora.AddMonths(1);//agrega un mes.

                    //rompe el ciclo, para evitar crear una nueva mora en el mes que aun no termina.
                    if (fechaMora > fechaActual)
                    {
                        break;
                    }

                    mora.Fecha = fechaMora.AddDays(-9);//resta los 11 dias agregados en la linea 4 del metodo
                    mora.Monto = ((datos.Cuota * datos.TasaMora) / 30) * diasDelMes;//calculo del monto de la mora
                    estado = Save(mora);//guarda la mora en la base de datos.
                }
            }

            return estado;
        }
    }
}
