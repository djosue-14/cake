using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Empleados;

namespace InmobiliariaLogicLayer.Empleados
{
    public class ReferenciaEmp
    {
        private ISqlPersistence persistence;

        //private ISelectAll a;
        //private ISelectForId b;

        public ReferenciaEmp(ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(ReferenciaEmpViewModels datos)
        {

            return persistence.Save(datos);
        }

        public int Delete(int id)
        {

            return persistence.Delete(id);
        }

        public int Update(ReferenciaEmpViewModels datos)
        {

            return persistence.Update(datos);
        }

        public List<ReferenciaEmpViewModels> SelectAll()
        {
            return (List<ReferenciaEmpViewModels>)persistence.FindAll();
        }

        public ReferenciaEmpViewModels SelectForId(int id)
        {
            return (ReferenciaEmpViewModels)persistence.FindForId(id);
        }

        public IEnumerable<ReferenciaEmpViewModels> FindForEmp(int id)
        {
            var lista = (List<ReferenciaEmpViewModels>)persistence.FindAll();
            var ilista = lista.Where(x => x.id_emp == id);

            return ilista;
        }
    }
}
