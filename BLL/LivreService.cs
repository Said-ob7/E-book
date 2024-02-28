using DAL.Entity;
using DAL.Repos;
using Models;
using Models.Livre;
using System.Collections.Generic;
using static Models.Genre;

namespace BLL
{
    public class LivreService
    {
        public List<LivreViewModel> ListAllBooks()
        {
            var list = new List<LivreViewModel>();

            LivreRepos repos = new LivreRepos();

            foreach (var item in repos.ReadAll())
            {
                LivreViewModel obj = new LivreViewModel()
                {
                    Description = item.Description,
                    LivreId = item.LivreId,
                    Titre = item.Titre,
                    Couverture = item.Couverture
                };

                list.Add(obj);
            }

            return list;
        }
        public LivreDetailsVM GetBookDetails(int livreId)
        {
            LivreRepos livreRepos = new LivreRepos();
            ChapitreRepos chapitreRepos = new ChapitreRepos();
            GenreRepos genreRepos = new GenreRepos();

            Livre livreEntity = livreRepos.Read(livreId);

            if (livreEntity == null)
            {
                return null;
            }

            List<ChapitreViewModel> chapitres = new List<ChapitreViewModel>();

            foreach (var chapitreEntity in chapitreRepos.ReadAllByLivreId(livreId))
            {
                ChapitreViewModel chapitreViewModel = new ChapitreViewModel()
                {
                    ChapitreId = chapitreEntity.ChapitreId,
                    Titre = chapitreEntity.Titre,
                    Contenu = chapitreEntity.Contenu,
                    LivreId = chapitreEntity.LivreId
                };

                chapitres.Add(chapitreViewModel);
            }

            DAL.Entity.Genre genreEntity = genreRepos.Read(livreEntity.GenreId);

            GenreViewModel genreViewModel = new GenreViewModel
            {
                GenreId = genreEntity.GenreId,
                Nom = genreEntity.Nom,
                Description = genreEntity.Description,
            };

            LivreDetailsVM bookDetailsViewModel = new LivreDetailsVM()
            {
                LivreId = livreEntity.LivreId,
                Titre = livreEntity.Titre,
                Description = livreEntity.Description,
                Couverture = livreEntity.Couverture,
                Chapitres = chapitres,
                Genre = genreViewModel
            };

            return bookDetailsViewModel;
        }

        public ChapitreViewModel GetChapterDetails(int livreId, int chapitreId)
        {
            ChapitreRepos chapitreRepos = new ChapitreRepos();
            var chapitreEntity = chapitreRepos.Read(chapitreId);

            if (chapitreEntity == null || chapitreEntity.LivreId != livreId)
            {
                return null;
            }

            var chapitreViewModel = new ChapitreViewModel
            {
                ChapitreId = chapitreEntity.ChapitreId,
                LivreId = chapitreEntity.LivreId,
                Titre = chapitreEntity.Titre,
                Contenu = chapitreEntity.Contenu
            };

            return chapitreViewModel;
        }
        
        
    }
}
