using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGMovies.BOL;

namespace EGMovies.DAL
{
    public class ActorRepository
    {
        private EGMoviesWorkshopDB _Db { get; set; }
        public Actor _obj { get; set; }
        public ActorRepository()
        {
            _Db = new EGMoviesWorkshopDB();
            _obj = new Actor();
        }

        public String AddNew()
        {
           // _Db = new EGMoviesWorkshopDB();

            _Db.Actors.Add(_obj);
            _Db.Entry(_obj).State = System.Data.Entity.EntityState.Added;
            _Db.SaveChanges();
            return _obj.Id.ToString();
        }

        public Actor FindActorByName(string ActorName)
        {

            _Db = new EGMoviesWorkshopDB();
            return _Db.Actors.FirstOrDefault(actr => actr.Name.Equals(ActorName));
        }

        public List<Actor> GitAll()
        {
            _Db = new EGMoviesWorkshopDB();

            return _Db.Actors.ToList();
        } 

    }
}
