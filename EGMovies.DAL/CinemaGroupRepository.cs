using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGMovies.BOL;

namespace EGMovies.DAL
{
    public class CinemaGroupRepository
    {
        private EGMoviesWorkshopDB _Db { get; set; }
        public CinemaGroup _obj { get; set; }
        public CinemaGroupRepository()
        {
            _Db = new EGMoviesWorkshopDB();
            _obj = new CinemaGroup();
        }

        public String AddNew()
        {
            //_Db = new EGMoviesWorkshopDB();

            _Db.CinemaGroups.Add(_obj);
            _Db.Entry(_obj).State = System.Data.Entity.EntityState.Added;

            _Db.SaveChanges();
            //_Db.CinemaGroups
            return _obj.Id.ToString();
        }


        public int AddNew(CinemaGroup obj)
        {

           _Db = new EGMoviesWorkshopDB();

            _Db.CinemaGroups.Add(obj);
            _Db.Entry(obj).State = System.Data.Entity.EntityState.Added;
            _Db.SaveChanges();
            return obj.Id;
        }

        public void DBSave()
        {
            _Db.SaveChanges();
        }


        public List<CinemaGroup> GitAll()
        {
            _Db = new EGMoviesWorkshopDB();
            return _Db.CinemaGroups.ToList();
        }


        public List<string> GitAreas()
        {
            _Db = new EGMoviesWorkshopDB();
            var AreasList = new List<string>();

            var Quary = from ara in _Db.CinemaGroups
                        orderby ara.Area
                        select ara.Area;
            AreasList.AddRange(Quary.Distinct());
            return AreasList;

        }

    }
}
