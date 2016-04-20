using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EGMovies.BOL;


namespace EGMovies.WebUI.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public List<Actor>  Actors { get; set; }
        public List<Show> Shows { get; set; }
        public List<Cinema>  Cinemas { get; set; }

    }
}