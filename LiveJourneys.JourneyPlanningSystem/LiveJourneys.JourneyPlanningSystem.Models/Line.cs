using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("Line")]
    public partial class Line:IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Line()
        {
            StationLines = new HashSet<StationLine>();
            StationMappings = new HashSet<StationMapping>();
        }

        [Column("LineId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be null or empty", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationLine> StationLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationMapping> StationMappings { get; set; }
    }
}
