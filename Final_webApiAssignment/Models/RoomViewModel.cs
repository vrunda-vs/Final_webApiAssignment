using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_webApiAssignment.Models
{
    public class RoomViewModel
    {
        public int Room_Id { get; set; }
        public int Hotel_ID { get; set; }

        public string room_name { get; set; }
        public string room_category { get; set; }
        public string room_price { get; set; }
        public string isactive { get; set; }
        

    }
}