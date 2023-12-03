using forthekittens.DataAccess.Data;
using forthekittens.DataAccess.Repository.IRepository;
using forthekittens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace forthekittens.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public readonly Kittensdbcontext _db;
        public CategoryRepository(Kittensdbcontext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
