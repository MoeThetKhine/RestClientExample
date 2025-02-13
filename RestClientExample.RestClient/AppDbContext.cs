using Microsoft.EntityFrameworkCore;
using RestClientExample.RestClient.Models;

namespace RestClientExample.RestClient
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<BlogModel> Blogs { get; set; }
	}
}
