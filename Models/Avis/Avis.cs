using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class AvisViewModel
	{
		public int AvisId { get; set; }
		public int LivreId { get; set; }
		public string Commentaire { get; set; } = string.Empty;
		public int Note { get; set; }
		// Autres propriétés nécessaires

		// Relation avec le Livre
		public LivreViewModel Livre { get; set; }
	}
}
