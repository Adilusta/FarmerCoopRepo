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
    public class EfProductDal : EfGenericRepository<Product>, IProductDal
	{
		private readonly FarmerCoopDbContext _context;
		public EfProductDal(FarmerCoopDbContext context) : base(context)
        {
            this._context = context;
        }
		public List<Product> GetProductListWithAppUser()
		{
			var values = _context.Products.Include(x => x.AppUser).ToList();
			return values;
		}
		public Product GetProductWithAppUserByProductID(int productID)
		{
			var value = _context.Products.Where(x => x.ProductID == productID).Include(y => y.AppUser).FirstOrDefault();
			//var value = _context.Posts.Include(x => x.AppUser).FirstOrDefault();
			return value;
		}
	}
}
