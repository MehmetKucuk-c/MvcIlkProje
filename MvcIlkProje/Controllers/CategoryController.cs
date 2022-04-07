using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcIlkProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GeTCategoryList()
        {
            var categoryValues = _cm.GetList();
            return View(categoryValues);
        }
        //Sayfa Yüklenirken çalısıccak
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        //Sayfada Bir Butana Basıldıgında Çalışıcak
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBl(p);
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult result = categoryValidatior.Validate(p);
            if (result.IsValid)
            {
                _cm.CategoryAdd(p);
                return RedirectToAction("GeTCategoryList");
            }
            
            foreach (var variable in result.Errors)
            {
                ModelState.AddModelError(variable.PropertyName, variable.ErrorMessage);
            }

            return View();
        }
    }
}