using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProjectN01649276.Models
{
    public class Booking
    {
        [Key]
        public int BookingId {  get; set; }
        
        public string Bookingdate { get; set; }

        public string Status { get; set; }

        //A booking have one customer
        //A customer have many bookings

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
    }

    public class BookingDto
    {
        public int BookingId { get; set; }

        public string Bookingdate { get; set; }

        public string Status { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int TourId { get; set; }
        public string TourName { get; set; }
    }
}