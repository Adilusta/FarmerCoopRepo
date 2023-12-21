using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerCoopWebUI.Dtos.CommentDto
{
	public class ResultCommentDto
	{
		public int CommentID { get; set; }
		public string CommentUserName { get; set; }
		public string CommentTitle { get; set; }
		public string CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public int PostID { get; set; }
	}
}
