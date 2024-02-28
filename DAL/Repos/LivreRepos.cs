using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Repos
{
    public class LivreRepos
    {
        public void Create(DAL.Entity.Livre entity)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                mydb.Livres.Add(entity);
                mydb.SaveChanges();
            }
        }

        public DAL.Entity.Livre Read(int id)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                return mydb.Livres.Find(id);
            }
        }

        public List<DAL.Entity.Livre> ReadAll()
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                return mydb.Livres.ToList();
            }
        }

        public void Update(DAL.Entity.Livre entity)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                mydb.Livres.Update(entity);
                mydb.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                DAL.Entity.Livre entity = mydb.Livres.Find(id);
                if (entity != null)
                {
                    mydb.Livres.Remove(entity);
                    mydb.SaveChanges();
                }
            }
        }
        
       
    }
}
