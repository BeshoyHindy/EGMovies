using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using EGMovies.BOL;

namespace EGMovies.WebUI.ViewModels
{
    public class CinemaDetailsViewModel
    {
        public Cinema Cinema { get; set; }
        public CinemaGroup  CinemaGroup { get; set; }
        public List<Show> Shows { get; set; }
        public List<Movie> Movies { get; set; }
      
            
    }
}