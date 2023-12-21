using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerCoopWebUI.Dtos.PostDtos
{
	public class UpdatePostDto
	{
		public int PostID { get; set; }
		public string PostTitle { get; set; }
		public string PostContent { get; set; }
		public DateTime CreateDate { get; set; }
		public bool PostStatus { get; set; }
		public int AppUserId { get; set; }
	}
}
