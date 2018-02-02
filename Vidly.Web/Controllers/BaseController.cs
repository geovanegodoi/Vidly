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
        public virtual ActionResult Index()
        {
            var model = DefaultBO.ListAll();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Details(TKey id)
        {
            var model = DefaultBO.Get(id);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult New()
        {
            return View("Save");
        }

        [HttpPost]
        public virtual ActionResult Save(TModel model)
        {
            DefaultBO.Save(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual ActionResult Edit(TKey id)
        {
            var model = DefaultBO.Get(id);
            return View("Save", model);
        }

        [HttpGet]
        public virtual ActionResult Delete(TKey id)
        {
            DefaultBO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}