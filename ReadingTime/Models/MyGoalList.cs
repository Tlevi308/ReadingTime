using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingTime.Models
{
    public class MyGoalList
    {
        [Key]
        [Display(Name = "My Goal List ID")]
        public int Id { get; set; }


        //one2one
        public int UserId { get; set; }

        [Display(Name = "Your Goal List")]
        public User User { get; set; }


        //many2many
        [Display(Name = "Book List")]
        public List<Book> Books { get; set; }


    }
}
