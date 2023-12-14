using FarmerCoopWebUI.Dtos.AppUserDto;

namespace FarmerCoopWebUI.Dtos.PostDtos
{
	public class ResultPostWithAppUserDto
	{
		public int PostID { get; set; }
		public string PostTitle { get; set; }
		public string PostContent { get; set; }
		public DateTime CreateDate { get; set; }
		public bool PostStatus { get; set; }
		public ResultAppUserDto AppUser { get; set; }
	}
}
