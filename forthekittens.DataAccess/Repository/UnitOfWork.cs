using forthekittens.DataAccess.Data;
using forthekittens.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forthekittens.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category {  get; private set; }
        public IProductRepository Product { get; private set; }
        public readonly Kittensdbcontext _db;
        public UnitOfWork(Kittensdbcontext db) 
        {
            _db = db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
