using DAL.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Genre;

namespace BLL
{
    public class GenreService
    {
        public List<GenreViewModel> ListAllGenres()
        {
            var list = new List<GenreViewModel>();

            GenreRepos repos = new GenreRepos();

            foreach (var item in repos.ReadAll())
            {
                GenreViewModel obj = new GenreViewModel()
                {
                    Description = item.Description,
                    GenreId = item.GenreId,
                    Nom = item.Nom,
                };

                list.Add(obj);
            }

            return list;
        }
    }
}
