namespace RestClientExample.RestClient.Features.Blog;

public class BL_Blog
{
	private readonly DA_Blog _dA_Blog;

	public BL_Blog(DA_Blog dA_Blog)
	{
		_dA_Blog = dA_Blog;
	}

	#region GetBlogs

	public async Task<BlogListResponseModel> GetBlogs(int pageNo, int pageSize)
	{
		if (pageNo == 0 || pageSize == 0)
			throw new Exception("Invalid Request.");

		return await _dA_Blog.GetBlogs(pageNo, pageSize);
	}

	#endregion

	public async Task<BlogModel> GetBlog (long id)
	{
		if(id == 0)
		{
			throw new Exception("Id cannot be empty.");
		}

		return await _dA_Blog.GetBlog(id);
	}

	public async Task<int> CreateBlog(BlogRequestModel requestModel)
	{
		if(string.IsNullOrEmpty(requestModel.BlogTitle))
		{
			throw new Exception("Blog Title cannot be empty.");
		}

		if(string.IsNullOrEmpty(requestModel.BlogAuthor))
		{
			throw new Exception("Blog Author cannot be empty.");
		}

		if(string.IsNullOrEmpty(requestModel.BlogContent))
		{
			throw new Exception("Blog Content cannot be empty.");
		}

		int result = await _dA_Blog.CreateBlog(requestModel);
		return result;
	}

	public async Task<int> UpdateBlog(BlogRequestModel requestModel, long id)
	{
		if(id == 0)
		{
			throw new Exception("ID cannot be empty.");
		}

		if (string.IsNullOrEmpty(requestModel.BlogTitle))
		{
			throw new Exception("Blog Title cannot be empty.");
		}

		if(string.IsNullOrEmpty(requestModel.BlogAuthor))
		{
			throw new Exception("Blog Author cannot be empty.");
		}

		if(string.IsNullOrEmpty(requestModel.BlogContent))
		{
			throw new Exception("Blog Content cannot be empty.");
		}

		int result = await _dA_Blog.UpdateBlog(requestModel, id);
		return result;
	}

	public async Task<int> PatchBlog(BlogRequestModel requestModel, long id)
	{
		if(id == 0)
		{
			throw new Exception("ID cannot be empty");
		}

		int result = await _dA_Blog.PatchBlog(requestModel, id);
		return result;
	}

}
