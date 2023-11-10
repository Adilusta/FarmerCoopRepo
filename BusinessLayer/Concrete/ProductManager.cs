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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
          return  _productDal.GetAll(filter);
        }

        public Product GetEntity(Expression<Func<Product, bool>> filter)
        {
         return _productDal.GetEntity(filter);
        }

        public Product GetEntityByID(int id)
        {
          return _productDal.GetEntityByID(id);
        }

        public void Insert(Product entity)
        {
           _productDal.Insert(entity);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
