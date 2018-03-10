using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveJourneys.JourneyPlanningSystem.Models
{

    [Table("UserType")]
    public partial class UserType:IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserType()
        {
            Users = new HashSet<User>();
        }

        [Column("UserTypeId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
