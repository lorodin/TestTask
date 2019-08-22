using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TestTask.Data.Models;
using TestTask.Util;

namespace TestTask.Models
{
    /// <summary>
    /// Модель представление для создания и редактирования фильма
    /// </summary>
    public class CreateFilmViewModel
    {
        public int Id { get; set; } = 0;

        [ValidateImage("JPEG|PNG", ErrorMessage = "Изображения могут быть только формата PNG и JPEG и не превышать 2 мегабайт")]
        [Display(Name = "Постер")]
        public HttpPostedFileWrapper PosterFile { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Название фильма")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Продюссер")]
        public string Director { get; set; }

        [Required]
        [Range(1895, Int32.MaxValue, ErrorMessage = "Первый фильм был снять в 1895 году!")]
        [Display(Name = "Год")]
        public int Year { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string PosterURL { get; set; }

        [DefaultValue(false)]
        public bool DeletePoster { get; set; }

        public static CreateFilmViewModel Create(Film film)
        {
            return new CreateFilmViewModel
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Descrition,
                Year = film.Year,
                Director = film.Director,
                PosterURL = film.PosterURL
            };
        }
    }

    /// <summary>
    /// Модель представление для детального представления информации о фильме
    /// </summary>
    public class FilmDetailsViewModel
    {
        public int FilmId { get; set; }
        [Display(Name = "Название фильма")]

        public string FilmName { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Изображение")]
        public string PosterURL { get; set; }

        [Display(Name = "Продюссер")]
        public string Director { get; set; }

        [Display(Name = "Год")]
        public int Year { get; set; }

        [Display(Name = "Email автора")]
        public string CreatorEmail { get; set; }

        [DefaultValue(false)]
        public bool CanEdit { get; set; }

        public static FilmDetailsViewModel Create(Film film)
        {
            return new FilmDetailsViewModel
            {
                FilmId = film.Id,
                FilmName = film.Name,
                Description = film.Descrition,
                PosterURL = film.PosterURL,
                CreatorEmail = film.Creator != null ? film.Creator.Email : "",
                Year = film.Year,
                Director = film.Director
            };
        }
    }


    /// <summary>
    /// Модель представление для списка фильмов
    /// </summary>
    public class FilmsListViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}