using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class ChapitreViewModel
	{
		public int ChapitreId { get; set; }
		public int LivreId { get; set; }
		public string Titre { get; set; } = string.Empty;
		public string Contenu { get; set; } = string.Empty;
		// Autres propriétés nécessaires

		// Relation avec le Livre
		public LivreViewModel Livre { get; set; }
	}
}
