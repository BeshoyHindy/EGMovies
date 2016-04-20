using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGMovies.BOL;
using System.Data.Entity.Infrastructure;

namespace EGMovies.DAL
{
    public class ShowRepository
    {
        private EGMoviesWorkshopDB _Db { get; set; }
        public Show _obj { get; set; }
        public ShowRepository()
        {
            _Db = new EGMoviesWorkshopDB();
            _obj = new Show();
            
        }

        public String AddNew()
        {
            try
            {
                // _Db = new EGMoviesWorkshopDB();

                _Db.Shows.Add(_obj);
                //dbCtx.Entry(stud).State = System.Data.Entity.EntityState.Modified;
                _Db.Entry(_obj).State = System.Data.Entity.EntityState.Added;
                _Db.SaveChanges();
                return _obj.Id.ToString();
            }
            catch (Exception)
            {


            }
            return _obj.Id.ToString();

        }

        public int AddNew(Show obj)
        {
            _Db.Shows.Add(obj);
            _Db.Entry(obj).State = System.Data.Entity.EntityState.Added;
            // _Db.SaveChanges();
            return obj.Id;
        }
        public void DBSave()
        {
            _Db.SaveChanges();
        }

        public List<Show> GitAll()
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Shows.ToList();
        }
       
        public Movie GitMovieByCinemaId(int CinemaId)
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Shows.FirstOrDefault(sh => sh.CinemaId == CinemaId).Movie;
        }

    }
}
