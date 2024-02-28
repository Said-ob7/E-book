using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class MyDbContext : DbContext
	{
		public DbSet<Avis> Aviss { get; set; }
		public DbSet<Chapitre> Chapitres { get; set; }
		public DbSet<Livre> Livres { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public MyDbContext() { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Update the connection string based on your database server 
			optionsBuilder.UseSqlServer(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=E-book;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Chapitre>()
			.HasOne(c => c.Livre)
			.WithMany(l => l.Chapitres)
			.HasForeignKey(c => c.LivreId)
			.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
