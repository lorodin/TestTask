using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Models.Repositories
{
    public interface IFilmsRepository
    {
        void Save(Film film);
        Film Get(int id);
        IEnumerable<Film> List();
    }
}
