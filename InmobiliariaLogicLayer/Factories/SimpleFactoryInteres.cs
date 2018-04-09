using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Intereses;

namespace InmobiliariaLogicLayer.Factories
{
    public class SimpleFactoryInteres
    {
        public IStrategyInteres createInteres(string type)
        {
            IStrategyInteres lotificadoraInteres = null;

            if (type == "Refugio")
            {
                lotificadoraInteres = new InteresRefugio();
            }
            else if (type == "Perlas")
            {
                lotificadoraInteres = new InteresPerlas();
            }
            else if (type == "America")
            {
                lotificadoraInteres = new InteresAmerica();
            }
            else if (type == "Condado")
            {
                lotificadoraInteres = new InteresCondado();
            }

            return lotificadoraInteres; 
        }
    }
}
