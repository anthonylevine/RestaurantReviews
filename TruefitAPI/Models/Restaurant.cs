using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int PriceRangeId { get; set; }
        [Required]
        public int AdminId { get; set;  }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string AddressTwo { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        public string WebsiteURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string Hours { get; set; }
        public string ImageLocations { get; set; }
        [NotMapped]
        public string[] Images
        {
            get
            {
                return ImageLocations.Split('|');
            }
        }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool TakesReservations { get; set; }
        [Required]
        public bool OffersDelivery { get; set; }
        [Required]
        public bool OffersTakeout { get; set; }
        [Required]
        public bool AcceptsCreditCards { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [Timestamp]
        public Byte[] LastUpdatedDate { get; set; }
        public RestaurantCategory Category { get; set; }
        public RestaurantPriceRange PriceRange { get; set; }
        public User Admin { get; set; }
    }
}