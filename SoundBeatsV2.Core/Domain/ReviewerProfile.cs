using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeatsV2.Core.Domain
{
    [Table("ReviewerProfile")]
    public class ReviewerProfile
    {
        public int Id { get; set; }


        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [StringLength(80)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        public ICollection<SongReview> SongReviews { get; set; }
    }
}
