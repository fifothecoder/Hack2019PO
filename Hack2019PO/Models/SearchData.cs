using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hack2019PO.Models
{
    public class SearchData
    {
        public AttendanceRecord[] attendanceRecords;
        public VotingRecord[] votingRecords;
        public SearchData(AttendanceRecord[] ar, VotingRecord[] vr)
        {
            attendanceRecords = ar;
            votingRecords = vr;
        }
    }
}