using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Genre
    {
        public class GenreViewModel
        {
            public int GenreId { get; set; }
            public string Nom { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;

            // Correct the property name to match the navigation property in your entity
            public ICollection<LivreViewModel> Livres { get; set; }
            
        }
    }
}
