using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask.Data.Models.Repositories
{
    public class FakeFilmsRepository : IFilmsRepository
    {
        private List<Film> films = new List<Film>();
        private Random rnd = new Random();

        public FakeFilmsRepository()
        {
            string[] filmNames = new string[] { "Avatar", "Matrica", "Matrica2", "Matrica3", "Ragnorok", "Interstellar", "New film" };
            string[] description = new string[] { "Short description", "Lorem Ipsum - это текст-'рыба', часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной 'рыбой' для текстов на латинице с начала XVI века.", "Description 1", "Description 2", "Description 3" };
            string[] directors = new string[] { "Ivanov", "Sidorov", "Vasilev", "Ostafiev"};
            for (int i = 0; i < 13; i++)
            {
                films.Add(new Film
                {
                    Id = i + 1,
                    CreatorId = rnd.Next(1, 10).ToString(),
                    PosterURL = FakeImageURL(),
                    Name = filmNames[rnd.Next(0, filmNames.Length - 1)],
                    Director = directors[rnd.Next(0, directors.Length - 1)],
                    Year = rnd.Next(1995, 2019),
                    Descrition = description[rnd.Next(0, description.Length - 1)]
                });
            }
        }

        private string FakeImageURL()
        {
            return string.Format("https://picsum.photos/id/{0}/200/300", rnd.Next(200, 250));
        }

        public Film Get(int id)
        {
            return films.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Film> List()
        {
            return films;
        }

        public void Save(Film film)
        {
            if (film.Id == 0)
            {
                int maxId = films.Max(f => f.Id);
                film.Id = maxId + 1;
                films.Add(film);
            } else {
                var oldFilm = Get(film.Id);
                oldFilm.Director = film.Director;
                oldFilm.Descrition = film.Descrition;
                oldFilm.CreatorId = film.CreatorId;
                oldFilm.Name = film.Name;
                oldFilm.PosterURL = film.PosterURL;
                oldFilm.Year = film.Year;
            }
        }
    }
}