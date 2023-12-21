using FarmerCoopWebUI.Dtos.AppUserDto;
using FarmerCoopWebUI.Dtos.CommentDto;

namespace FarmerCoopWebUI.Dtos.PostDtos
{
	public class ResultPostWithAppUserAndCommentsDto
	{
		public int PostID { get; set; }
		public string PostTitle { get; set; }
		public string PostContent { get; set; }
		public DateTime CreateDate { get; set; }
		public bool PostStatus { get; set; }
		public ResultAppUserDto AppUser { get; set; }
		public int AppUserId { get; set; }
		public List<ResultCommentDto> Comments { get; set; }
	}
}
