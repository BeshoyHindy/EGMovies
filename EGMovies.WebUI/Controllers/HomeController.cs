using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGMovies.BOL;
using EGMovies.DAL;
using EGMovies.WebUI.ViewModels;


namespace EGMovies.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
            MovieRepository repoMovie = new MovieRepository();
            if (!string.IsNullOrEmpty(id))
            {
                return View(repoMovie.SearchByMovieName(id));
            }
            else
            {
                return View(repoMovie.GitAll());

            }
        }

        public ActionResult Details(int id)
        {
            MovieRepository repoMovie = new MovieRepository();
            Movie movie = repoMovie.GitMovieByMovieId(id);
            List<Actor> actors = repoMovie.GitActorsByMovieId(id);
            List<Show> shows = repoMovie.GitShowsByMovieId(id);
            List<Cinema> cinemas = repoMovie.GitCinemasByMovieId(id);

            MovieDetailsViewModel movieDetailsViewModel = new MovieDetailsViewModel
            {
                Movie = movie,
                Actors = actors,
                Shows = shows,
                Cinemas = cinemas
            };

            return View(movieDetailsViewModel);

        }

        public ActionResult ByMovieGenre(string moviegenre)
        {
            MovieRepository repoMovie = new MovieRepository();


            ViewBag.movieGenre = new SelectList(repoMovie.GitGenres());
            repoMovie = new MovieRepository();

            if (!string.IsNullOrEmpty(moviegenre))
            {
                return View(repoMovie.GitMoviesByGenre(moviegenre));
            }
            else
            {
                return View(repoMovie.GitAll());

            }
            
        }

    }
}