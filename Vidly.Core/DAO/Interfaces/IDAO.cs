using System.Collections.Generic;

namespace Vidly.Core.DAO
{
    public interface IDAO { }

    public interface IDAO<TKey, TDomain, in TCriteria> : IDAO
        where TDomain : class
        where TCriteria : class
    {
        TDomain              Get   (TKey id);
        TKey                 Save  (TDomain domain);
        IEnumerable<TDomain> Search(TCriteria criteria);
        IEnumerable<TDomain> SearchByName(string name);
        IEnumerable<TDomain> GetAll( );
        void                 Delete(TDomain domain);
        void                 Delete(TKey id);
    }
}