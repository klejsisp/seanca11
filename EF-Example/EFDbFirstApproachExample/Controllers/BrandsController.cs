using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands/Index
        public ActionResult Index(string search = "",string sortcolumn = "BrandID", string iconclass = "fa-sort-asc",int pg = 1)
        {
            var db = new ProveDbContex();
            ViewBag.search = search;
            List<Brand> brands = db.Brands.Where(var=>var.BrandName.Contains(search)).ToList();

            //sortig
            ViewBag.sortcolumn = sortcolumn;
            ViewBag.iconclass = iconclass;
            if (ViewBag.sortcolumn == "BrandID")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    brands = brands.OrderBy(temp => temp.BrandID).ToList();
                else
                    brands = brands.OrderByDescending(temp => temp.BrandID).ToList();
            }

            if (ViewBag.sortcolumn == "BrandName")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    brands = brands.OrderBy(temp => temp.BrandName).ToList();
                else
                    brands = brands.OrderByDescending(temp => temp.BrandName).ToList();
            }


            //paging

            int NoOfRecordsPerPage = 3;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(brands.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (pg - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = pg;
            ViewBag.NoOfPages = NoOfPages;
            brands = brands.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();


            return View(brands);
        }
        public ActionResult Detaje( int id)
        {
            var db = new ProveDbContex();
             var br = db.Brands.Where(temp => temp.BrandID == id).FirstOrDefault();
            return View(br);
            
        }
        public ActionResult Krijo()
        {
         return View();
        }
        [HttpPost]
        public ActionResult Krijo(Brand b)
        {
            var db = new ProveDbContex();
            db.Brands.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult Ndrysho(int id)
        {
            var db = new ProveDbContex();
            var b = db.Brands.Where(tmp => tmp.BrandID == id).FirstOrDefault();
            return View(b);
        }
        [HttpPost]
        public ActionResult Ndrysho(Brand br)
        {
            var db = new ProveDbContex();
            Brand br1 = db.Brands.Where(tmp => tmp.BrandID == br.BrandID).FirstOrDefault();
            br1.BrandName = br.BrandName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Fshi(int id)
        {
            var db = new ProveDbContex();
            var b = db.Brands.Where(tmp => tmp.BrandID == id).FirstOrDefault();
            return View(b);
        }
        [HttpPost]
        public ActionResult Fshi(Brand br)
        {
            var db = new ProveDbContex();
            Brand br1 = db.Brands.Where(tmp => tmp.BrandID == br.BrandID).FirstOrDefault();
            db.Brands.Remove(br1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


