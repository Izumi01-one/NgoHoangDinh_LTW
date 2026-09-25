using Microsoft.AspNetCore.Mvc;
using Week_6_WebMCV.Models;

namespace Week_6_WebMCV.Controllers
{
    public class MemberController : Controller
    {

        // mock data
        private static readonly List<Member> _Members = new List<Member>()
        {
            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberUserName = "ngohoangdinh",
                MemberPassword = "123456",
                MemberEmail = "ngohoangdinh@gmail.com",
                MemberFullName = "Ngô Hoàng Đỉnh"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberUserName = "tranthib",
                MemberPassword = "123456",
                MemberEmail = "tranthib@gmail.com",
                MemberFullName = "Trần Thị Bình"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberUserName = "levanc",
                MemberPassword = "123456",
                MemberEmail = "levanc@gmail.com",
                MemberFullName = "Lê Văn Cường"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberUserName = "phamthid",
                MemberPassword = "123456",
                MemberEmail = "phamthid@gmail.com",
                MemberFullName = "Phạm Thị Dung"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberUserName = "hoangvane",
                MemberPassword = "123456",
                MemberEmail = "hoangvane@gmail.com",
                MemberFullName = "Hoàng Văn Em"
            }

        };


        // get list
        public IActionResult Index()
        {
            return View(_Members);
        }


        // create
        public IActionResult Create()
        {

            return View();
        }


        // create submit form
        [HttpPost]
        public IActionResult Create(Member tvcMember)
        {
            tvcMember.MemberId = Guid.NewGuid().ToString();
            _Members.Add(tvcMember);
            return RedirectToAction("Index");
        }


        // edit
        public IActionResult Edit(string id)
        {
            var tvcMember = _Members.FirstOrDefault(m => m.MemberId == id);
            return View(tvcMember);
        }

        [HttpPost]
        public IActionResult Edit(string id,Member tvcMember)
        {
            for(int i = 0; i < _Members.Count; i++)
            {
                if (_Members[i].MemberId == id)
                {
                    _Members[i].MemberId = tvcMember.MemberId;
                    _Members[i].MemberUserName = tvcMember.MemberUserName;
                    _Members[i].MemberPassword = tvcMember.MemberPassword;
                    _Members[i].MemberEmail = tvcMember.MemberEmail;
                    _Members[i].MemberFullName = tvcMember.MemberFullName;
                    break;
                }
               
            }
            return RedirectToAction("Index");
        }


        public IActionResult GetDetail()
        {


            var member = new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberUserName = "NgoDinh",
                MemberPassword = "Dinh111@",
                MemberFullName = "Ngô Hoàng Đỉnh",
                MemberEmail = "ngohoangdinh@gmail.com"
            };
            return View(member);
        }
    }
}
