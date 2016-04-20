using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGMovies.BOL;

namespace EGMovies.DAL
{
    public class CinemaRepository
    {
        private EGMoviesWorkshopDB _Db { get; set; }
        public Cinema _obj { get; set; }
        public CinemaRepository()
        {
            _Db = new EGMoviesWorkshopDB();
            _obj = new Cinema();
        }

        public String AddNew()
        {
            //_Db = new EGMoviesWorkshopDB();
            _Db.Cinemas.Add(_obj);
            _Db.Entry(_obj).State = System.Data.Entity.EntityState.Added;

            // _Db.SaveChanges();
            return _obj.Id.ToString();
        }

        public int AddNew(Cinema obj)
        {

            _Db.Cinemas.Add(obj);
            _Db.Entry(obj).State = System.Data.Entity.EntityState.Added;
            // _Db.SaveChanges();
            return obj.Id;
        }

        public void DBSave()
        {
            _Db.SaveChanges();
        }


        public List<Cinema> GitAll()
        {
            _Db = new EGMoviesWorkshopDB();
            return _Db.Cinemas.ToList();
        }

        public List<Cinema> GitCinemasByCinemaGroup(int CinemaGroupId)
        {
            _Db = new EGMoviesWorkshopDB();
            return _Db.Cinemas.Where(c => c.CinemaGroupId == CinemaGroupId).ToList();
        }

        public CinemaGroup GitCinemaGroupByCinemaId(int CinemaId)
        {
            _Db = new EGMoviesWorkshopDB();
            return _Db.Cinemas.FirstOrDefault(c => c.Id == CinemaId).CinemaGroup;
        }
        public Cinema GitCinemaByCinemaId(int CinemaId)
        {
            _Db = new EGMoviesWorkshopDB();
            return _Db.Cinemas.FirstOrDefault(c => c.Id == CinemaId);
        }
        public List<Show> GitShowsByCinemaId(int cinemaId)
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Shows.Where(s => s.CinemaId == cinemaId).ToList();
        }


        public List<Cinema> GitCinemasByAreaName(string areaName)
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.CinemaGroups.FirstOrDefault(cg => cg.Area == areaName).Cinemas.ToList();
        }



    }
}
