using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPostDal : EfGenericRepository<Post>, IPostDal
    {
		private readonly FarmerCoopDbContext _context;
		public EfPostDal(FarmerCoopDbContext context) : base(context)
        {
            this._context = context;
        }

		public List<Post> GetPostListWithAppUser()
		{
			var values = _context.Posts.Include(x => x.AppUser).ToList();
			return values;
		}

		public Post GetPostWithAppUserAndCommentsByPostID(int postID)
		{
			var value = _context.Posts.Where(x=> x.PostID==postID).Include(y => y.Comments).Include(z=> z.AppUser).FirstOrDefault();
			return value;
		}

		public Post GetPostWithAppUserByPostID(int postID)
		{
			var value = _context.Posts.Where(x => x.PostID == postID).Include(y => y.AppUser).FirstOrDefault();
			//var value = _context.Posts.Include(x => x.AppUser).FirstOrDefault();
			return value;
		}
	}
}
