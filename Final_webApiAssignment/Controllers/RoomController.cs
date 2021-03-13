using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Final_webApiAssignment.Models;

namespace Final_webApiAssignment.Controllers
{
    public class RoomController : ApiController
    {
        [AllowAnonymous]
        //[ResponseType(typeof(room))]
        //[HttpGet]
        [Route("Individualroom")]
        public IHttpActionResult GetAllroom()
        {
            IList<RoomViewModel> room = null;
            using (var x = new WebApiDemo_DBEntities())
            {
                room = x.rooms.Select(h => new RoomViewModel()
                {
                    Room_Id = h.Room_Id,
                    room_name = h.room_name,
                    room_category = h.room_category,
                    room_price = h.room_price.ToString(),
                    isactive = h.isactive.ToString(),
                    

                }).ToList<RoomViewModel>();
            }
            if (room.Count == 0)
            {
                return NotFound();
            }
            return Ok(room);
        }
        //[HttpPost]
        [Route("Individualroom/Addroom")]
        public IHttpActionResult AddRoom(RoomViewModel room)
        {
            using (var x = new WebApiDemo_DBEntities())
            {
                x.rooms.Add(new room()
                {
                    room_name = room.room_name,
                    room_category = room.room_category,
                    Hotel_ID=room.Hotel_ID,
                    room_price = double.Parse(room.room_price),
                    isactive = int.Parse(room.isactive.ToString())
                    
                });
                x.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        [Route("Individualroom/Updateroom")]
        public IHttpActionResult Updateroom(RoomViewModel room)
        {
            using (var x = new WebApiDemo_DBEntities())
            {
                var checkroomllist = x.rooms.Where(h => h.Room_Id == room.Room_Id).FirstOrDefault<room>();
                if (checkroomllist != null)
                {
                    checkroomllist.room_name = room.room_name;
                    checkroomllist.room_category = room.room_category;
                    checkroomllist.Hotel_ID = room.Hotel_ID;
                    checkroomllist.room_price = double.Parse(room.room_price);
                    checkroomllist.isactive = int.Parse(room.isactive.ToString());


                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();

        }
    }
}
