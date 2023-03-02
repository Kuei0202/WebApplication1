using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Calendar_TableController : Controller
    {
        DateTime current = DateTime.Now;
        private readonly WebApplication1Context _context;

        public Calendar_TableController(WebApplication1Context context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult Test()
        {

            var list= _context.Calendar_Table.Where(p=>p.Item_Date.Year==current.Year
                      && p.Item_Date.Month == current.Month &&p.Create_User== HttpContext.Session.GetString("Name")).ToList();
            ViewBag.List = list;
            ViewBag.Current = current;

            return View(new Calendar_Table());
        }
        private bool Calendar_TableExists(int id)
        {
          return _context.Calendar_Table.Any(e => e.ID == id);
        }

        [HttpPost]
        public ActionResult Test(IFormCollection form,DateTime tm)
        {
            
            string date = form["day"].ToString();
            
            string content = form["incident"];
            DateTime sponse = DateTime.Now,
                uptime = new DateTime(tm.Year, tm.Month, Convert.ToInt32(date));
            Calendar_Table table = new Calendar_Table();
            
            if(content== null) {
                content = "";
            }
            table.Create_Date=sponse;
            table.Item_Date=uptime;
            table.Item_Content = content;
            table.Create_User=HttpContext.Session.GetString("Name");

            _context.Calendar_Table.Add(table);
            _context.SaveChanges();

            var list = _context.Calendar_Table.Where(p => p.Item_Date.Year == tm.Year
            && p.Item_Date.Month == tm.Month).ToList();
            ViewBag.List = list;
            ViewBag.Current = tm;
           
            return View(new Calendar_Table());
        }

        
        public ActionResult Update(int mode,DateTime tm)
        {
            DateTime temp = tm;
           if(mode == 0) 
            {
                ViewBag.Current = tm.AddMonths(-1);
                temp = temp.AddMonths(-1);
            }
            if (mode == 1)
            {
                ViewBag.Current = tm.AddMonths(1);
                temp = temp.AddMonths(1);
            }
            var list = _context.Calendar_Table.Where(p => p.Item_Date.Year == temp.Year
            && p.Item_Date.Month == temp.Month&& p.Create_User == HttpContext.Session.GetString("Name")).ToList();

            ViewBag.List = list;
            return View("~/Views/Calendar_Table/test.cshtml",new Calendar_Table());
        }
    }
}
