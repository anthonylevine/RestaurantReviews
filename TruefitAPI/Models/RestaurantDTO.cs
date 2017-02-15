using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryLabel { get; set; }
        public int PriceRangeId { get; set; }
        public string PriceRangeLabel { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressTwo { get; set;  }
        public string City { get; set; }
        public string State { get; set;  }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string WebsiteURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string Hours { get; set; }      
    }
}