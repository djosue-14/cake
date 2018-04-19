using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaLogicLayer.Persistence;

namespace InmobiliariaLogicLayer.Cuotas.Moras
{
    public abstract class Mora
    {
        private ISelectForId selectForId;
        private ISave save;

        public Mora(ISelectForId selectForId, ISave save)
        {
            this.selectForId = selectForId;
            this.save = save;
        }

        public abstract double MontoMora(CalcularMoraViewModels datos);

        public CalcularMoraViewModels FindForId(int id)
        {
            var datos = (CalcularMoraViewModels)selectForId.FindForId(id);
            return datos;
        }

        
        public int DiasTranscurridos(DateTime fechaUltimoPago)
        {
            DateTime fechaActual = DateTime.Today;
            int diasTranscurridos;

            /*  Resta a la fecha actual la fecha del ultimo mes cancelado
                Toma solo los dias con la funcion ToString("dd")
                Convierte a entero.
            */
            diasTranscurridos = Convert.ToInt16(fechaActual.Subtract(fechaUltimoPago).ToString("dd"));

            return diasTranscurridos;
        }

        //public ISelectForId SelectForId
        //{
        //    get { return selectForId; }
        //    set { selectForId = value; }
        //}
        //public ISave Save
        //{
        //    get { return save; }
        //    set { save = value; }
        //}


    }
}
