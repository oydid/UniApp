namespace UniApp.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Length must be between 10 - 255")]
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Relationships
        [Display(Name = "Actors")]
        public List<int> Actor_Ids { get; set; }
        [Display(Name = "Studio")]
        public int StudioId { get; set; }
    }
}
