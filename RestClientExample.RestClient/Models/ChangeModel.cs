namespace RestClientExample.RestClient.Models
{
	public static class ChangeModel
	{
		#region Change

		public static BlogModel Change(this BlogRequestModel requestModel)
		{
			return new BlogModel()
			{
				BlogTitle = requestModel.BlogTitle,
				BlogAuthor = requestModel.BlogAuthor,
				BlogContent = requestModel.BlogContent,
			};
		}

		#endregion
	}
}
