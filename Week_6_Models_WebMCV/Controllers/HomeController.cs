using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Week_6_Models_WebMCV.Models;

namespace Week_6_Models_WebMCV.Controllers
{
    public class HomeController : Controller
    {
        // Simple in-memory store for User entities used by Home controller actions.
        // This is for demo purposes only.
        private static readonly List<User> _users = new List<User>
        {
            new User { Id = 1, name = "Mark Smith", address = "Park Street", email = "Mark@mvcexample.com" },
            new User { Id = 2, name = "John Parker", address = "New Park", email = "John@mvcexample.com" },
            new User { Id = 3, name = "Steave Edward", address = "Melbourne Street", email = "steave@mvcexample.com" }
        };
        private static long _nextId = 4;
        public IActionResult Index()
        {
            // The Index view is strongly-typed to the Login model.
            // Return an instance of Login instead of a List<User> to avoid InvalidOperationException.
            var login = new Login();
            return View(login);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(string userName, string password)
        {
            if(userName == "Peter" && password == "password")
            {
                string msg = "welcome " + userName;
                return Content(msg);
            }
            else
            {
                // Return the Login model back to the view so the view's expected model type matches.
                var model = new Login { userName = userName };
                return View(model);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.Id = _nextId++;
            _users.Add(user);
            return RedirectToAction(nameof(Users));
        }

        // List all users
        public IActionResult Users()
        {
            return View(_users);
        }

        // Details view
        public IActionResult Details(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // Edit (GET)
        public IActionResult Edit(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _users.FirstOrDefault(u => u.Id == model.Id);
            if (user == null) return NotFound();

            user.name = model.name;
            user.address = model.address;
            user.email = model.email;

            return RedirectToAction(nameof(Users));
        }


    }
}
