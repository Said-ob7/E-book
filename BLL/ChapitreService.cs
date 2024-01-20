using DAL.Entity;
using DAL.Repos;
using Models;
using System.Collections.Generic;

namespace BLL
{
	public class ChapitreService
	{
		public List<ChapitreViewModel> GetChapitresByLivreId(int livreId)
		{
			var list = new List<ChapitreViewModel>();

			ChapitreRepos repos = new ChapitreRepos();

			var chapitres = repos.ReadAllByLivreId(livreId);

			foreach (var item in chapitres)
			{
				ChapitreViewModel obj = new ChapitreViewModel()
				{
					ChapitreId = item.ChapitreId,
					LivreId = item.LivreId,
					Titre = item.Titre,
					Contenu = item.Contenu
				};
				list.Add(obj);
			}

			return list;
		}
	}
}
