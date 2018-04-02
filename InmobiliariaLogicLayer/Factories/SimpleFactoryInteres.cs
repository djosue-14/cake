using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Intereses.InteresStrategies;
using InmobiliariaLogicLayer.Intereses;

namespace InmobiliariaLogicLayer.Factories
{
    public class SimpleFactoryInteres
    {
        public IStrategyInteres createInteres(string type)
        {
            IStrategyInteres lotificadoraInteres = null;

            if (type == "refugio")
            {
                lotificadoraInteres = new InteresRefugio();
            }
            else if (type == "perlas")
            {
                lotificadoraInteres = new InteresPerlas();
            }
            else if (type == "america")
            {
                lotificadoraInteres = new InteresAmerica();
            }
            else if (type == "condado")
            {
                lotificadoraInteres = new InteresCondado();
            }

            return lotificadoraInteres; 
        }
    }
}
