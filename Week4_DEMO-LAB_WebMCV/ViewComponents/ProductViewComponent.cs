using Microsoft.AspNetCore.Mvc;
using Week4_DEMO_LAB_WebMCV.Models;

namespace Week4_DEMO_LAB_WebMCV.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly Products product = new Products();

        public IViewComponentResult Invoke()
        {
            return View(product.getProducts());
        }
    }
}
