using Hack2019PO.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            AttendanceRecord[] attendanceRecordTask = Internals.OpenDataHandler.GetAttendanceFromWeb(name);
            VotingRecord[] votingRecordTask = Internals.OpenDataHandler.GetVotingFromWeb(name);

            SearchData data = new SearchData(attendanceRecordTask, votingRecordTask);
            return (data.attendanceRecords == null && data.votingRecords == null) ? View("ResultEmpty", new AttendanceRecord() { Name = name}) : View("Result", data);
        }

        [HttpPost]
        public ActionResult SearchParty(string party)
        {
            party = Internals.Prettifiers.DeprettifyPartyName(party);
            AttendanceRecord[] attendanceRecordTask = Internals.OpenDataHandler.GetAttendancePartyFromWeb(party);
            VotingRecord[] votingRecordTask = Internals.OpenDataHandler.GetVotingPartyFromWeb(party);

            SearchData data = new SearchData(attendanceRecordTask, votingRecordTask);
            return (data.attendanceRecords == null && data.votingRecords == null) ? View("ResultEmpty", new AttendanceRecord() { Name = party }) : View("ResultParty", data);
        }

        [HttpGet]
        public ActionResult LookupVoting()
        {
            return View("LookupVotingRooms");
        }

        [HttpGet]
        public ActionResult Statistics()
        {
            return View("Statistics");
        }

        

    }
}