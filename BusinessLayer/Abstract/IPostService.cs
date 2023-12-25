using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPostService : IGenericService<Post>
    {
		List<Post> TGetPostListWithAppUser();
		Post TGetPostWithAppUserByPostID(int postID);
		Post GetPostWithAppUserAndCommentsByPostID(int postID);
		List<Post> GetPostListByAppUserID(int userID);
	}
}
