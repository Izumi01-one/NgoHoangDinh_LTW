using Microsoft.AspNetCore.Mvc.Rendering;

namespace Week4_DEMO_LAB_WebMCV.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public DateTime MFD{ get; set; }
        public int Price { get; set; }


        public List<Products> getProducts()
        {
            List<Products> products = new List<Products>()
            {
                new Products()
                {
                    Id = 1,
                    Name = "Nồi cơm điện cao tần Nagakawa",
                    Image = "/images/products/b1.jpg",
                    CategoryId = 1,
                    MFD = new DateTime(2026, 9, 11),
                    Price = 5000000
                },
                new Products()
                {
                    Id = 2,
                    Name = "Nồi cơm điện Panasonic",
                    Image = "/images/products/b1.jpg",
                    CategoryId = 1,
                    MFD = new DateTime(2026, 8, 11),
                    Price = 5000000
                },
                new Products()
                {
                    Id = 3,
                    Name = "Nồi cơm điện Midea",
                    Image = "/images/products/b1.jpg",
                    CategoryId = 1,
                    MFD = new DateTime(2026, 7, 11),
                    Price = 5000000
                },


            };
            return products;
        }

        public List<SelectListItem> Category { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "Áo dài"},
            new SelectListItem {Value = "2", Text = "Áo đông"},
            new SelectListItem {Value = "3", Text = "Túi xách"},
            new SelectListItem {Value = "4", Text = "Đồng hồ"},
            new SelectListItem {Value = "5", Text = "Ví da"},
            new SelectListItem {Value = "6", Text = "Thắt lưng da"},
            new SelectListItem {Value = "7", Text = "Tủ lạnh"},
            new SelectListItem {Value = "8", Text = "Tivi"},
            new SelectListItem {Value = "9", Text = "Quạt điện"},
            new SelectListItem {Value = "10", Text = "Lò sưởi"}
        };

    }
}
