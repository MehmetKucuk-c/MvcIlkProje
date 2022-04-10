using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcIlkProje.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _wm = new WriterManager(new EfWriterDal());
        private readonly WriterValidator _validatorRules = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = _wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            
            var result = _validatorRules.Validate(p);
            if (result.IsValid)
            {
                _wm.WriterAdd(p);
                return RedirectToAction("Index");
            }

            foreach (var variable in result.Errors)
            {
                ModelState.AddModelError(variable.PropertyName,variable.ErrorMessage);
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = _wm.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {

            var result = _validatorRules.Validate(p);
            if (result.IsValid)
            {
                _wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }

            foreach (var variable in result.Errors)
            {
                ModelState.AddModelError(variable.PropertyName, variable.ErrorMessage);
            }

            return View();
        }
    }
}