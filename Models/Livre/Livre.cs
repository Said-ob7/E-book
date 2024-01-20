using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class LivreViewModel
	{
		public int LivreId { get; set; }
		public string Titre { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Couverture { get; set; } = string.Empty;

		// Correct the property name to match the navigation property in your entity
		public ICollection<AvisViewModel> Avis { get; set; }
		public ICollection<ChapitreViewModel> Chapitres { get; set; }  // Correct the property name
	}
}



