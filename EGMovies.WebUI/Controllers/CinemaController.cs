using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGMovies.DAL;
using EGMovies.BOL;
using EGMovies.WebUI.ViewModels;

namespace EGMovies.WebUI.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
       
        public ActionResult Index(string id)
        {
            int CinemaGroupId = 0;
            CinemaGroupRepository repoCinemaGroup = new CinemaGroupRepository();

            ViewBag.id = new SelectList(repoCinemaGroup.GitAll(), "Id", "Name");
            CinemaRepository repoCinema = new CinemaRepository();

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(id, out CinemaGroupId);
            }
            else
            {
                int.TryParse(id, out CinemaGroupId);

            }

            if (CinemaGroupId >0 )
            {
                return View(repoCinema.GitCinemasByCinemaGroup(CinemaGroupId));
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

            CinemaDetailsViewModel cinemaDetailsViewModel  = new CinemaDetailsViewModel
            {
                Cinema = cinema ,
                CinemaGroup = cinemaGroup ,
                Shows =shows
            };

            return View(cinemaDetailsViewModel);
        }
    }
}