using FarmerCoopWebUI.Dtos.PostDtos;

namespace FarmerCoopWebUI.Dtos.CommentDto
{
	public class GetCommentByAppUserDto
	{
		public int CommentID { get; set; }
		public string CommentTitle { get; set; }
		public string CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public int PostID { get; set; }
		public ResultPostDto Post { get; set; }
	}
}
