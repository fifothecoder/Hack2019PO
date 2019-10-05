using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hack2019PO.Models
{
    public class VotingRecord
    {
        public string Session { get; set; }
        public string ProgramNumber { get; set; }
        public string ProgramPoint { get; set; }
        public string Note { get; set; }
        public string Person { get; set; }
        public string Party { get; set; }
        public string Vote { get; set; }


        public VotingRecord()
        {

        }

    }
}