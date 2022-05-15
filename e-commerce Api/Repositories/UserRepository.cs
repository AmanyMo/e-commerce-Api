namespace e_commerce_Api.Repositories
{
    public class UserRepository : IUser
    {
        public Task<User> Add(User order)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int user_Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
