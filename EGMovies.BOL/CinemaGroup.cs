namespace EGMovies.BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CinemaGroup")]
    public partial class CinemaGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CinemaGroup()
        {
            Cinemas = new HashSet<Cinema>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
