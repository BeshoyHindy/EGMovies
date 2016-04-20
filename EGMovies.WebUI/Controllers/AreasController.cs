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
    public class AreasController : Controller
    {
        // GET: Areas
        public ActionResult Index(string id)
        {
            CinemaGroupRepository repoCinemaGroup = new CinemaGroupRepository();

            ViewBag.id = new SelectList(repoCinemaGroup.GitAreas());



            CinemaRepository repoCinema = new CinemaRepository();

            if (!string.IsNullOrEmpty(id))
            {
                return View(repoCinema.GitCinemasByAreaName(id));
            }
            else
            {
                return View(repoCinema.GitAll());
            }

        }


        public ActionResult Details(int id)
        {
            CinemaRepository repoCinema = new CinemaRepository();
            Cinema cinema = repoCinema.GitCinemaByCinemaId(id);
            CinemaGroup cinemaGroup = repoCinema.GitCinemaGroupByCinemaId(id);
            List<Show> shows = repoCinema.GitShowsByCinemaId(id);

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel
            {
                Cinema = cinema,
                CinemaGroup = cinemaGroup,
                Shows = shows
            };

            return View(cinemaDetailsViewModel);
        }


    }
}