using Week_3_Shopping_WebMCV.Models;
using Microsoft.AspNetCore.Mvc;

namespace Week_3_Shopping_WebMCV.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/1.jpeg"),
                    Gender = 1, 
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)

                },
                new Account()
                {
                    Id = 2,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/2.jpeg"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)

                },
                new Account()
                {
                    Id = 3,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/3.jpeg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)

                },
            };
            ViewBag.Accounts = accounts;

            return View();
        }

        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/1.jpeg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)

                },
                new Account()
                {
                    Id = 2,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/2.jpeg"),
                    Gender = 0,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)

                },
                new Account()
                {
                    Id = 3,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/3.jpeg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)

                },
            };

            Account account = accounts.FirstOrDefault(ac => ac.Id == id);

            ViewBag.Account = account;

            return View("ProfileView");
        }
    }
}
