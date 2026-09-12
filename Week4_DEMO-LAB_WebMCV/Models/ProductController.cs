using Microsoft.AspNetCore.Mvc;
using Week4_DEMO_LAB_WebMCV.Models;


namespace Week4_DEMO_LAB_WebMCV.Models
{
    public class ProductController : Controller
    {
        protected Products product = new Products();

        [Route("San-pham", Name = "product")]
        public IActionResult Index()
        {
            ViewBag.Category = product.Category;
            var products = product.getProducts();
            return View(products);
        }

        [Route("Danh-muc/{categoryId:int}", Name = "category")]
        public IActionResult Category(int categoryId)
        {
            var products = product.getProducts();
            var resultProduct = products.Where(product => product.CategoryId == categoryId).ToList();

            ViewBag.Category = product.Category;
            ViewBag.SelectedCategoryId = categoryId;
            return View(resultProduct);

        }


        public PartialViewResult ShowCategory()
        {
            var categories = product.Category;
            return PartialView(categories);
        }
    }
}
