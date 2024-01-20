using DAL.Entity;
using DAL.Repos;
using Models;
using System.Collections.Generic;

namespace BLL
{
	public class AvisService
	{
		public List<AvisViewModel> GetAvisByLivreId(int livreId)
		{
			var list = new List<AvisViewModel>();

			AvisRepos repos = new AvisRepos();

			var avisList = repos.ReadAllByLivreId(livreId);

			foreach (var item in avisList)
			{
				AvisViewModel obj = new AvisViewModel()
				{
					AvisId = item.AvisId,
					LivreId = item.LivreId,
					Commentaire = item.Commentaire,
					Note = item.Note
				};
				list.Add(obj);
			}

			return list;
		}
	}
}
