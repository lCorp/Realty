using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Persistence;
using Core.Models;
using Core.Utils;

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
            model.Password = CrytographyUtil.GetHashToString(CrytographyUtil.GeneratePassword());
            model.Id = CrytographyUtil.StringToGuid(model.AccountName);
            model.NickName = CrytographyUtil.StringToGuid(model.AccountName).ToString();
            _context.AccountList.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}