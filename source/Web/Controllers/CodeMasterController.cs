using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using Core.Resources;
using Core.Persistence;
using Core.Constant;
using Core.Models;

namespace Web.Controllers
{
    public class CodeMasterController : Controller
    {
        private readonly Context _context = new Context();
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, string currentCodeType, string codeType, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewBag.ValueSortParm = sortOrder == "value_asc" ? "value_desc" : "value_asc";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            if (codeType != null)
            {
                page = 1;
                CodeMaster codeMaster = this._context.CodeMasterList.FirstOrDefault(m => m.CodeMasterCode == codeType && m.CodeMasterType == "EditableCode");
                if (codeMaster == null)
                {
                    codeMaster = this._context.CodeMasterList.Where(m => m.CodeMasterType == "EditableCode").OrderBy(m => m.Ordinal).FirstOrDefault();
                }
                if (codeMaster != null)
                {
                    codeType = codeMaster.CodeMasterCode;
                }
            }
            else
            {
                CodeMaster codeMaster = this._context.CodeMasterList.FirstOrDefault(m => m.CodeMasterCode == currentCodeType && m.CodeMasterType == "EditableCode");
                if (codeMaster == null)
                {
                    codeMaster = this._context.CodeMasterList.Where(m => m.CodeMasterType == "EditableCode").OrderBy(m => m.Ordinal).FirstOrDefault();
                }
                if (codeMaster != null)
                {
                    currentCodeType = codeMaster.CodeMasterCode;
                }
                codeType = currentCodeType;
            }

            ViewBag.CurrentCodeType = codeType;

            if (string.IsNullOrEmpty(codeType))
            {
                return View((new List<CodeMaster>()).ToPagedList(0, 0));
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IQueryable<CodeMaster> codeMasterList = from m in _context.CodeMasterList
                                                    where m.CodeMasterType == codeType
                                                    select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                codeMasterList = codeMasterList.Where(m => m.CodeMasterValue.ToUpper().Contains(searchString.ToUpper()));
            }

            ViewBag.TotalSearchResult = codeMasterList.Count();

            switch (sortOrder)
            {
                case "id_desc":
                    codeMasterList = codeMasterList.OrderByDescending(m => m.Id);
                    break;
                case "value_desc":
                    codeMasterList = codeMasterList.OrderByDescending(m => m.CodeMasterValue);
                    break;
                case "date_desc":
                    codeMasterList = codeMasterList.OrderByDescending(m => m.LastUpdatedDateTime);
                    break;
                case "id_asc":
                    codeMasterList = codeMasterList.OrderBy(m => m.Id);
                    break;
                case "value_asc":
                    codeMasterList = codeMasterList.OrderBy(m => m.CodeMasterValue);
                    break;
                default:
                    codeMasterList = codeMasterList.OrderBy(m => m.LastUpdatedDateTime);
                    break;
            }

            int pageSize = GlobalConstant.SMALL_PAGE_SIZE;
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
