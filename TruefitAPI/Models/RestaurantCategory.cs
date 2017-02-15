using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class RestaurantCategory
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public bool Active { get; set; }
        [Timestamp]
        public Byte[] LastUpdatedDate { get; set; }
    }
}