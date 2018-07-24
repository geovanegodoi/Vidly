using System.Collections.Generic;

namespace Vidly.Interfaces
{
    public interface IBO { }

    public interface IBO<TKey, TModel, TCriteria> : IBO
        where TModel    : class
        where TCriteria : class
    {
        TModel              Get   (TKey id);
        TKey                Save  (TModel model);
        IEnumerable<TModel> Search(TCriteria criteria);
        IEnumerable<TModel> SearchByName(string name);
        IEnumerable<TModel> GetAll();        
        void                Delete(TKey id);
        void                Delete(TModel model);
        TModel              CreateModelInstance();
    }

    public interface IBO<TKey, TModel, TViewModel, TCriteria> : IBO<TKey, TModel, TCriteria>
        where TModel     : class
        where TViewModel : class
        where TCriteria  : class
    {
        TKey        Save(TViewModel viewModel);
        TViewModel  GetViewModel();
        TViewModel  GetViewModel(TKey id);
    }
}