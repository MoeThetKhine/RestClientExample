namespace RestClientExample.RestClient.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
	private readonly BL_Blog _bL_Blog;

	public BlogController(BL_Blog bL_Blog)
	{
		_bL_Blog = bL_Blog;
	}

	#region GetBlogs

	[HttpGet]
	public async Task<IActionResult> GetBlogs(int pageNo , int pageSize)
	{
		try
		{
			BlogListResponseModel lst = await _bL_Blog.GetBlog(pageNo, pageSize);
			return Ok(new ResponseModel()
			{
				IsSuccess = true,
				Data = lst.Data,
				PageSetting = lst.PageSetting,
			});
		}

		catch(Exception ex)
		{
			return BadRequest(new ResponseModel()
			{
				IsSuccess = false,
				Message = ex.Message
			});
		}
	}

	#endregion
}
