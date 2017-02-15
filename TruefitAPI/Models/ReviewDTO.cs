using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public string RestaurantName { get; set; }
        public string UserName { get; set; }
        public string ReviewComment { get; set; }
        public int Rating { get; set; }
        public string DateTimeVisited { get; set; }
        public string DateRevieweWritten { get; set; }
    }
}