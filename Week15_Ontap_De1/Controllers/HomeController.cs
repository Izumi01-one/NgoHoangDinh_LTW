using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Week15_de1_ontap.Models;

namespace Week15_de1_ontap.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _context;

        public HomeController(QltaiSanContext _context)
        {
            this._context = _context;
        }

        public IActionResult LocTS(int MaLoai)
        {
            var dsTS = _context.TaiSans.Where(s => s.MaLoai == MaLoai);
            return PartialView("_HangPartial", dsTS);
        }

        public IActionResult Index()
        {
            var dsTS = _context.TaiSans.Where(s => s.NguyenGia >= 20 && s.NguyenGia != null).ToList();
            return View(dsTS);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaiSan taisan)
        {
            if (ModelState.IsValid)
            {
                _context.TaiSans.Add(taisan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taisan.MaLoai);
            return View(taisan);
        }

        
    }
}
