namespace e_commerce_Api.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        User Add(User order);
        Task<User> Update(int userId, User user);
        bool Delete(int user_Id);
    }
}
