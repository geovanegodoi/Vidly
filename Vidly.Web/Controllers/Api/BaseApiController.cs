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
        public IHttpActionResult Get(TKey id)
        {
            IHttpActionResult httpResult = NotFound();
            try
            {
                httpResult = Ok(DefaultBO.Get(id));
            }
            catch (KeyNotFoundException)
            {
                httpResult = NotFound();
            }
            return httpResult;
        }

        [HttpPost]
        public IHttpActionResult Save(TModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = DefaultBO.Save(model);

            return Created(new Uri(Request.RequestUri + "/" + result), result);
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