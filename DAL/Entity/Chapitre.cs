using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
	[Table("T_Chapitre", Schema = "dbo")]
	public class Chapitre
	{
		[Key]
		public int ChapitreId { get; set; }

		public int LivreId { get; set; }

		[MaxLength(200)]
		[Required]
		public string Titre { get; set; } = string.Empty;

		[MaxLength(400000)]
		public string Contenu { get; set; } = string.Empty;

		[ForeignKey("LivreId")]
		public Livre Livre { get; set; }
	}
}
