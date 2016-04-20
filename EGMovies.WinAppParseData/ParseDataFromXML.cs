using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using EGMovies.BOL;
using EGMovies.DAL;

namespace EGMovies.WinAppParseData
{
    public partial class ParseDataFromXML : Form
    {
        public String FilePath { get; set; }
        public FileInfo _FileInfo { get; set; }


        public CinemaGroupRepository RepoCinmaGroup { get; set; }
        public CinemaGroup ObjCinemaGroup { get; set; }

        public CinemaRepository RepoCinema { get; set; }
        public Cinema ObjCinema { get; set; }

        public ShowRepository RepoShow { get; set; }
        public Show ObjShow { get; set; }

        public MovieRepository RepoMovie { get; set; }
        public Movie ObjMovie { get; set; }

        public ActorRepository RepoActor { get; set; }
        public Actor ObjActor { get; set; }



        public ParseDataFromXML()
        {

            FilePath = AppDomain.CurrentDomain.BaseDirectory + @"DataFile\Data.xml";
            _FileInfo = new FileInfo(FilePath);

            //RepoCinmaGroup = new CinemaGroupRepository();
            //RepoCinema = new CinemaRepository();
            //RepoShow = new ShowRepository();
            //RepoMovie = new MovieRepository();
            //RepoActor = new ActorRepository();


            InitializeComponent();
        }

        private void btnGenerateData_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            var rootxDoc = XDocument.Load(FilePath);

            int cinmagroupIndex = 0;
            int cinmaIndex = 0;
            int showIndex = 0;
            int movieIndex = 0;
            int movieIndexFounded = 0;
            int actorIndex = 0;

            #region rgnCinemaGroup

            //add CinemaGroups
            foreach (var cinmagroup in rootxDoc.Descendants().Where(cg => cg.Name.LocalName.Equals("CinemaGroup")))
            {

                cinmagroupIndex++;
                ObjCinemaGroup = new CinemaGroup();

                ObjCinemaGroup.Id = cinmagroupIndex;
                ObjCinemaGroup.Name = cinmagroup.Attribute("Name").Value;
                ObjCinemaGroup.City = cinmagroup.Element("City")?.Value;
                ObjCinemaGroup.Area = cinmagroup.Element("Area")?.Value;
                ObjCinemaGroup.Address = cinmagroup.Element("Address")?.Value;
                ObjCinemaGroup.Telephone = cinmagroup.Element("Telephone")?.Value;
                ObjCinemaGroup.Description = cinmagroup.Element("Description")?.Value;
                //RepoCinmaGroup.AddNew();
                //MessageBox.Show(AddCinemaGroup(ObjCinemaGroup));
                AddCinemaGroup(ObjCinemaGroup);


                #region rgnCinema
                //add Cinemas
                foreach (var cinma in cinmagroup.Descendants().Where(cg => cg.Name.LocalName.Equals("Cinema")))
                {

                    cinmaIndex++;
                    ObjCinema = new Cinema();


                    ObjCinema.Id = cinmaIndex;
                    ObjCinema.Name = cinma.Attribute("Name").Value;
                    ObjCinema.CinemaGroupId = cinmagroupIndex;
                    // ObjCinema.CinemaGroup = ObjCinemaGroup;
                    //RepoCinema.AddNew();
                    //MessageBox.Show(AddCinema(ObjCinema));
                    AddCinema(ObjCinema);

                    #region rgnMovie

                    // add Shows
                    foreach (var shw in cinma.Descendants().Where(cg => cg.Name.LocalName.Equals("Show")))
                    {
                        showIndex++;
                        ObjShow = new Show();

                        // add movies
                        foreach (var mov in shw.Descendants().Where(cg => cg.Name.LocalName.Equals("Movie")))
                        {
                            movieIndex++;
                            ObjMovie = new Movie();
                            RepoMovie = new MovieRepository();

                            if (!RepoMovie.GitIDByName(mov.Attribute("Name").Value.ToString(), out movieIndexFounded))
                            {
                                //add new movie
                                ObjMovie.Id = movieIndex;
                                ObjMovie.Name = mov.Attribute("Name").Value.Trim();
                                ObjMovie.Genre = mov.Element("Genre")?.Value;
                                ObjMovie.ShowingDate = DateTime.ParseExact(mov.Element("ShowingDate")?.Value.ToString(),
                                    "dd/MM/yyyy", null);
                                ObjMovie.Description = mov.Element("Description")?.Value;

                                // MessageBox.Show(AddMovie(ObjMovie));
                                //AddMovie(ObjMovie);

                                List<Actor> listActors = new List<Actor>();
                                foreach (var actor in mov.Descendants().Where(cg => cg.Name.LocalName.Equals("Actor")))
                                {
                                    actorIndex++;
                                    ObjActor = new Actor();

                                    ObjActor.Id = actorIndex;
                                    ObjActor.Name = actor.Attribute("Name").Value.Trim();
                                    ObjActor.Role = actor.Attribute("Role").Value.Trim();
                                    listActors.Add(ObjActor);
                                }

                                ObjMovie.Actors = listActors;
                                AddMovie(ObjMovie);
                                listActors = null;

                            }



                        }



                        #region rgnShow

                        ObjShow.Id = showIndex;
                        ObjShow.ShowFrom = shw.Attribute("From").Value;
                        ObjShow.ShowTo = shw.Attribute("To").Value;
                        ObjShow.CinemaId = cinmaIndex;
                        if (movieIndexFounded == 0)
                        {
                            ObjShow.MovieId = movieIndex;
                        }
                        else
                        {
                            ObjShow.MovieId = movieIndexFounded;
                            movieIndexFounded = 0;
                            movieIndex--;
                        }
                        //MessageBox.Show(AddShow(ObjShow));
                        AddShow(ObjShow);


                        #endregion


                        #endregion
                    }


                    #endregion
                }
            }
            #endregion

            MessageBox.Show("All Data Saved Succefully");


        }

        private void ParseDataFromXML_Load(object sender, EventArgs e)
        {

            if (!_FileInfo.Exists)
            {
                MessageBox.Show("Data File XML Not Found");
            }
            else
            {
                lblDataFilePath.Text = FilePath;
            }
        }


        private String AddCinemaGroup(CinemaGroup cinemaGroup)
        {
            RepoCinmaGroup = new CinemaGroupRepository();
            RepoCinmaGroup.AddNew(cinemaGroup);
            RepoCinmaGroup.DBSave();

            return cinemaGroup.Name + " , - id : " + cinemaGroup.Id;
        }

        private String AddCinema(Cinema cinema)
        {
            RepoCinema = new CinemaRepository();
            RepoCinema.AddNew(cinema);
            RepoCinema.DBSave();
            return cinema.Name + " , - id : " + cinema.Id + " - Cinemagroup id : " + cinema.CinemaGroupId;
        }

        private String AddMovie(Movie movie)
        {
            RepoMovie = new MovieRepository();
            RepoMovie.AddNew(movie);
            RepoMovie.DBSave();
            return movie.Name + " , - id : " + movie.Id;
        }

        private String AddShow(Show show)
        {
            RepoShow = new ShowRepository();
            RepoShow.AddNew(show);
            RepoShow.DBSave();
            return "movie id : " + show.MovieId + " , - Cinema id : " + show.CinemaId;
        }

    }
}
