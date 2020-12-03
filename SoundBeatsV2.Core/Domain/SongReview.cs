using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeatsV2.Core.Domain
{

    [Table("SongReview")]
    public class SongReview
    {

        public int Id { get; set; }

        [Display(Name = "Calificación")]
        public int Ranking { get; set; }

        [StringLength(500)]
        [Display(Name = "Comentario")]
        public string Comment { get; set; }


        public int SongId { get; set; }

        [Display(Name = "Canción")]
        public Song Song { get; set; }

        public int ReviewerProfileId { get; set; }

        [Display(Name = "Reseñador")]
        public ReviewerProfile Artist { get; set; }

    }
}
