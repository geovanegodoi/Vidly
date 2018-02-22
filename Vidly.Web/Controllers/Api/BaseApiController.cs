using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
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

        [HttpGet]
        public IEnumerable<TModel> Get()
        {
            return DefaultBO.ListAll();
            
        }

        [HttpGet]
        public TModel Get(TKey id)
        {
            return DefaultBO.Get(id);
        }

        [HttpPost]
        public TKey Save(TModel model)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return DefaultBO.Save(model);
        }

        [HttpDelete]
        public void Delete(TKey id)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                DefaultBO.Delete(id);
            }
            catch (KeyNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}