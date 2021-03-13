using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_webApiAssignment.Models
{
    public class BookingViewModel
    {
        public int booking_id { set; get; }
        public string room_id { set; get; }
        public string booking_date { set; get; }
        public string status { set; get; }

    }
}