using Microsoft.AspNetCore.Mvc;
using Week_9_Entity_CRUD.Models;

namespace Week_9_Entity_CRUD.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "iPhone 16 Pro Max",
                Price = 34990000,
                SalePrice = 32990000,
                Status = 1,
                CategoryId = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "iphone-16-pro-max.jpg",
                Description = "Điện thoại cao cấp của Apple"
            },
            new Product
            {
                Id = 2,
                Name = "Samsung Galaxy S25 Ultra",
                Price = 33990000,
                SalePrice = 31990000,
                Status = 1,
                CategoryId = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "samsung-galaxy-s25-ultra.jpg",
                Description = "Điện thoại cao cấp của Samsung"
            },
            new Product
            {
                Id = 3,
                Name = "Laptop Dell Inspiron 15",
                Price = 18990000,
                SalePrice = 17490000,
                Status = 1,
                CategoryId = 2,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "dell-inspiron-15.jpg",
                Description = "Laptop phục vụ học tập và làm việc"
            },
            new Product
            {
                Id = 4,
                Name = "MacBook Air M4",
                Price = 28990000,
                SalePrice = 27990000,
                Status = 1,
                CategoryId = 2,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "macbook-air-m4.jpg",
                Description = "Laptop mỏng nhẹ sử dụng chip Apple M4"
            },
            new Product
            {
                Id = 5,
                Name = "iPad Air M3",
                Price = 16990000,
                SalePrice = 15990000,
                Status = 1,
                CategoryId = 3,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "ipad-air-m3.jpg",
                Description = "Máy tính bảng phục vụ học tập và giải trí"
            },
            new Product
            {
                Id = 6,
                Name = "Tai nghe Sony WH-1000XM5",
                Price = 8990000,
                SalePrice = 7490000,
                Status = 1,
                CategoryId = 4,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "sony-wh-1000xm5.jpg",
                Description = "Tai nghe Bluetooth chống ồn"
            },
            new Product
            {
                Id = 7,
                Name = "Sạc dự phòng 20000mAh",
                Price = 990000,
                SalePrice = 790000,
                Status = 1,
                CategoryId = 5,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "sac-du-phong-20000mah.jpg",
                Description = "Sạc dự phòng dung lượng lớn"
            }
        };

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            product.Id = Products.Count == 0
                ? 1
                : Products.Max(p => p.Id) + 1;

            if (product.CreatedDate == default)
            {
                product.CreatedDate = DateTime.Today;
            }

            Products.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var existingProduct = Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.SalePrice = product.SalePrice;
            existingProduct.Status = product.Status;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.CreatedDate = product.CreatedDate;
            existingProduct.Image = product.Image;
            existingProduct.Description = product.Description;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}