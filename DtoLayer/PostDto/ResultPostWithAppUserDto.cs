using DtoLayer.AppUserDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PostDto
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
