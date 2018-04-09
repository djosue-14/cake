using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Persistence
{
    public interface IReadPersistence : IFindForItem, IFindAll
    {
    }

    public interface IFindForItem
    {
        object FindForItem(object id);
    }

    public interface IFindAll
    {
        object FindAll();
    }
}
