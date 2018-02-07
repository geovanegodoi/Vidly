using System.Collections.Generic;

namespace Vidly.Interfaces
{
    public interface IBO { }

    public interface IBO<TKey, TModel, TCriteria> : IBO
        where TModel    : class
        where TCriteria : class
    {
        TModel              Get     (TKey id);
        int                 Save    (TModel model);
        IEnumerable<TModel> Search  (TCriteria criteria);
        IEnumerable<TModel> ListAll ( );
        void                Delete  (TKey id);
        void                Delete  (TModel model);
    }

    public interface IBO<TKey, TModel, TViewModel, TCriteria> : IBO<TKey, TModel, TCriteria>
        where TModel     : class
        where TViewModel : class
        where TCriteria  : class
    {
        int Save(TViewModel viewModel);
    }
}