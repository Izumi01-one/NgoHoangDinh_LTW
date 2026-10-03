using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week_7_Lab5.Models
{
    public class Product : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Giá gốc")]
        [Required(ErrorMessage = "Giá gốc không được bỏ trống")]
        [Range(100000, double.MaxValue,
            ErrorMessage = "Giá gốc phải từ 100.000 trở lên")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống")]
        [Range(1, double.MaxValue,
            ErrorMessage = "Giá bán phải lớn hơn 0")]
        [DataType(DataType.Currency)]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
        [MaxLength(1500,
            ErrorMessage = "Mô tả sản phẩm tối đa 1500 ký tự")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Danh mục")]
        [Range(1, int.MaxValue,
            ErrorMessage = "Vui lòng chọn danh mục hợp lệ")]
        public int CategoryId { get; set; }

        // Đường dẫn ảnh sau khi lưu vào wwwroot
        public string? ImageUrl { get; set; }

        // File nhận từ form
        [NotMapped]
        [Display(Name = "Chọn hình ảnh")]
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh sản phẩm")]
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            // Giá bán phải thấp hơn giá gốc ít nhất 10%
            if (Price > 0 && SalePrice > Price * 0.9f)
            {
                yield return new ValidationResult(
                    "Giá bán phải thấp hơn giá gốc ít nhất 10%.",
                    new[] { nameof(SalePrice) });
            }

            string[] sensitiveWords =
            {
                "die",
                "admin",
                "fack"
            };

            if (!string.IsNullOrWhiteSpace(Description))
            {
                string descriptionLower =
                    Description.ToLowerInvariant();

                foreach (string word in sensitiveWords)
                {
                    if (descriptionLower.Contains(word))
                    {
                        yield return new ValidationResult(
                            $"Mô tả không được chứa từ nhạy cảm: {word}.",
                            new[] { nameof(Description) });

                        break;
                    }
                }
            }

            if (ImageFile != null)
            {
                string[] allowedExtensions =
                {
                    ".jpg",
                    ".jpeg",
                    ".png",
                    ".gif",
                    ".webp"
                };

                string extension = Path
                    .GetExtension(ImageFile.FileName)
                    .ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    yield return new ValidationResult(
                        "Hình ảnh phải có định dạng JPG, JPEG, PNG, GIF hoặc WEBP.",
                        new[] { nameof(ImageFile) });
                }

                // Giới hạn dung lượng 5 MB
                if (ImageFile.Length > 5 * 1024 * 1024)
                {
                    yield return new ValidationResult(
                        "Dung lượng hình ảnh không được vượt quá 5 MB.",
                        new[] { nameof(ImageFile) });
                }
            }
        }
    }
}