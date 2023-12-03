using forthekittens.DataAccess.Data;
using forthekittens.DataAccess.Repository.IRepository;
using forthekittens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace forthekittens.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly Kittensdbcontext _db;
        public ProductRepository(Kittensdbcontext db) : base(db)
        {
            _db = db;
        }
       
        public void Update(Product productobj)
        {
            _db.Products.Update(productobj);
        }

    }
}
