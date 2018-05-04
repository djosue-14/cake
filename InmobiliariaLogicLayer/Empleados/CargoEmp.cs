using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Empleados
{
    public class CargoEmp
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public CargoEmp(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(CargoEmpViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(CargoEmpViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<CargoEmpViewModels> SelectAll()
        {
            return (List<CargoEmpViewModels>)persistence.FindAll();
        }

        public CargoEmpViewModels SelectForId(int id)
        {
            return (CargoEmpViewModels)persistence.FindForId(id);
        }

    }
}