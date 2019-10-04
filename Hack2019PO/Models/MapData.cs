using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hack2019PO.Models
{
    public class MapData
    {
        public string Address;
        public string AddressNo;
        public MapData(string address, string addressNo)
        {
            Address = address;
            AddressNo = addressNo;
        }
    }
}