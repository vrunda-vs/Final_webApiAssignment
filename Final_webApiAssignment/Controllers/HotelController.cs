using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Final_webApiAssignment.Models;
using System.Web.Http.Description;

namespace Final_webApiAssignment.Controllers
{
    public class HotelController : ApiController
    {
        [AllowAnonymous]
        //[ResponseType(typeof(Hotel))]
        //[HttpGet]
        [Route("Individual")]
        public IHttpActionResult GetAllHotel()
        {
            IList<HotelViewModel> hotel = null;
            using (var x = new WebApiDemo_DBEntities())
            {
                hotel = x.Hotels.Select(h => new HotelViewModel()
                {
                    Hotel_Id = h.Hotel_ID,
                    Hotel_name = h.hotel_name,
                    Hotel_address = h.hotel_address,
                    Hotel_city = h.hotel_city,
                    Hotel_pincode = h.hotel_pincode,
                    Hotel_mno = h.hotel_mno,
                    Hotel_contact_person = h.hotel_contact_person,
                    website = h.website,
                    facebook = h.facebook,
                    twitter = h.twitter,
                    //isactive= h.isactive,
                    //created_date=h.created_date,
                    created_by=h.created_by,
                    //updated_date=h.updated_date,
                    updated_by=h.updated_by
                    
                }).ToList<HotelViewModel>();
            }
            if (hotel.Count == 0)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        //[HttpPost]
        [Route("Individual/Addhotel")]
        public IHttpActionResult AddHotel(HotelViewModel hotel)
    {
        using (var x = new WebApiDemo_DBEntities())
        {
            x.Hotels.Add(new Hotel()
            {
                hotel_name = hotel.Hotel_name,
                hotel_address = hotel.Hotel_address,
                hotel_city = hotel.Hotel_city,
                hotel_pincode = hotel.Hotel_pincode,
                hotel_mno = hotel.Hotel_mno,
                hotel_contact_person = hotel.Hotel_contact_person,
                website = hotel.website,
                facebook = hotel.facebook,
                twitter = hotel.twitter,
                created_by = hotel.created_by,
                updated_by = hotel.updated_by
            });
            x.SaveChanges();
        }
        return Ok();
    }
        [Route("Individual/Updatehotel")]
        public IHttpActionResult UpdateHotel(HotelViewModel hotel)
        {
            using (var x = new WebApiDemo_DBEntities())
            {
                var checkhotellist = x.Hotels.Where(h => h.Hotel_ID == hotel.Hotel_Id).FirstOrDefault<Hotel>();
                if (checkhotellist != null)
                {
                    checkhotellist.hotel_name = hotel.Hotel_name;
                    checkhotellist.hotel_address = hotel.Hotel_address;
                    checkhotellist.hotel_city = hotel.Hotel_city;
                    checkhotellist.hotel_pincode = hotel.Hotel_pincode;
                    checkhotellist.hotel_mno = hotel.Hotel_mno;
                    checkhotellist.hotel_contact_person = hotel.Hotel_contact_person;
                    checkhotellist.website = hotel.website;
                    checkhotellist.facebook = hotel.facebook;
                    checkhotellist.twitter = hotel.twitter;
                    checkhotellist.created_by = hotel.created_by;
                    //updated_date=h.updated_date,
                    checkhotellist.updated_by = hotel.updated_by;
                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
                return Ok();
            
        }
        [Route("Individual/Deletehotel")]
        public IHttpActionResult deleteHotel(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please enter valid hotel id");
            }
            using (var x = new WebApiDemo_DBEntities())
            {
                var hotel = x.Hotels.Where(h => h.Hotel_ID == id).FirstOrDefault();
                x.Entry(hotel).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }
            return Ok();
            }
        }
}
