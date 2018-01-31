using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Interfaces;

namespace Vidly.Controllers
{
    public abstract class BaseController<TKey, TModel, TCriteria> : Controller
        where TModel    : class
        where TCriteria : class
    {
        protected IBO<TKey, TModel, TCriteria> DefaultBO { get; set; }

        public BaseController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = DefaultBO.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(TModel model)
        {
            DefaultBO.Save(model);
            return this.Index();
        }

        [HttpPost]
        public ActionResult Delete(TKey id)
        {
            DefaultBO.Delete(id);
            return this.Index();
        }
    }
}