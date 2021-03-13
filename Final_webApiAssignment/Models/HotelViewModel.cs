using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_webApiAssignment.Models
{
    public class HotelViewModel
    {
        public int Hotel_Id { get; set; }
        public string Hotel_name { get; set; }

        public string Hotel_address  { get; set; }
        public string Hotel_city { get; set; }
        public string Hotel_pincode { get; set; }
        public string Hotel_mno { get; set; }
        public string Hotel_contact_person { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        //public string isactive { get; set; }

        
        public string created_by { get; set; }
        
        public string updated_by { get; set; }

    }
}