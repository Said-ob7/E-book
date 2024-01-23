using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    [Table("T_Genre", Schema = "dbo")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nom { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        // Remove the foreign key attribute from Livres collection
        public ICollection<Livre> Livres { get; set; }
    }
}
