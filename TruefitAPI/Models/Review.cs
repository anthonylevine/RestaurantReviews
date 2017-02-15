using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ReviewComment { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public DateTime DateVisited { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [Timestamp]
        public Byte[] LastUpdatedDate { get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }
    }
}