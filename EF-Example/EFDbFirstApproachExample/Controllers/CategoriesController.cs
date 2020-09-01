using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public ActionResult Index(string search="",string sortcolumn="CategoryName",string iconclass= "fa-sort-asc", int pg = 1)
        {
            var db = new ProveDbContex();
            ViewBag.search = search;
            List<Category> categories = db.Categories.Where(tmp=>tmp.CategoryName.Contains(search)).ToList();

            //sortig
            ViewBag.sortcolumn = sortcolumn;
            ViewBag.iconclass = iconclass;
            if (ViewBag.sortcolumn == "CategoryID")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    categories = categories.OrderBy(temp => temp.CategoryID).ToList();
                else
                    categories = categories.OrderByDescending(temp => temp.CategoryID).ToList();
            }

            if (ViewBag.sortcolumn == "CategoryName")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    categories = categories.OrderBy(temp => temp.CategoryName).ToList();
                else
                    categories = categories.OrderByDescending(temp => temp.CategoryName).ToList();
            }

            //paging

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(categories.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (pg - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = pg;
            ViewBag.NoOfPages = NoOfPages;
            categories = categories.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();



            return View(categories);
        }
        public ActionResult Detajet(int id)
        {
            var db = new ProveDbContex();
            var cat = db.Categories.Where(tmp => tmp.CategoryID == id).FirstOrDefault();
            return View(cat);
        }
        public ActionResult Krijo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Krijo(Category cat)
        {
            if (ModelState.IsValid)
            {
                var db = new ProveDbContex();
                db.Categories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View();

        }
        public ActionResult Ndrysho(int id)
        {
            var db = new ProveDbContex();
            var ct = db.Categories.Where(tmp => tmp.CategoryID== id).FirstOrDefault();
            return View(ct);
        }

        [HttpPost]
        public ActionResult Ndrysho(Category cat)
        {
            var db = new ProveDbContex();
            Category ct = db.Categories.Where(tmp => tmp.CategoryID == cat.CategoryID).FirstOrDefault();
            ct.CategoryName = cat.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Fshi(int id)
        {
            var db = new ProveDbContex();
            var ct = db.Categories.Where(tmp => tmp.CategoryID == id).FirstOrDefault();
            return View(ct);
        }
        [HttpPost]
        public ActionResult Fshi(Category cat)
        {
            var db = new ProveDbContex();
            Category ct = db.Categories.Where(tmp => tmp.CategoryID == cat.CategoryID).FirstOrDefault();
            db.Categories.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


