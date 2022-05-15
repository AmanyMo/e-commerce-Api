namespace e_commerce_Api.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ModelContext _context;
      
        public ProductRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Products> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
                return product;
        }
        public async Task<Products> Add(Products product)
        {
            var result = _context.Products.AddAsync(product).Result;
            var num = await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Products> Update(Products _product)
        {
             Products products =await _context.Products.AsNoTracking().SingleOrDefaultAsync(p=>p.ProductID==_product.ProductID);
            if (products != null)
            {
                _context.Entry(_product).State = EntityState.Modified;
                try
                {
                    int successRet = _context.SaveChangesAsync().Result;
                    if (successRet == 1)
                    {
                        return _product;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {

                    throw e.InnerException;
                }

            }
            else
                return products;
        }
        public  bool Delete(int prod_Id)
        {
            var prod =  _context.Products.FindAsync(prod_Id).Result;
            if (prod != null)
            {
                _context.Products.Remove(prod);
               var ret=  _context.SaveChangesAsync().Result;
                if (Convert.ToBoolean(ret) ) 
                    return true;
                
            }
            return false;

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
