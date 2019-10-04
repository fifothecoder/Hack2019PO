using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hack2019PO.Models
{
    public class VoteDistrict
    {
        public string Address;
        public string AddressNo;
        public string Venue;
        public string DistricAddress;
        public int DistricNo;


        public VoteDistrict(string address, string addressno,string venue, string districtAddress, int districtNo)
        {
            Address = address;
            AddressNo = addressno;
            Venue = venue;
            DistricAddress = districtAddress;
            DistricNo = districtNo;
        }
    }
}