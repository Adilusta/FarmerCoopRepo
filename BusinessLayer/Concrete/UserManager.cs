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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Delete(AppUser entity)
        {
            _userDal.Delete(entity);
        }

        public List<AppUser> GetAll(Expression<Func<AppUser, bool>> filter = null)
        {
			return _userDal.GetAll(filter);
		}

        public AppUser GetEntity(Expression<Func<AppUser, bool>> filter)
        {
           return _userDal.GetEntity(filter);
        }

        public AppUser GetEntityByID(int id)
        {
            return _userDal.GetEntityByID(id);
        }

        public void Insert(AppUser entity)
        {
            _userDal.Insert(entity);
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
        }
    }
}
