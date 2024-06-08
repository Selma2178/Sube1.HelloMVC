using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sube1.HelloMVC;
using Sube1.HelloMVC.Models;

namespace Sube1.HelloMVC.Controllers
{
    public class DersController : Controller
    {
        public IActionResult DersListe(int id)
        {
            List<Ders> lst = null;
            using (var ctx = new OkulDbcontext())
            {
                lst = ctx.Dersler.Where(x => x.Ogrenciid == id).ToList();
				ViewBag.OgrenciId = id;
			}
            return View(lst);
        }

		[HttpGet]
		public IActionResult DersEkle(int ogrenciId)
		{
            ViewBag.OgrenciId = ogrenciId;
            return View();
		}

		[HttpPost]
		public IActionResult DersEkle(Ders ders, int ogrenciId)
		{
			if (ModelState.IsValid)
			{
				using (var ctx = new OkulDbcontext())
				{
					try
					{
						ders.Ogrenciid = ogrenciId;
						ctx.Dersler.Add(ders);
						ctx.SaveChanges();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}
				}
			}
			return RedirectToAction("DersListe", new { id = ogrenciId });

		}

        public IActionResult DeleteDers(int id)
        {
			var ogrenciId = 0;
            using (var ctx = new OkulDbcontext())
            {
				var ders = ctx.Dersler.FirstOrDefault(x => x.Dersid == id);
				ogrenciId = ders.Ogrenciid;
                ctx.Remove(ders);
                ctx.SaveChanges();

            }
			return RedirectToAction("DersListe", new { id = ogrenciId });

		}
    }
}
