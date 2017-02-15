using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class UserFriends
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]
        [Key]
        public int FriendId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public User Friend { get; set; }

    }
}