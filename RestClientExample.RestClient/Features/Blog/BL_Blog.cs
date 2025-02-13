namespace RestClientExample.RestClient.Features.Blog;

public class BL_Blog
{
	private readonly DA_Blog _dA_Blog;

	public BL_Blog(DA_Blog dA_Blog)
	{
		_dA_Blog = dA_Blog;
	}

	#region GetBlog

	public async Task<BlogListResponseModel> GetBlog(int pageNo, int pageSize)
	{
		if (pageNo == 0 || pageSize == 0)
			throw new Exception("Invalid Request.");

		return await _dA_Blog.GetBlogs(pageNo, pageSize);
	}

	#endregion
}
