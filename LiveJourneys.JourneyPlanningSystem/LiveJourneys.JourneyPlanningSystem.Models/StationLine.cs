using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("StationLine")]
    public partial class StationLine:IEntity
    {
        [NotMapped]
        public int Id { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Line should be selected", AllowEmptyStrings = false)]
        public int LineId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Station should be selected", AllowEmptyStrings = false)]
        public int StationId { get; set; }

        public int OrderNumber { get; set; }

        public virtual Line Line { get; set; }

        public virtual Station Station { get; set; }
    }
}
