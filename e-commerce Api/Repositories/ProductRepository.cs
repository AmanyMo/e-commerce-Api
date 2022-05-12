using e_commerce_Api.Interfaces;
using e_commerce_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_Api.Repositories
{
    public class ProductRepository : IProduct
    {
        private DbContext _context;
        public ProductRepository(DbContext context)
        {
            this._context = context;
        }
        public void Add(Products product)
        {
            throw new NotImplementedException();
            //_context.Products.Add(product);
            
        }

        public void Delete(int prod_Id)
        {
            throw new NotImplementedException();
          //Products prod=  _context.Products.Find(prod_Id);
          //  _context.Products.Remove(prod);


        }

        public IEnumerable<Products> GetAll()
        {
            throw new NotImplementedException();
            //return _context.Products.ToList();
        }

        public Products GetById(int id)
        {
            throw new NotImplementedException();
            //return _context.Products.Find(id);
        }

        public void Save()
        {
            throw new NotImplementedException();
            //_context.SaveChanges();
        }

        public void Update(Products product)
        {
            throw new NotImplementedException();
            //_context.Entry(product).State = EntityState.Modified;
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
