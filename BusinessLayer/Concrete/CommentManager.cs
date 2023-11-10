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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void Insert(Comment entity)
        {
            _commentDal.Insert(entity);
        }
        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.GetAll(filter);
        }

        public Comment GetEntity(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.GetEntity(filter);
        }

        public Comment GetEntityByID(int id)
        {
            return _commentDal.GetEntityByID(id);
        }
    }
}
