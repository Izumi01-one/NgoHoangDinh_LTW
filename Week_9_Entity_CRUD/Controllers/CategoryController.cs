using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week_9_Entity_CRUD.Models;

namespace Week_9_Entity_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly List<Category> Categories = new List<Category>()
        {
            new Category
            {
                Id = 1,
                Name = "Điện thoại",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "dien-thoai.jpg",
                Description = "Các sản phẩm điện thoại di động"
            },
            new Category
            {
                Id = 2,
                Name = "Laptop",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "laptop.jpg",
                Description = "Các sản phẩm máy tính xách tay"
            },
            new Category
            {
                Id = 3,
                Name = "Máy tính bảng",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "may-tinh-bang.jpg",
                Description = "Các sản phẩm máy tính bảng"
            },
            new Category
            {
                Id = 4,
                Name = "Tai nghe",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "tai-nghe.jpg",
                Description = "Tai nghe có dây và không dây"
            },
            new Category
            {
                Id = 5,
                Name = "Phụ kiện",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "phu-kien.jpg",
                Description = "Phụ kiện dành cho thiết bị công nghệ"
            }

        };
        public IActionResult Index()
        {
            return View(Categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            Categories.Add(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Category category)
        {
            for(int i = 0; i < Categories.Count; i++)
            {
                if (Categories[i].Id == Id)
                {
                    Categories[i].Id = category.Id;
                    Categories[i].Name = category.Name;
                    Categories[i].Status = category.Status;
                    Categories[i].CreatedDate = category.CreatedDate;
                    Categories[i].Image = category.Image;
                    Categories[i].Description = category.Description;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var category = Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
