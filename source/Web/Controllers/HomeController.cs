using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Persistence;
using Core.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context = new Context();
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View(_context.AccountList);
        }

        public ActionResult Create(Account model)
        {
            _context.AccountList.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}