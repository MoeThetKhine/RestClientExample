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
			BlogListResponseModel lst = await _bL_Blog.GetBlogs(pageNo, pageSize);
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

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBlog(long id)
	{
		try
		{
			var item = await _bL_Blog.GetBlog(id);
			return Ok(new ResponseModel()
			{
				IsSuccess = true,
				Item = item,
			});
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> CreateBlog([FromBody]BlogRequestModel requestModel)
	{
		try
		{
			int result = await _bL_Blog.CreateBlog(requestModel);

			ResponseModel responseModel = new();

			if(result > 0)
			{
				return StatusCode(201, responseModel = new()
				{
					IsSuccess=true,
					Message = "Creating Successful!",
					Item = requestModel
				});
			}

			return BadRequest(responseModel = new()
			{
				Message = "Creating Fail!",
				IsSuccess = false
			});
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog([FromBody]BlogRequestModel requestModel,long id)
	{
		try
		{
			int result = await _bL_Blog.UpdateBlog(requestModel,id);
			ResponseModel responseModel = new();

			if(result > 0)
			{
				return StatusCode(202, responseModel = new()
				{
					IsSuccess = true,
					Message = "Updating Successful!",
					Item = requestModel
				});
			}
			return StatusCode(400, responseModel = new()
			{
				IsSuccess = true,
				Message = "Updating Fail!"
			});
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel,long id)
	{
		try
		{
			int result = await _bL_Blog.PatchBlog(requestModel,id);
			ResponseModel responseModel = new();

			if(result > 0)
			{
				return StatusCode(202, responseModel = new()
				{
					IsSuccess = true,
					Message = "Updating Successful!",
					Item = requestModel
				});
			}

			return BadRequest(responseModel = new()
			{
				IsSuccess = false,
				Message = "Updating Fail."
			});
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

}
