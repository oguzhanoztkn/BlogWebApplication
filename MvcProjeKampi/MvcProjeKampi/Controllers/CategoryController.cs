using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        //BL katmanında bulunan CategoryManagerden nesne oluşturduk
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() //Kategori Listeleme
        {
            var categoryvalues = cm.GetList();
            //oluşturduğumuz cm nesnesinden GetList methodunu çağırdık
            return View(categoryvalues);
            //categoryvalues değerini viewa döndürdük
        }

        [HttpGet] //sayfa yüklendiği zaman çalışacak olan attribute
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]//sayfada post işlemi gerçekleştiğinde çalışacak
        public ActionResult AddCategory(Category p)
        {
            //  cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            //ValidationResult türünde değişken oluşturduk bu değişken parametre olarak gelen değeri categoryValidator sınıfında olan değerlere göre validasyon yapacak.
            if (results.IsValid)//results validasyona uygunsa/geçerliyse
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
                //kategoryi ekleme işlemi gerçekleştikten sonra GetCategoryListe yönlendir

            }
            else
            {
                foreach (var item in results.Errors) //resulttan gelen errorları döndür
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}