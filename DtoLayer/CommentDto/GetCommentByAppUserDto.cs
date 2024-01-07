using DtoLayer.PostDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CommentDto
{
	public class GetCommentByAppUserDto
	{
		public int CommentID { get; set; }
		public string CommentTitle { get; set; }
		public string CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public int PostID { get; set; }
		public ResultPostDto Post {get; set;}
	}
}
