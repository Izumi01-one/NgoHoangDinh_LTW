using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NgoHoangDinh_241230706.Models;
using System.Diagnostics;

namespace NgoHoangDinh_241230706.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult LocSach(int maTl)
        {
            var dsSach = _context.Saches.Where(s => s.MaTl == maTl).ToList();
            return PartialView("_BookPartial", dsSach);
        }

        public IActionResult Index()
        {
            var ds = _context.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(ds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(sach);


        }

    }
}
