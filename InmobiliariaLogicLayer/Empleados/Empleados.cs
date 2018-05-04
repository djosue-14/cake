using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Empleados
{
    public class Empleados
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public Empleados(ISqlPersistence persistence) {
            this.persistence = persistence;
        }

        public int Save(EmpleadosIngresoViewModels datos) {

            return persistence.Save(datos);
        }

        public int Delete(int id) {

            return persistence.Delete(id);
        }

        public int Update(EmpleadosIngresoViewModels datos) {

            return persistence.Update(datos);
        }

        public List<EmpleadosIngresoViewModels> SelectAll() {
            return (List<EmpleadosIngresoViewModels>)persistence.FindAll();
        }

        public EmpleadosIngresoViewModels SelectForId(int id) {
            return (EmpleadosIngresoViewModels)persistence.FindForId(id);
        }

    }
}