using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStudent.Models;

namespace WebStudent.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        public ActionResult Index()
        {
            using(SD obj = new SD())
            {
                return View(obj.details.ToList());

            }
            
        }

        // GET: student/Details/5
        public ActionResult Details(int id)
        {
            using (SD obj = new SD())
            {
                return View(obj.details.Where(x => x.id == id).FirstOrDefault());
            }
            
        }

        // GET: student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: student/Create
        [HttpPost]
        public ActionResult Create(detail ob)
        {
            try
            {
                using(var record = new SD())
                {
                    record.details.Add(ob);
                    record.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, detail ob)
        {
            try
            {
                using (SD info = new SD())
                {
                    info.Entry(ob).State = EntityState.Modified;
                    info.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Delete/5
        public ActionResult Delete(int id)
        {
            using (SD obj = new SD())
            {
                return View(obj.details.Where(x => x.id == id).FirstOrDefault());
            }
            
        }

        // POST: student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using(SD info = new SD())
                {
                    detail ob = info.details.Where(x => x.id == id).FirstOrDefault();
                    info.details.Remove(ob);
                    info.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
