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
using Core.Persistence;
using Core.Constant;
using Core.Models;
using Core.Resources.Views.CodeMaster;

namespace Web.Controllers
{
    public class CodeMasterController : Controller
    {
        private readonly Context dataContext = new Context();
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, string currentCodeType, string codeType, string currentParentValue, string parentValue, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewBag.ValueSortParm = sortOrder == "value_asc" ? "value_desc" : "value_asc";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            if (codeType != null)
            {
                page = 1;
                codeType = CheckOrGetDefaultEditableCodeType(codeType);
            }
            else
            {
                currentCodeType = CheckOrGetDefaultEditableCodeType(currentCodeType);
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

            if (parentValue != null)
            {
                page = 1;
            }
            else
            {
                parentValue = currentParentValue;
            }

            ViewBag.CurrentParentValue = parentValue;

            IQueryable<CodeMaster> codeMasterList = null;

            if (!String.IsNullOrEmpty(parentValue))
            {
                codeMasterList = CodeMaster.GetAvailableListByType(codeType, parentValue).AsQueryable();
            }
            else
            {
                codeMasterList = CodeMaster.GetAvailableListByType(codeType).AsQueryable();
            }

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

        // GET: /Student/Create
        public ActionResult Create(string currentCodeType, string codeType)
        {
            if (codeType != null)
            {
                codeType = CheckOrGetDefaultEditableCodeType(codeType);
            }
            else
            {
                currentCodeType = CheckOrGetDefaultEditableCodeType(currentCodeType);
                codeType = currentCodeType;
            }

            ViewBag.CurrentCodeType = codeType;

            CodeMaster model = new CodeMaster();
            model.CodeMasterType = codeType;

            return View(model);
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentId, CodeMasterType, CodeMasterValue")]CodeMaster model)
        {
            ViewBag.CurrentCodeType = model.CodeMasterType;
            try
            {
                if (ModelState.IsValid)
                {
                    CodeMaster codeMaster = this.dataContext.CodeMasterList.FirstOrDefault(m => m.CodeMasterType == model.CodeMasterType && m.CodeMasterValue == model.CodeMasterValue && m.ParentId == model.ParentId && string.Compare(m.Status, "DELETED", StringComparison.OrdinalIgnoreCase) != 0);
                    if (codeMaster != null)
                    {
                        ModelState.AddModelError("", CodeMasterViewResource.Duplicated);
                        return View(model);
                    }

                    model.CodeMasterCode = Guid.NewGuid().ToString();
                    dataContext.CodeMasterList.Add(model);
                    dataContext.SaveChanges();
                    ViewBag.InfoMessage = CodeMasterViewResource.SaveSuccess;
                    return View(model);
                }
                ModelState.AddModelError("", CodeMasterViewResource.SaveException);
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", CodeMasterViewResource.SaveException);
            }
            return View(model);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeMaster codeMaster = dataContext.CodeMasterList.Find(id);
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
                    dataContext.Entry(codeMaster).State = EntityState.Modified;
                    dataContext.SaveChanges();
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
        public ActionResult Delete(Guid? id, bool? saveChangesError = false)
        {
            CodeMaster codeMaster = null;
            if (id == null)
            {
                ViewBag.ErrorMessage = CodeMasterViewResource.NotFoundToDelete;
            }
            else if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = CodeMasterViewResource.DeleteFailed;
            }
            codeMaster = dataContext.CodeMasterList.FirstOrDefault(m => m.Id == id);
            if (codeMaster == null || !CodeMaster.IsEditableCodeType(codeMaster.CodeMasterType))
            {
                ViewBag.ErrorMessage = CodeMasterViewResource.NotFoundToDelete;
            }
            return View(codeMaster);
        }

        // POST: /Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            string codeType = string.Empty;
            try
            {
                CodeMaster codeMaster = dataContext.CodeMasterList.Find(id);
                codeType = codeMaster.CodeMasterType;
                codeMaster.Status = "DELETED";
                dataContext.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index", new { codeType = codeType });
        }

        private string CheckOrGetDefaultEditableCodeType(string codeTypeToCheck)
        {
            string result = string.Empty;
            CodeMaster codeMaster = this.dataContext.CodeMasterList.FirstOrDefault(m => m.CodeMasterCode == codeTypeToCheck && m.CodeMasterType == "EditableCode");
            if (codeMaster == null)
            {
                codeMaster = this.dataContext.CodeMasterList.Where(m => m.CodeMasterType == "EditableCode").OrderBy(m => m.Ordinal).FirstOrDefault();
            }
            if (codeMaster != null)
            {
                result = codeMaster.CodeMasterCode;
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
