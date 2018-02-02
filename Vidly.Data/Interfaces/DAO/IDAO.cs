using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Interfaces
{
    public interface IDAO<TKey, TDomain, TCriteria> 
        where TDomain : class
        where TCriteria : class
    {
        TDomain              Get     (TKey id);
        int                  Save    (TDomain domain);
        IEnumerable<TDomain> Search  (TCriteria criteria);
        IEnumerable<TDomain> ListAll ( );
        void                 Delete  (TDomain domain);
        void                 Delete  (TKey id);
    }
}