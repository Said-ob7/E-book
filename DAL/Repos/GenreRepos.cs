using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Repos
{
    public class GenreRepos
    {
        public void Create(DAL.Entity.Genre entity)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                mydb.Genres.Add(entity);
                mydb.SaveChanges();
            }
        }
        public DAL.Entity.Genre Read(int id)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                return mydb.Genres.Find(id);
            }
        }
        public List<DAL.Entity.Genre> ReadAll()
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                return mydb.Genres.ToList();
            }
        }
        public void Update(DAL.Entity.Genre entity)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                mydb.Genres.Update(entity);
                mydb.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (MyDbContext mydb = new MyDbContext())
            {
                DAL.Entity.Genre entity = mydb.Genres.Find(id);
                if (entity != null)
                {
                    mydb.Genres.Remove(entity);
                    mydb.SaveChanges();
                }
            }
        }
        
    }
}
