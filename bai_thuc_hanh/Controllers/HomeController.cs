using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NgoHoangDinh_241230706_ontap.Models;
using System.Diagnostics;

namespace NgoHoangDinh_241230706_ontap.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HomeController(QlhangHoaContext _context)
        {
            this._context = _context;
        }

        public IActionResult LocHang(int MaLoai)
        {
            var ds = _context.HangHoas.Where(s => s.MaLoai == MaLoai).ToList();
            return PartialView("_HangPartial", ds);
        }

        public IActionResult Index()
        {
            var dsHang = _context.HangHoas.Where(s => s.Gia >= 100).ToList();
            return View(dsHang);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hang)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hang.MaLoai);
            return View(hang);

        }


    }
}
