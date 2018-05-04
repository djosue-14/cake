using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Empleados
{
    public class EstadoEmp
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public EstadoEmp(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(EstadoEmpViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(EstadoEmpViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<EstadoEmpViewModels> SelectAll()
        {
            return (List<EstadoEmpViewModels>)persistence.FindAll();
        }

        public EstadoEmpViewModels SelectForId(int id)
        {
            return (EstadoEmpViewModels)persistence.FindForId(id);
        }
    }
}
