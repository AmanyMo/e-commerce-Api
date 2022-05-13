

//        public async Task<Categories> Update(Categories category)
//        {
//              _context.Entry(category).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return category;

//        }

//    }
//}


using Microsoft.AspNetCore.Mvc;

namespace e_commerce_Api.Repositories
{
    public class CategoriesRepository : ICategories
    {
        private readonly ModelContext _context;

        public CategoriesRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Categories> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }
        public async Task<Categories> Add(Categories category)
        {
            var result = _context.Categories.AddAsync(category).Result;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException db)
            {
                throw db.InnerException;
            }
            return result.Entity;
        }
        public  async Task<Categories> Update(Categories _category)
        {
            Categories category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.CategoryID == _category.CategoryID);
            if (category != null)
            {
                _context.Entry(_category).State = EntityState.Modified;
                try
                {
                    int successRet = _context.SaveChangesAsync().Result;
                    if (successRet == 1)
                    {
                        return _category;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
            }
            else
            {
                return category;
            }
        }
        public bool Delete(int cat_Id)
        {
            int retVal;
            var cat = _context.Categories.FindAsync(cat_Id).Result;
            if (cat != null)
            {
                _context.Categories.Remove(cat);
                try
                {
                   retVal= _context.SaveChangesAsync().Result;
                }
                catch (DbUpdateConcurrencyException db)
                {
                    throw db.InnerException;
                }
               
                if (Convert.ToBoolean(retVal))
                    return true;
            }
            return false;
        }
        private  bool CategoriesExists(int id)
        {
           var cat= GetById(id).Result;

            return cat!=null ? true : false;
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}


