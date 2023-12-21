﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CommentDto
{
	public class UpdateCommentDto
	{
		public int CommentID { get; set; }
		public string CommentUserName { get; set; }
		public string CommentTitle { get; set; }
		public string CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public int PostID { get; set; }
	}
}
