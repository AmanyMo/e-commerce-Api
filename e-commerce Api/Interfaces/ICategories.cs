namespace e_commerce_Api.Interfaces
{
    public interface ICategories
    {
        Task<IEnumerable<Categories>> GetAll();
        Task<Categories> GetById(int id);
        Task<Categories> Add(Categories category);
        Task<Categories> Update(Categories category);

        bool Delete(int category_Id);

    }
}
