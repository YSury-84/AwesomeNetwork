using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Model.DB;
using SocialNetwork.Model.Repository;
using SocialNetwork.Views;
using System.Collections.Generic;
using System.IO;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        // ссылка на репозиторий
        public readonly IUserRepository _users;

        // Также добавим инициализацию в конструктор
        public HomeController(ILogger<HomeController> logger, IUserRepository users)
        {
            _users = users;
        }
        // GET: HomeController
        public ActionResult Index(User user)
        {
            return View();
        }

        // GET: HomeController
        [HttpPost]
        public ActionResult Register(User user)
        {
            _users.AddUser(user);
            return View();
        }

        // GET: HomeController/Details
        [HttpPost]
        public ActionResult Details(User user)
        {
            _users.ReadUser(ref user);
            ViewBag.User = user;
            List<User> users = new List<User>();
            _users.ReadUsers(ref users);
            ViewBag.Users = users;
            List<string> freinds = new List<string>();
            _users.ListFreinds(user.Login, ref freinds);
            ViewBag.Freinds = freinds;
            return View();
        }
        // POST: HomeController/Edit/5
        [HttpPost]
        public ActionResult Freind(Friend friend)
        {

            StreamWriter sw = new StreamWriter("Test.txt");
            sw.WriteLine(friend.UserLogin + "->" + friend.FrendLogin);
            sw.Close();

            _users.AddFriend(friend);
            return View();
        }

    }
}
