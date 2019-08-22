using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Data.Models.Repositories
{
    public class FilmsRepository: IDisposable, IFilmsRepository
    {
        private ApplicationDbContext db;
        public FilmsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Film Get(int id)
        {
            return db.Films.Include(f => f.Creator).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Film> List()
        {
            return db.Films;    
        }

        public void Save(Film film)
        {
            if (film.Id == 0)
            {
                db.Films.Add(film);
            }
            else
            {
                var old = Get(film.Id);
                old.Update(film);
            }
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}