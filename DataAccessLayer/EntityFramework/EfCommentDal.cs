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
    public class EfCommentDal : EfGenericRepository<Comment>, ICommentDal
    {
        private readonly FarmerCoopDbContext _context;
        public EfCommentDal(FarmerCoopDbContext context) : base(context)
        {
            this._context = context;
        }
        public List<Comment> GetCommentListByAppUser(int userID)
        {
            var comments = _context.Comments.Include(x=>x.Post).Where(x => x.AppUserID == userID).ToList();
            return comments;
        } 
    }
}
