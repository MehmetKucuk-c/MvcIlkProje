using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;


namespace MvcIlkProje.Controllers
{
    public class AdminCategoryController : Controller
    {
        private CategoryManager _cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categoryValues = _cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult result = categoryValidatior.Validate(p);
            if (result.IsValid)
            {
                _cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }

            foreach (var validationFailure in result.Errors)
            {
                ModelState.AddModelError(validationFailure.PropertyName,validationFailure.ErrorMessage);
            }
            return View();
        }
    }
}