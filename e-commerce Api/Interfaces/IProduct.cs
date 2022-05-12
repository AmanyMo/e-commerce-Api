namespace e_commerce_Api.Interfaces
{
    public interface IProduct 
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        void Add(Products product);
        void Update(Products product);

        void Delete(int prod_Id);

        void Save();


    }
}