using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("StationMapping")]
    public partial class StationMapping
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FromStaionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ToStationId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LineId { get; set; }

        public double Distance { get; set; }

        public bool? isDeleay { get; set; }

        public virtual Line Line { get; set; }

        public virtual Station Station { get; set; }

        public virtual Station Station1 { get; set; }
    }
}
