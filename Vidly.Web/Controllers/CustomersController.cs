using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : BaseController<Customer, CustomerViewModel>
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = this.GetList();
            //var customers = new List<Customer>()
            //{
            //    new Customer(){ Name = "John Smith" },
            //    new Customer(){ Name = "Mary Williams" }
            //};
            return View(customers);
        }

        public ActionResult New()
        {
            var viewModel = this.GetViewModel();

            return View(viewModel);
        }

        public ActionResult Edit(int id, string name)
        {
            return View(new Customer() { Id=id, Name=name });
        }
    }
}