using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hack2019PO.Models
{
    public class AttendanceRecord
    {
        public string SessionID { get; set; }
        public string SessionDate { get; set; }

        public string Name { get; set; }
        public string Party { get; set; }
        public string Attended { get; set; }
    }
}