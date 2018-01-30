using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Interfaces
{
    public interface IDAO<TDomain, TCriteria> 
        where TDomain : class
        where TCriteria : class
    {
        TDomain              Get     (object id);
        int                  Save    (TDomain model);
        void                 Delete  (TDomain model);
        void                 Delete  (int id);
        IEnumerable<TDomain> Search  (TCriteria criteria);
    }
}