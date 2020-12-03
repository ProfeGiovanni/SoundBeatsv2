using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeatsV2.Core.Domain
{
    [Table("Song")]
    public class Song
    {
        public int Id { get; set; }

        [Display(Name = "N°")]
        public int TrackNumber { get; set; }

        [StringLength(80)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Duración [mm:ss]")]
        public decimal Length { get; set; }

        public int AlbumId { get; set; }
        [Display(Name = "Nombre del Album")]
        public virtual Album Album { get; set; }

        /* Relación 1 a 1*/
        public int GenreId { get; set; }
        [Display(Name = "Género")]
        public virtual Genre Genre { get; set; }

        public ICollection<SongReview> SongReviews { get; set; }
    }
}
