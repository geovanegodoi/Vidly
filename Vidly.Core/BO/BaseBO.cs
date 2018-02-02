using AutoMapper;
using System.Collections.Generic;
using Vidly.Interfaces;

namespace Vidly.Core.BO
{
    public abstract class BaseBO<TKey, TModel, TCriteria, TDomain> : IBO<TKey, TModel, TCriteria>
        where TModel    : class
        where TCriteria : class
        where TDomain   : class
    {
        protected IDAO<TKey, TDomain, TCriteria> DefaultDAO { get; set; }

        public BaseBO()
        {
            
        }

        public TModel Get(TKey id)
        {
            var domain = DefaultDAO.Get(id);
            return Mapper.Map<TModel>(domain);
        }

        public int Save(TModel model)
        {
            TDomain domain = Mapper.Map<TDomain>(model);
            return DefaultDAO.Save(domain);
        }

        public IEnumerable<TModel> Search(TCriteria criteria)
        {
            var domain = DefaultDAO.Search(criteria);
            return Mapper.Map<IEnumerable<TModel>>(domain);
        }

        public IEnumerable<TModel> ListAll()
        {
            var domain = DefaultDAO.ListAll();
            return Mapper.Map<IEnumerable<TModel>>(domain);
        }

        public void Delete(TModel model)
        {
            var domain = Mapper.Map<TDomain>(model);
            DefaultDAO.Delete(domain);
        }

        public void Delete(TKey id)
        {
            DefaultDAO.Delete(id);
        }
    }
}
