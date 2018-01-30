using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Interfaces
{
    public interface IBO<TModel, TCriteria> 
        where TModel : class
        where TCriteria : class
    {
        TModel              Get     (int id);
        int                 Save    (TModel model);
        void                Delete  (TModel model);
        void                Delete  (int id);
        IEnumerable<TModel> Search  (TCriteria criteria);
    }
}