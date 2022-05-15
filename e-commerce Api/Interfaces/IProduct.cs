namespace e_commerce_Api.Interfaces
{
    public interface IProduct 
    {
        Task<IEnumerable<Products>> GetAll();
        Task<Products> GetById(int id);
        Task<IEnumerable<Products>> GetAllProductsCategory(int category_Id);
        Task<Products> Add(Products product);
        Task<Products> Update(Products product);
        bool Delete(int prod_Id);

    }
}