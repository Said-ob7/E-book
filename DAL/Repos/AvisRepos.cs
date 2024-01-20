using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
	public class AvisRepos
	{
		public void Create(Avis entity)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				mydb.Aviss.Add(entity);
				mydb.SaveChanges();
			}
		}

		public List<Avis> ReadAllByLivreId(int livreId)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				return mydb.Aviss.Where(a => a.LivreId == livreId).ToList();
			}
		}

		public void Update(Avis entity)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				mydb.Aviss.Update(entity);
				mydb.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				Avis entity = mydb.Aviss.Find(id);
				if (entity != null)
				{
					mydb.Aviss.Remove(entity);
					mydb.SaveChanges();
				}
			}
		}
	}
}
