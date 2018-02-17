using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Interfaces;

namespace Vidly.Controllers
{
    public abstract class BaseApiController<TKey, TModel, TCriteria, TBO> : ApiController
        where TModel    : class
        where TCriteria : class
        where TBO       : IBO<TKey, TModel, TCriteria>
    {
        protected TBO DefaultBO { get; set; }

        public BaseApiController()
        {

        }

        public IEnumerable<TModel> Get()
        {
            return DefaultBO.ListAll();
            
        }

        public TModel Get(TKey id)
        {
            return DefaultBO.Get(id);
        }

        public TKey Save(TModel model)
        {
            return DefaultBO.Save(model);
        }

        public void Delete(TKey id)
        {

        }
    }
}