
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

            //return _context.Products.ToList();
        }

        public void Delete(int prod_Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetAll()
        {
            throw new NotImplementedException();
        }

        public Products GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Products product)
        {
            throw new NotImplementedException();
        }
    }
}