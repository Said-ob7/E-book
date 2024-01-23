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
                // Handle case where the book is not found
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

            // Fetch the Genre information
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
                // Handle the case where the chapter is not found or not associated with the given book
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
        public List<LivreViewModel> GetBooksByGenre(int genreId)
        {
            LivreRepos livreRepos = new LivreRepos();

            // Assuming you have a method in LivreRepos to get books by genre
            var booksByGenre = livreRepos.GetBooksByGenre(genreId);

            var bookViewModels = booksByGenre.Select(bookEntity => new LivreViewModel
            {
                LivreId = bookEntity.LivreId,
                Titre = bookEntity.Titre,
                Description = bookEntity.Description,
                Couverture = bookEntity.Couverture,
                // Add other properties as needed
            }).ToList();

            return bookViewModels;
        }
        
    }
}
