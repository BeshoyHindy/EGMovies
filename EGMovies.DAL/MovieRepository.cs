using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGMovies.BOL;

namespace EGMovies.DAL
{
    public class MovieRepository
    {
        private EGMoviesWorkshopDB _Db { get; set; }
        public Movie _obj { get; set; }

        public MovieRepository()
        {
            _Db = new EGMoviesWorkshopDB();
            _obj = new Movie();
        }

        public String AddNew()
        {
            // _Db = new EGMoviesWorkshopDB();

            _Db.Movies.Add(_obj);
            _Db.Entry(_obj).State = System.Data.Entity.EntityState.Added;

            _Db.SaveChanges();
            return _obj.Id.ToString();
        }

        public int AddNew(Movie obj)
        {
            _Db.Movies.Add(obj);
            _Db.Entry(obj).State = System.Data.Entity.EntityState.Added;
            // _Db.SaveChanges();
            return obj.Id;
        }

        public void DBSave()
        {
            _Db.SaveChanges();
        }

        public Movie FindMovieByName(string MovieName)
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Movies.FirstOrDefault(mov => mov.Name.Equals(MovieName));
        }

        public bool GitIDByName(string MovieName, out int ID)
        {
            _Db = new EGMoviesWorkshopDB();
            Movie intMovie = new Movie();

            intMovie = _Db.Movies.FirstOrDefault(mov => mov.Name.Equals(MovieName));
            if (intMovie != null)
            {
                ID = intMovie.Id;
                return true;
            }
            else
            {
                ID = 0;
                return false;
            }
        }

        public List<Movie> GitAll()
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Movies.ToList();
        }

        public List<Movie> SearchByMovieName(String MovieName)
        {
            _Db = new EGMoviesWorkshopDB();
            //if (string.IsNullOrEmpty(MovieName))
            //{
            //    return _Db.Movies.ToList();
            //}
            //else
            //{
            return _Db.Movies.Where(mov => mov.Name.Contains(MovieName)).ToList();

            //}
        }

        public Movie GitMovieByMovieId(int MovieId)
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Movies.SingleOrDefault(mov => mov.Id == (MovieId));

        }

        public List<Actor> GitActorsByMovieId(int MovieId)
        {
            _Db = new EGMoviesWorkshopDB();

            Movie movie = new Movie();
            movie = _Db.Movies.FirstOrDefault(m => m.Id == MovieId);
            return movie.Actors.ToList();

        }

        public List<Show> GitShowsByMovieId(int MovieId)
        {
            _Db = new EGMoviesWorkshopDB();

            Movie movie = new Movie();
            movie = _Db.Movies.FirstOrDefault(m => m.Id == MovieId);
            return movie.Shows.ToList();

        }


        public List<Cinema> GitCinemasByMovieId(int MovieId)
        {
            _Db = new EGMoviesWorkshopDB();

            Movie movie = new Movie();
            movie = _Db.Movies.FirstOrDefault(m => m.Id == MovieId);
            var q = from c in movie.Shows.Where(s => s.MovieId == MovieId)
                    select c.Cinema;
            return q.Distinct().ToList();
        }


        public List<string> GitGenres()
        {
            _Db = new EGMoviesWorkshopDB();
            var GenreList = new List<string>();

            var Quary = from gen in _Db.Movies
                        orderby gen.Genre
                        select gen.Genre;
            GenreList.AddRange(Quary.Distinct());
            return GenreList;

        }

        public List<Movie> GitMoviesByGenre(string Genrename)
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Movies.Where(mov => mov.Genre.Contains(Genrename)).ToList();
        }

       




    }
}

