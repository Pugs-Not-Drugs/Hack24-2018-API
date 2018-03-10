using Microsoft.EntityFrameworkCore;

namespace Hack24_2018_API.Models
{
	public class EcoNottsDbContext : DbContext
	{
		public EcoNottsDbContext(DbContextOptions options): base(options)
		{

		}

		public DbSet<Establishment> Establishments { get; set; }
		public DbSet<Reports> Reports { get; set; }
	}
}
