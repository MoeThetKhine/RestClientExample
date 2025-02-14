namespace RestClientExample.RestClient.Features.Blog;

public class DA_Blog
{
	private readonly AppDbContext _appDbContext;

	public DA_Blog(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetBlogs

	public async Task<BlogListResponseModel> GetBlogs(int pageNo, int pageSize)
	{
		var lst = await _appDbContext.Blogs.AsNoTracking()
			.OrderByDescending(x => x.BlogId)
			.Skip((pageNo - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();

		var rowCount = await _appDbContext.Blogs.CountAsync();
		var pageCount = rowCount / pageSize;

		if(rowCount % pageSize > 0)
		{
			pageCount++;
		}

		PageSettingModel pageSettingModel = new()
		{
			PageCount = pageCount,
			PageSize = pageSize,
			PageNo = pageNo,
		};

		return new BlogListResponseModel()
		{
			Data = new BlogDataModel() { Blogs = lst },
			PageSetting = new PageSettingModel()
			{
				PageCount = pageCount,
				PageSize = pageSize,
				PageNo = pageNo,
			}
		};
	}

	#endregion

	public async Task<BlogModel> GetBlog(long id)
	{
		var item = await _appDbContext.Blogs
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.BlogId == id);

		return item!;
	}

	public async Task<int> CreateBlog(BlogRequestModel requestModel)
	{
		await _appDbContext.Blogs.AddAsync(requestModel.Change());
		int result = await _appDbContext.SaveChangesAsync();
		return result;
	}

}
