﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hack2019PO.Models;

namespace Hack2019PO.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(MapData data)
        {
            VoteDistrict vd = Internals.OpenDataHandler.GetDistrict("Volgogradská", "26");

            return View("Result", vd);
        }
    }
}