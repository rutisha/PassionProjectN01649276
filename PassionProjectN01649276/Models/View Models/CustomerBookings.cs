using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProjectN01649276.Models.View_Models
{
    public class CustomerBookings
    {
        public CustomerDto SelectedCustomer { get; set; }
        public IEnumerable<BookingDto> RelatedBookings { get; set; }
    }
}