using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Interfaces
{
    public interface IBO<TKey, TModel, TCriteria>
        where TModel    : class
        where TCriteria : class
    {
        TModel              Get     (TKey id);
        int                 Save    (TModel model);
        void                Delete  (TModel model);
        void                Delete  (TKey id);
        IEnumerable<TModel> ListAll ();
        IEnumerable<TModel> Search  (TCriteria criteria);
    }
}