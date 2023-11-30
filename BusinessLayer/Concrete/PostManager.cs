using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }

        public List<Post> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            return _postDal.GetAll(filter);
        }

        public Post GetEntity(Expression<Func<Post, bool>> filter)
        {
            return _postDal.GetEntity(filter);
        }

        public Post GetEntityByID(int id)
        {
            return _postDal.GetEntityByID(id);
        }

        public void Insert(Post entity)
        {
           _postDal.Insert(entity);
        }
		public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
		public List<Post> TGetPostListWithAppUser()
		{
			return _postDal.GetPostListWithAppUser();
		}

		public Post TGetPostWithAppUserByPostID(int postID)
		{
			return _postDal.GetPostWithAppUserByPostID(postID);
		}
	}
}
