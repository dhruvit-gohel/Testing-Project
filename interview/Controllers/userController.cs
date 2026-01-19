using interview.DAL;
using interview.Models;
using Microsoft.AspNetCore.Mvc;

namespace interview.Controllers
{
    public class userController : Controller
    {
        private readonly User_DAL _dal;

        public userController(User_DAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User_Data> lst = new List<User_Data>();
            lst = _dal.Get_All();
            return View(lst);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User_Data model)
        {
            bool res = _dal.Insert_User(model);
            if (res)
            {




                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
