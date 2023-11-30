﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
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
    }
}
