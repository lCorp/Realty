using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Persistence;
using Core.Models;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using Core.Resources;

namespace Web.Controllers
{
    public class CodeMasterController : Controller
    {
        private Context _context = new Context();
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewBag.ValueSortParm = sortOrder == "value_asc" ? "value_desc" : "value_asc";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var codeMasterList = from s in _context.CodeMasterList
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                codeMasterList = codeMasterList.Where(s => s.CodeMasterValue.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    codeMasterList = codeMasterList.OrderByDescending(s => s.Id);
                    break;
                case "value_desc":
                    codeMasterList = codeMasterList.OrderByDescending(s => s.CodeMasterValue);
                    break;
                case "date_desc":
                    codeMasterList = codeMasterList.OrderByDescending(s => s.LastUpdatedDateTime);
                    break;
                case "id_asc":
                    codeMasterList = codeMasterList.OrderBy(s => s.Id);
                    break;
                case "value_asc":
                    codeMasterList = codeMasterList.OrderBy(s => s.CodeMasterValue);
                    break;
                //case "date_asc":
                //    codeMasterList = codeMasterList.OrderBy(s => s.LastUpdatedDateTime);
                //    break;
                default:
                    codeMasterList = codeMasterList.OrderBy(s => s.LastUpdatedDateTime);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(codeMasterList.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeMaster codeMaster = _context.CodeMasterList.Find(id);
            if (codeMaster == null)
            {
                return HttpNotFound();
            }
            return View(codeMaster);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category, Value")]CodeMaster codeMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.CodeMasterList.Add(codeMaster);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(codeMaster);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeMaster codeMaster = _context.CodeMasterList.Find(id);
            if (codeMaster == null)
            {
                return HttpNotFound();
            }
            return View(codeMaster);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Category, Value")]CodeMaster codeMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(codeMaster).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(codeMaster);
        }
        // GET: /Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            CodeMaster codeMaster = _context.CodeMasterList.Find(id);
            if (codeMaster == null)
            {
                return HttpNotFound();
            }
            return View(codeMaster);
        }

        // POST: /Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                CodeMaster codeMaster = _context.CodeMasterList.Find(id);
                _context.CodeMasterList.Remove(codeMaster);
                _context.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
