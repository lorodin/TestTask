using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TestTask.Data.Models;
using TestTask.Data.Models.Repositories;
using TestTask.Models;
using TestTask.Util;

namespace TestTask.Controllers
{
    public class FilmController : Controller
    {
        private IFilmsRepository filmsRepository;
        private IFilesManager filesManager; 
        public FilmController(IFilmsRepository filmsRepository, IFilesManager filesManager)
        {
            this.filmsRepository = filmsRepository;
            this.filesManager = filesManager;
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return View("Error");
            }

            var film = filmsRepository.Get(id.Value);

            if (film == null)
            {
                return View("Error");
            }

            var detailsModel = FilmDetailsViewModel.Create(film);
            detailsModel.CanEdit = User.Identity.IsAuthenticated && film.CreatorId == User.Identity.GetUserId();

            return View(detailsModel);
        }

        public ActionResult List(int page = 1)
        {
            var pageInfo = new PageInfoViewModel
            {
                PageNumber = page,
                TotalItems = filmsRepository.List().Count()
            };

            var films = filmsRepository.List().Skip((pageInfo.PageNumber - 1) * pageInfo.PageSize)
                                              .Take(pageInfo.PageSize);

            return View(new FilmsListViewModel
            {
                Films = films,
                PageInfo = pageInfo
            });
        }

        [Authorize]
        public ActionResult Create(int id = 0)
        {
            CreateFilmViewModel model;

            if (id != 0)
            {
                var film = filmsRepository.Get(id);

                if (film == null)
                {
                    return View("Error");
                }

                if (film.CreatorId != User.Identity.GetUserId())
                {
                    return View("Error");
                }

                model = CreateFilmViewModel.Create(film);
            }
            else
            {
                model = new CreateFilmViewModel();
            }
            

            return View(model);
        }

        [ValidateInput(false)]
        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateFilmViewModel filmViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(filmViewModel);
            }
            
            Film film = new Film();

            
            if (filmViewModel.Id == 0)
            {
                film.CreatorId = User.Identity.GetUserId();
            } else
            {
                film.Id = filmViewModel.Id;
            }

            if (filmViewModel.PosterFile != null)
            {
                filesManager.Delete(filmViewModel.PosterURL);
                film.PosterURL = filesManager.SavePostFile(filmViewModel.PosterFile);
            }
            else
            {
                if (filmViewModel.DeletePoster)
                {
                    filesManager.Delete(filmViewModel.PosterURL);
                }
                else
                {
                    film.PosterURL = null;
                }
            }

            film.Name = HtmlUtils.ClearHtml(filmViewModel.Name);
            film.Director = HtmlUtils.ClearHtml(filmViewModel.Director);
            film.Descrition = HtmlUtils.ClearHtml(filmViewModel.Description);
            film.Year = filmViewModel.Year;

            filmsRepository.Save(film);

            return RedirectToAction("Details", new { id = film.Id });
        }
    }
}