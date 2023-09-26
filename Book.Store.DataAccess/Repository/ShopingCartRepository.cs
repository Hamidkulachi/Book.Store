using Book.Store.Data;
using Book.Store.DataAccess.Repository.IRepository;
using Book.Store.Models;
using Book.Store.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Store.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
