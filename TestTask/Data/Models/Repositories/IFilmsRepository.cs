using System.Collections.Generic;

namespace TestTask.Data.Models.Repositories
{
    public interface IFilmsRepository
    {
        void Save(Film film);
        Film Get(int id);
        IEnumerable<Film> List();
    }
}
