using Microsoft.AspNetCore.Mvc;
using Week_9_Entity_CRUD.Models;

namespace Week_9_Entity_CRUD.Controllers
{
    public class BannerController : Controller
    {
        private static readonly List<Banner> Banners = new List<Banner>()
        {
            new Banner
            {
                Id = 1,
                Name = "Khuyến mãi điện thoại",
                Status = 1,
                Priority = 1,
                Image = "banner-dien-thoai.jpg",
                Description = "Khuyến mãi các sản phẩm điện thoại"
            },
            new Banner
            {
                Id = 2,
                Name = "Khuyến mãi laptop",
                Status = 1,
                Priority = 2,
                Image = "banner-laptop.jpg",
                Description = "Khuyến mãi các sản phẩm laptop"
            },
            new Banner
            {
                Id = 3,
                Name = "Phụ kiện công nghệ",
                Status = 1,
                Priority = 3,
                Image = "banner-phu-kien.jpg",
                Description = "Khuyến mãi phụ kiện công nghệ"
            },
            new Banner
            {
                Id = 4,
                Name = "Sản phẩm mới",
                Status = 0,
                Priority = 4,
                Image = "banner-san-pham-moi.jpg",
                Description = "Giới thiệu những sản phẩm mới"
            }
        };

        public IActionResult Index()
        {
            return View(Banners);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View(banner);
            }

            banner.Id = Banners.Count == 0
                ? 1
                : Banners.Max(b => b.Id) + 1;

            Banners.Add(banner);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var banner = Banners.FirstOrDefault(b => b.Id == id);

            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Banner banner)
        {
            if (id != banner.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(banner);
            }

            var existingBanner = Banners.FirstOrDefault(b => b.Id == id);

            if (existingBanner == null)
            {
                return NotFound();
            }

            existingBanner.Name = banner.Name;
            existingBanner.Status = banner.Status;
            existingBanner.Priority = banner.Priority;
            existingBanner.Image = banner.Image;
            existingBanner.Description = banner.Description;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var banner = Banners.FirstOrDefault(b => b.Id == id);

            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        public IActionResult Delete(int id)
        {
            var banner = Banners.FirstOrDefault(b => b.Id == id);

            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var banner = Banners.FirstOrDefault(b => b.Id == id);

            if (banner == null)
            {
                return NotFound();
            }

            Banners.Remove(banner);

            return RedirectToAction(nameof(Index));
        }
    }
}