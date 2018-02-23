using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Interfaces
{
    public interface IDAO { }

    public interface IDAO<TKey, TDomain, in TCriteria> : IDAO
        where TDomain : class
        where TCriteria : class
    {
        TDomain              Get     (TKey id);
        TKey                 Save    (TDomain domain);
        IEnumerable<TDomain> Search  (TCriteria criteria);
        IEnumerable<TDomain> ListAll ( );
        void                 Delete  (TDomain domain);
        void                 Delete  (TKey id);
    }
}