using Hack2019PO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hack2019PO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {           
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            //Return search window
            return View("Search");
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            AttendanceRecord[] records = Internals.OpenDataHandler.GetAttendanceFromWeb(name);
            //Return Result
            return records != null ? View("Result", records) : View("ResultEmpty", new AttendanceRecord() { Name = name});
        }
    }
}