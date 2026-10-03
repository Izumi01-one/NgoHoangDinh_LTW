using Microsoft.AspNetCore.Mvc;
using Week_7_Lab5.Models;

namespace Week_7_Lab5.Controllers
{
    public class CategoryController : Controller
    {
        // Danh sách lưu dữ liệu tạm thời
        private static readonly List<Category> categories = new();

        public IActionResult Index()
        {
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            // Tự tăng Id khi chưa dùng database
            category.Id = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;

            categories.Add(category);

            // Chuyển về action Index
            return RedirectToAction(nameof(Index));
        }
    }
}