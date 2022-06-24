using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            
            List<SelectListItem> adminRole = (from x in adminManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AdminRole
                                              }).ToList();
            ViewBag.vlc = adminRole;
          
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminManager.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetByID(id);

            List<SelectListItem> adminRole = (from x in adminManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AdminRole
                                                }).ToList();
            ViewBag.vlc = adminRole;
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }

    }
}