using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Final_webApiAssignment.Models;

namespace Final_webApiAssignment.Controllers
{
    public class BookingController : ApiController
    {
        [AllowAnonymous]
        //[ResponseType(typeof(room))]
        //[HttpGet]
        [Route("Individualbooking")]
        public IHttpActionResult GetAllbooking()
        {
            IList<BookingViewModel> booking = null;
            using (var x = new WebApiDemo_DBEntities())
            {
                booking = x.bookings.Select(h => new BookingViewModel()
                {
                    booking_id = h.booking_id,
                    room_id = h.room_id.ToString(),
                    status = h.status,
                    booking_date = h.booking_date.ToString()
                                
               
                }).ToList<BookingViewModel>();
            }
            if (booking.Count == 0)
            {
                return NotFound();
            }
            return Ok(booking);
        }
        //[HttpPost]
        [Route("Individualbooking/Addbooking")]
        public IHttpActionResult AddRoom(BookingViewModel booking)
        {
            using (var x = new WebApiDemo_DBEntities())
            {
                x.bookings.Add(new booking()
                {
                    booking_id = booking.booking_id,
                    room_id =int.Parse(booking.room_id),
                    status = booking.status,
                    booking_date =DateTime.Parse(booking.booking_date)

                });
                x.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        [Route("Individualbooking/Updatebooking")]
        public IHttpActionResult Updateroom(BookingViewModel booking)
        {
            using (var x = new WebApiDemo_DBEntities())
            {
                var checkbookingllist = x.bookings.Where(h => h.booking_id == booking.booking_id).FirstOrDefault<booking>();
                if (checkbookingllist != null)
                {
                    
                    checkbookingllist.room_id = int.Parse(booking.room_id);
                    checkbookingllist.status = booking.status;
                    checkbookingllist.booking_date = DateTime.Parse(booking.booking_date);


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
