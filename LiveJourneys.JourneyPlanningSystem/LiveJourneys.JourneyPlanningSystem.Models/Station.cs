using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("Station")]
    public partial class Station:IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Station()
        {
            StationLines = new HashSet<StationLine>();
            StationMappings = new HashSet<StationMapping>();
            StationMappings1 = new HashSet<StationMapping>();
        }

        [Column("StationId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be null or empty", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Station name should be blow 50 characters")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationLine> StationLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationMapping> StationMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationMapping> StationMappings1 { get; set; }
    }
}
