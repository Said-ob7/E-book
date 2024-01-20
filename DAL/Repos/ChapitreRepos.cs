using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Repos
{
	public class ChapitreRepos
	{
		public void Create(Chapitre entity)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				mydb.Chapitres.Add(entity);
				mydb.SaveChanges();
			}
		}

		public Chapitre Read(int id)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				return mydb.Chapitres.FirstOrDefault(c => c.ChapitreId == id);
			}
		}

		public List<Chapitre> ReadAllByLivreId(int livreId)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				return mydb.Chapitres.Where(c => c.LivreId == livreId).ToList();
			}
		}

		public void Update(Chapitre entity)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				mydb.Chapitres.Update(entity);
				mydb.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (MyDbContext mydb = new MyDbContext())
			{
				Chapitre entity = mydb.Chapitres.Find(id);
				if (entity != null)
				{
					mydb.Chapitres.Remove(entity);
					mydb.SaveChanges();
				}
			}
		}
	}
}
