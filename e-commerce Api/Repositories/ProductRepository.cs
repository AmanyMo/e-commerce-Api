using e_commerce_Api.Interfaces;
using e_commerce_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_Api.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ModelContext _context;
      
        public ProductRepository(ModelContext context)
        {
            _context = context;
        }
      

        public IEnumerable<Products> GetAll()
        {
            return _context.Products.ToList();          
           
        }

        public  Products GetById(int id)
        {
            return _context.Products.Find(id);
        }
        public void Add(Products product)
        {
            _context.Products.Add(product);
        }
        public void Update(Products product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }


        public void Delete(int prod_Id)
        {
            Products prod = _context.Products.Find(prod_Id);
            _context.Products.Remove(prod);
        }


        public void Save()
        {
            _context.SaveChanges();
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
