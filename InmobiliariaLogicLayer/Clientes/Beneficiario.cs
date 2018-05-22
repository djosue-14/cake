using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels.Clientes;

namespace InmobiliariaLogicLayer.Clientes
{
    public class Beneficiario
    {
        private ISqlPersistence persistence;
        public Beneficiario (ISqlPersistence persistence)
        {
            this.persistence = persistence;
        }

        public int Save(BeneficiarioViewModels datos)
        {
            return persistence.Save(datos);
        }

        public List<BeneficiarioViewModels> SelectAllBeneficiario()
        {
            return (List<BeneficiarioViewModels>)persistence.FindAll();
        }
        public int Update (BeneficiarioViewModels datos)
        {
            return persistence.Update(datos);
        }

        public BeneficiarioViewModels SelectForId (int id)
        {
            return (BeneficiarioViewModels)persistence.FindForId(id);
        }

        public IEnumerable<BeneficiarioViewModels> BenefForCliente (int id)
        {
            var _beneficiario = (List<BeneficiarioViewModels>)persistence.FindAll();
            var beneficiario = _beneficiario.Where(x => x.ClienteId == id);
            return beneficiario;
        }

        public int Delete (int id)
        {
            return persistence.Delete(id);
        }

       

    }
}
