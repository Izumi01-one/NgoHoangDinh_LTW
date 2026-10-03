using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Week_7_Lab5.Models;

namespace Week_7_Lab5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            return View(accounts);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            Account model = new Account();
            return View(model);

        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(@"^\(?[0-9]{3}\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (!_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} không đúng định dạng");
            }
            return Json(true);
        }
    }
}
