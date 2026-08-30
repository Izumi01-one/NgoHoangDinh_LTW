namespace Week_3_Shopping_WebMCV.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
        public int Price {  get; set; }
        public int SalePrice {  get; set; }
        public int CategoryId {  get; set; }
        public string Decription {  get; set; }
        public int Status {  get; set; }
        public DateTime CreateAt { get; set; }
    }
}
