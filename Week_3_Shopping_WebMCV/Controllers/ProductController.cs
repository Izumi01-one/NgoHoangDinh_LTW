using Week_3_Shopping_WebMCV.Models;
using Microsoft.AspNetCore.Mvc;

namespace Week_3_Shopping_WebMCV.Controllers
{
    
    public class ProductController : Controller
    {
        public List<Product> createProducts()
        {
            List<Product> products = new List<Product> {
                new Product()
                {
                    Id = 1,
                    Name = "Đồ bơi cho trẻ em",
                    Image = Url.Content("~/images/Product/1.jpg"),
                    Price = 500000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Decription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Status = 1,
                    CreateAt = new DateTime(2001, 1, 1)
                },
                new Product()
                {
                    Id = 2,
                    Name = "Đồ bơi cho trẻ em thời trang",
                    Image = Url.Content("~/images/Product/2.jpg"),
                    Price = 500000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Decription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Status = 1,
                    CreateAt = new DateTime(2001, 1, 1)
                },
                new Product()
                {
                    Id = 3,
                    Name = "Đồ bơi cho trẻ em từ 3-5 tuổi",
                    Image = Url.Content("~/images/Product/3.jpg"),
                    Price = 500000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Decription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Status = 1,
                    CreateAt = new DateTime(2001, 1, 1)
                },
                new Product()
                {
                    Id = 4,
                    Name = "Túi xách cao cấp LV",
                    Image = Url.Content("~/images/Product/7.jpg"),
                    Price = 50000000,
                    SalePrice = 45000000,
                    CategoryId = 2,
                    Decription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Status = 1,
                    CreateAt = new DateTime(2001, 1, 1)
                },
                new Product()
                {
                    Id = 5,
                    Name = "Túi xách cao cấp LAVATINO",
                    Image = Url.Content("~/images/Product/8.jpg"),
                    Price = 60000000,
                    SalePrice = 55000000,
                    CategoryId = 2,
                    Decription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Status = 1,
                    CreateAt = new DateTime(2001, 1, 1)
                },
            };
            return products;
        }

        public Dictionary<int, string> createCategory()
        {
            return new Dictionary<int, string>
            {
                {1, "Quần áo" },
                {2, "Túi xách" },
                {3, "Đồng hồ" },
                {4, "Ti vi" },
                {5, "Tủ lạnh" },
                {6, "Máy bơm" },
                {7, "Quạt điện" },
                {8, "Lò sưởi" }
            };
        }



        [Route("San-pham", Name = "product")]
        public IActionResult Index()
        {
            List<Product> products = createProducts();
            ViewBag.Products = products;
            ViewBag.Categories = createCategory();
            return View();
        }

        [Route("Chi-tiet-san-pham/{id?}", Name = "productDetail")]
        public IActionResult Product(int Id)
        {
            List<Product> products = createProducts();

            Product? product = products.FirstOrDefault(pd => pd.Id == Id);
            if (product == null) {
                return NotFound($"không tìm thấy sản phẩm có Id = {Id}");
            }

            ViewBag.Product = product;
            return View("ProductView");
        }

        [Route("Danh-muc/{categoryId:int}", Name = "category")]
        public IActionResult Category(int categoryId) {
            List<Product> products = createProducts();


            // Lọc sp có CategoryId tương ứng
            List<Product> resultProducts = products.Where(product => product.CategoryId == categoryId).ToList();

            ViewBag.Products = resultProducts;
            ViewBag.Categories = createCategory();
            ViewBag.SelectedCategoryId = categoryId;


            return View("Index");
        }
    }
}
