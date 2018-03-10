using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("User")]
    public partial class User:IEntity
    {
        [Column("UserId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int TypeId { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
