using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingTime.Models
{
    public enum UserType
    {
        Client,
        Admin
    }

    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int Id { get; set; }

        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //one2one
        [Display(Name = "My Goal List")]
        public MyGoalList MyGoalList { get; set; }

        //one2many
        public int BookId { get; set; }

        [Display(Name = "I highly recommend it")]
        public Book Book { get; set; }

        public UserType Type { get; set; } = UserType.Client;




    }
}
