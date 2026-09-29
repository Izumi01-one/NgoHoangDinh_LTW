using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_7_Validatation.Models;

namespace Week_7_Validatation.Controllers
{
    public class TvcMemberController : Controller
    {
        private static List<TvcMember> tvcMembers = new List<TvcMember>();

        // GET: TvcMemberController
        public ActionResult Index()
        {
            return View(tvcMembers);
        }

        // GET: TvcMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TvcMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TvcMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TvcMember tvcMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tvcMember);
                }
                tvcMembers.Add(tvcMember);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TvcMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TvcMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TvcMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TvcMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
