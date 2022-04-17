using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcIlkProje.Controllers
{
    public class HeadingController : Controller
    {
        private readonly HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        private readonly CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        private WriterManager _wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingValues = _hm.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            var valueCategory = (from x in _cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            var valueWriter = (from x in _wm.GetList()
                select new SelectListItem()
                {
                    Text = x.WriterName + " " + x.WriterSurname,
                    Value = x.WriterId.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            _hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
    }
}