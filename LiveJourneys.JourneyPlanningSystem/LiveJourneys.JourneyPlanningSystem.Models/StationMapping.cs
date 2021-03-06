using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("StationMapping")]
    public partial class StationMapping:IEntity
    {
        [NotMapped]
        public int Id { get; set; }

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

        public bool? IsDeleay { get; set; }

        public virtual Line Line { get; set; }

        public virtual Station FromStation { get; set; }

        public virtual Station ToStation { get; set; }
    }
}
