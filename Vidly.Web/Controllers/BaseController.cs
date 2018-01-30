using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class BaseController<TModel, TViewModel> : Controller
    {
        public IList<TModel> GetList()
        {
            return new List<TModel>();
        }

        public TModel GetSingle()
        {
            return (TModel)new Object();
        }

        public TViewModel GetViewModel()
        {
            return (TViewModel)new Object();
        }
    }
}