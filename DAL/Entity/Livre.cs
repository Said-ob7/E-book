using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    [Table("T_Livre", Schema = "dbo")]
    public class Livre
    {
        [Key]
        public int LivreId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Titre { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Couverture { get; set; } = string.Empty;
        public ICollection<Chapitre> Chapitres { get; set; }  // Ensure the property name is Chapitres

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}
