namespace e_commerce_Api.Interfaces
{
    public interface IProduct 
    {
        Task<IEnumerable<Products>> GetAll();
        Task<Products> GetById(int id);
        Task<Products> Add(Products product);
        Task<Products> Update(Products product);
        bool Delete(int prod_Id);

    }
}