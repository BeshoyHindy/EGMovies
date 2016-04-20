namespace EGMovies.BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Show")]
    public partial class Show
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string ShowFrom { get; set; }

        [StringLength(10)]
        public string ShowTo { get; set; }

        public int? MovieId { get; set; }

        public int? CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
