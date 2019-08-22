using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Descrition { get; set; }
        [Display(Name = "Продюсер")]
        [MaxLength(50)]
        public string Director { get; set; }
        public int Year { get; set; }
        public string PosterURL { get; set; }
        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }
        public void Update(Film film)
        {
            this.Name = film.Name;
            this.Descrition = film.Descrition;
            this.Director = film.Director;
            this.PosterURL = film.PosterURL;
            this.Year = film.Year;
        }
    }
}