using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
	[Table("T_Avis", Schema = "dbo")]
	public class Avis
	{
		[Key]
		public int AvisId { get; set; }

		public int LivreId { get; set; }

		[MaxLength(1000)]
		public string Commentaire { get; set; } = string.Empty;

		public int Note { get; set; }

		[ForeignKey("LivreId")]
		public Livre Livre { get; set; }
	}
}
