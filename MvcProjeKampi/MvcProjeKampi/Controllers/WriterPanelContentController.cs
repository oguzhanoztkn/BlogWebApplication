﻿using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: WriterPanelContent  
        public ActionResult MyContent(string p)
        {
            //Context c = new Context();
            //p = (string)Session["WriterMail"];
            //var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            //var contentValues = cm.GetListByWriter(writerIdInfo);

            
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
           
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerIdInfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}