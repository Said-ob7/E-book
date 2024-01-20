using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Livre
{
    public class LivreDetailsVM
    {
        public int LivreId { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Couverture { get; set; } = string.Empty;

        // Other properties you may want to include

        // Relation with the chapters
        public List<ChapitreViewModel> Chapitres { get; set; }  
    }
}
