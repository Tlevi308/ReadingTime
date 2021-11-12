using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingTime.Models
{
    public class Book
    {
        [Key]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "You mast write description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Enter URL for image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "You should choose YES, NO or Reading now")]
        [Display(Name = "Did I read that")]
        public Boolean Read { get; set; }

        //many2many
        public List<MyGoalList> Lists { get; set; }

        //many2one
        [Display(Name = "Who recommend on me")]
        public List<User> Users { get; set; }

        //===================//
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }


    }
}
