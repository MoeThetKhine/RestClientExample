namespace RestClientExample.RestClient;

#region AppDbContext

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<BlogModel> Blogs { get; set; }
}

#endregion