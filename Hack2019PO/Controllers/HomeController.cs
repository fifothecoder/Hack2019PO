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
            AttendanceRecord[] attendanceRecord = Internals.OpenDataHandler.GetAttendanceFromWeb(name);
            VotingRecord[] votingRecords = Internals.OpenDataHandler.GetVotingFromWeb(name);

            SearchData result = new SearchData(attendanceRecord, votingRecords);

            //Return Result
            return (attendanceRecord != null || votingRecords != null) ? View("Result", result) : View("ResultEmpty", new AttendanceRecord() { Name = name});
        }



    }
}