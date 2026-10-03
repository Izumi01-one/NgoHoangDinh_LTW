using Microsoft.AspNetCore.Mvc;
using Week_7_Lab5.Models;

namespace Week_7_Lab5.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> products = new();

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (product.ImageFile != null &&
                product.ImageFile.Length > 0)
            {
                string uploadFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "products");

                Directory.CreateDirectory(uploadFolder);

                string extension = Path.GetExtension(
                    product.ImageFile.FileName);

                string fileName = $"{Guid.NewGuid()}{extension}";

                string filePath = Path.Combine(
                    uploadFolder,
                    fileName);

                await using FileStream stream =
                    new FileStream(filePath, FileMode.Create);

                await product.ImageFile.CopyToAsync(stream);

                product.ImageUrl =
                    $"/images/products/{fileName}";
            }

            // Không giữ đối tượng file trong danh sách
            product.ImageFile = null;

            products.Add(product);

            return RedirectToAction(nameof(Index));
        }
    }
}