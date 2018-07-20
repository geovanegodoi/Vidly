using AutoMapper;
using System.Collections.Generic;
using Vidly.Core.DAO;
using Vidly.Interfaces;

namespace Vidly.Core.BO
{
    public abstract class BaseBO<TKey, TModel, TCriteria, TDomain, TDAO> : IBO<TKey, TModel, TCriteria>
        where TModel    : class
        where TCriteria : class
        where TDomain   : class
        where TDAO      : IDAO<TKey, TDomain, TCriteria>
    {
        protected TDAO DefaultDAO { get; set; }

        public BaseBO()
        {
            
        }

        public virtual TModel Get(TKey id)
        {
            var domain = DefaultDAO.Get(id);

            if (domain == null)
                throw new KeyNotFoundException();

            return Mapper.Map<TModel>(domain);
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            var domain = DefaultDAO.GetAll();
            return Mapper.Map<IEnumerable<TModel>>(domain);
        }

        public virtual TKey Save(TModel model)
        {
            TDomain domain = Mapper.Map<TDomain>(model);
            return DefaultDAO.Save(domain);
        }

        public virtual IEnumerable<TModel> Search(TCriteria criteria)
        {
            var domain = DefaultDAO.Search(criteria);
            return Mapper.Map<IEnumerable<TModel>>(domain);
        }

        public virtual void Delete(TModel model)
        {
            var domain = Mapper.Map<TDomain>(model);
            DefaultDAO.Delete(domain);
        }

        public virtual void Delete(TKey id)
        {
            DefaultDAO.Delete(id);
        }
    }

    public abstract class BaseBO<TKey, TModel, TViewModel, TCriteria, TDomain, TDAO> : BaseBO<TKey, TModel, TCriteria, TDomain, TDAO>, IBO
        where TModel     : class
        where TViewModel : class
        where TCriteria  : class
        where TDomain    : class
        where TDAO       : IDAO<TKey, TDomain, TCriteria>
    {
        public TKey Save(TViewModel viewModel)
        {
            var model  = Mapper.Map<TModel>(viewModel);
            return base.Save(model);
        }
    }
}
