namespace RestClientExample.RestClient.Models;

#region BlogModel

[Table("Tbl_Blog")]
public class BlogModel
{
	[Key]
	public int BlogId {  get; set; }
	public string BlogTitle { get; set; } = null!;
	public string BlogAuthor { get; set; } = null!;
	public string BlogContent { get; set; } = null!;
}

#endregion