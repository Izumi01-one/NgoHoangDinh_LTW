using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Week15_de2_ontap.Models;

namespace Week15_de2_ontap.Controllers
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
            var ds = _context.TaiSans.Where(s => s.MaLoai == MaLoai).ToList();
            return PartialView("_HangPartial", ds);
        }

        public IActionResult Index()
        {
            var dsTS = _context.TaiSans.Where(s => s.NguyenGia >= 20 && s.NguyenGia != null).ToList();
            return View(dsTS);
        }

        [HttpGet]
        public IActionResult Edit(int MaTS)
        {
            var ts = _context.TaiSans.Find(MaTS);
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }

        [HttpPost]
        public IActionResult Edit(TaiSan taisan)
        {
            if (ModelState.IsValid)
            {
                _context.TaiSans.Update(taisan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taisan.MaLoai);
            return View(taisan);
        }
    }
}
