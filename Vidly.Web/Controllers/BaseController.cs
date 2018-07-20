using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Interfaces;

namespace Vidly.Controllers
{
    public abstract class BaseController<TKey, TModel, TCriteria, TBO> : Controller
        where TModel    : class
        where TCriteria : class
        where TBO       : IBO<TKey, TModel, TCriteria>
    {
        protected TBO DefaultBO { get; set; }

        public BaseController()
        {

        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Details(TKey id)
        {
            var model = DefaultBO.Get(id);

            if (model == null)
                return new HttpNotFoundResult();

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

    public abstract class BaseController<TKey, TModel, TViewModel, TCriteria, TBO> : BaseController<TKey, TModel, TCriteria, TBO>
        where TModel     : class
        where TViewModel : class
        where TCriteria  : class
        where TBO        : IBO<TKey, TModel, TViewModel, TCriteria>
    {
        [HttpGet]
        public override ActionResult New()
        {
            var viewModel = DefaultBO.GetViewModel();
            return View("Save", viewModel);
        }

        [HttpGet]
        public override ActionResult Edit(TKey id)
        {
            var viewModel = DefaultBO.GetViewModel(id);
            return View("Save", viewModel);
        }

        [HttpPost]
        public virtual ActionResult SaveViewModel(TViewModel viewModel)
        {
            DefaultBO.Save(viewModel);
            return RedirectToAction("Index");
        }
    }
}