using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingTime.Models
{
    public class Genre
    {

        [Key]
        [Display(Name = "Genre ID")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string GenreName { get; set; }

        [Display(Name = "Related Books")]
        public virtual List<Book> BookList { get; set; }
    }
}
