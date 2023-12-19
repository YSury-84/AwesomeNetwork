using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Model.DB;
using SocialNetwork.Model.Repository;
using SocialNetwork.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
            using StreamWriter writer = new StreamWriter("debug\\index.txt");
            DateTime now = DateTime.Now;
            writer.WriteLine(Convert.ToString(now));
            writer.Close();
            string cLogin = Request.Cookies["Login"];
            string cPassReg = Request.Cookies["PassReg"];
            if (cLogin != "" && cPassReg != "")
            {
                user.Login = cLogin;
                user.PassReg = cPassReg;
                return RedirectToAction("Details", "Home");
            }
            return View();
        }

        // GET: HomeController
        [HttpPost]
        public ActionResult Register(User user)
        {
            using StreamWriter writer = new StreamWriter("debug\\register.txt");
            DateTime now = DateTime.Now;
            writer.WriteLine(Convert.ToString(now));
            writer.Close();
            _users.AddUser(user);
            string cLogin = Request.Cookies["Login"];
            string cPassReg = Request.Cookies["PassReg"];
            Thread.Sleep(2000);
            if (cLogin != "" && cPassReg != "")
            {
                return RedirectToAction("Details", "Home");
            }
            return View();
        }

        // GET: HomeController/Details
        public ActionResult Details(User user)
        {
            using StreamWriter writer = new StreamWriter("debug\\details.txt");
            DateTime now = DateTime.Now;
            writer.WriteLine(Convert.ToString(now));
            writer.Close();

            string cLogin = Request.Cookies["Login"];
            string cPassReg = Request.Cookies["PassReg"];
            if (cLogin != "" & cPassReg != "")
                {
                user.Login = cLogin;
                user.PassReg = cPassReg;

                using StreamWriter writer2 = new StreamWriter("debug\\coock.txt");
                writer2.WriteLine(cLogin);
                writer2.WriteLine(cPassReg);
                writer2.Close();

            }

            _users.ReadUser(ref user);
            ViewBag.User = user;
            List<User> users = new List<User>();
            _users.ReadUsers(ref users);
            ViewBag.Users = users;
            List<string> freinds = new List<string>();
            _users.ListFreinds(user.Login, ref freinds);
            ViewBag.Freinds = freinds;
            if (user.Login == "")
                return RedirectToAction("Index", "Home");

            using StreamWriter writer3 = new StreamWriter("debug\\text.txt");
            writer3.WriteLine("."+user.Login+".");
            writer3.WriteLine("."+user.PassReg+".");
            writer3.WriteLine("."+cLogin+".");
            writer3.WriteLine("."+cPassReg+".");
            if (cLogin == null) writer3.WriteLine(". cLogin = null.");
            if (user.Login == null) writer3.WriteLine(". user.Login = null.");
            writer3.Close();

            if (user.Login != "" & cLogin == "")
            {
                Response.Cookies.Append("Login", user.Login);
                Response.Cookies.Append("PassReg", user.PassReg);
            } else
            if (user.Login != "" & cLogin == null)
            {
                Response.Cookies.Append("Login", user.Login);
                Response.Cookies.Append("PassReg", user.PassReg);
            }

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
