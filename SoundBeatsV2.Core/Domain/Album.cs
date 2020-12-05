using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeatsV2.Core.Domain
{
    [Table("Albums")]
    public class Album
    {
        public int Id { get; set; }


        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Año")]
        public int Year { get; set; }


        [Display(Name = "Imagen de Portada")]
        public byte[] PhotoCover { get; set; }
        public string ImageType { get; set; }

        public int ArtistId { get; set; }

        [Display(Name = "Artista")]
        public  Artist Artist { get; set; }

        public ICollection<Song> Song { get; set;  }

    }
}
