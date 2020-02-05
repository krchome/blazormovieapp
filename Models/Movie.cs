using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovieApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        //Id from the aspnetusers table
        public string OwnerID { get; set; }
        [Required(ErrorMessage ="Movie title is required")]
        [StringLength(25, ErrorMessage ="Please keep the title below 25 characters")]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Director's name is required")]
        public string Director { get; set; }
        [Range(60, 240, ErrorMessage ="Value for {0} must be between {1} and {2}")]
        public int RunningTime { get; set; }
    }
}
