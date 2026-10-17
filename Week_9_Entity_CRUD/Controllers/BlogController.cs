using Microsoft.AspNetCore.Mvc;
using Week_9_Entity_CRUD.Models;

namespace Week_9_Entity_CRUD.Controllers
{
    public class BlogController : Controller
    {
        private static readonly List<Blog> Blogs = new List<Blog>()
        {
            new Blog
            {
                Id = 1,
                Name = "Cách chọn điện thoại phù hợp",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 1),
                Image = "cach-chon-dien-thoai.jpg",
                Description = "Hướng dẫn lựa chọn điện thoại phù hợp với nhu cầu"
            },
            new Blog
            {
                Id = 2,
                Name = "Kinh nghiệm mua laptop",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 2),
                Image = "kinh-nghiem-mua-laptop.jpg",
                Description = "Những kinh nghiệm cần biết khi mua laptop"
            },
            new Blog
            {
                Id = 3,
                Name = "Các phụ kiện công nghệ cần thiết",
                Status = 1,
                CreatedDate = new DateTime(2026, 1, 3),
                Image = "phu-kien-cong-nghe.jpg",
                Description = "Danh sách các phụ kiện công nghệ hữu ích"
            },
            new Blog
            {
                Id = 4,
                Name = "Cách bảo quản pin điện thoại",
                Status = 0,
                CreatedDate = new DateTime(2026, 1, 4),
                Image = "bao-quan-pin-dien-thoai.jpg",
                Description = "Hướng dẫn sử dụng và bảo quản pin điện thoại"
            }
        };

        public IActionResult Index()
        {
            return View(Blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            blog.Id = Blogs.Count == 0
                ? 1
                : Blogs.Max(b => b.Id) + 1;

            if (blog.CreatedDate == default)
            {
                blog.CreatedDate = DateTime.Today;
            }

            Blogs.Add(blog);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var blog = Blogs.FirstOrDefault(b => b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            var existingBlog = Blogs.FirstOrDefault(b => b.Id == id);

            if (existingBlog == null)
            {
                return NotFound();
            }

            existingBlog.Name = blog.Name;
            existingBlog.Status = blog.Status;
            existingBlog.CreatedDate = blog.CreatedDate;
            existingBlog.Image = blog.Image;
            existingBlog.Description = blog.Description;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var blog = Blogs.FirstOrDefault(b => b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        public IActionResult Delete(int id)
        {
            var blog = Blogs.FirstOrDefault(b => b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var blog = Blogs.FirstOrDefault(b => b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            Blogs.Remove(blog);

            return RedirectToAction(nameof(Index));
        }
    }
}