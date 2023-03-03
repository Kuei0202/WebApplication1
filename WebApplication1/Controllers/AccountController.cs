using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly WebApplication1Context _context;
        private readonly ILogger<AccountController> _logger;
        public AccountController(WebApplication1Context context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            _logger.LogInformation("這是登入畫面");
            return View(new User_account());
        }

        public ActionResult Register()
        {
            return View(new Temp_User_Data());
        }

        [HttpPost]
        public ActionResult Login(User_account login_try)
        {
            bool check = _context.User_account.Where(p => p.Account == login_try.Account
                        && p.Password == login_try.Password).Any();
            if (check)
            {
                HttpContext.Session.SetString("Name", login_try.Account);
                return RedirectToAction("Test", "Calendar_Table");
            }
            else
            {
                ViewBag.msg = "密碼不正確";
                return View(new User_account());
            }

        }
        [HttpPost]
        public ActionResult Register(Temp_User_Data user_data)
        {
            _logger.LogInformation("Exception Handle 1");
            if (user_data.Password != user_data.Password2)
            {
                ViewBag.msg = "輸入密碼不一致";
                return View(new Temp_User_Data());
            }

            User_account update_data = new User_account();
            update_data.Account = user_data.Account;
            update_data.Password = user_data.Password;

            bool check = _context.User_account.Where(p => p.Account == update_data.Account).Any();
            if (check)
            {
                ViewBag.msg = "帳號已存在";
                return View(new Temp_User_Data());
            }

            _context.User_account.Add(update_data);
            _context.SaveChanges();
            return RedirectToAction("Login", "Account");

        }
    }
}
