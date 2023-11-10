using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IEntity, new() 
    {

       private readonly FarmerCoopDbContext _context;

        public EfGenericRepository(FarmerCoopDbContext context)
        {
            _context = context;
        }
        public void Insert(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Set<TEntity>().Where(filter).ToList();

            }
            else
            {
                return _context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public TEntity GetEntityByID(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
