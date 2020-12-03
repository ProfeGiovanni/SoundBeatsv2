using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SoundBeatsV2.Core.Domain
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
