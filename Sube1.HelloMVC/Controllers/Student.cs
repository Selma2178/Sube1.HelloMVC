using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube1.HelloMVC.Models;
using System.Collections.Generic;

namespace Sube1.HelloMVC.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            List<Ogrenci> lst = null;
            using (var ctx = new OkulDbcontext())
            {
                lst = ctx.Ogrenciler.ToList();
            }
            return View(lst);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new OkulDbcontext())
                {
                    try
                    {
                        ctx.Ogrenciler.Add(ogr);
                        ctx.SaveChanges();
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex);
                    }
                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult EditStudent(int id)
        {
            Ogrenci ogr = null;
            using (var ctx = new OkulDbcontext())
            {
                ogr = ctx.Ogrenciler.Find(id);

            }
            return View(ogr);
        }
        [HttpPost]
        public IActionResult EditSudent(Ogrenci ogr)
        {
            using (var ctx = new OkulDbcontext())
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSudent(int id)
        {
            using (var ctx = new OkulDbcontext())
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();

            }
            return RedirectToAction("Index");

        }
    }
}
