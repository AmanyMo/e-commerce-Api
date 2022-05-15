﻿namespace e_commerce_Api.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ModelContext _context;
        public UserRepository(ModelContext context)
        {
            _context = context;
        }
        public  User Add(User user)
        {
            _context.Users.AddAsync(user);
            try
            {
              int retval=  _context.SaveChangesAsync().Result;
                if (Convert.ToBoolean(retval))
                    return user;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return null;
        }

        public bool Delete(int user_Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Update(int userId, User _user)
        {
            User user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Entry(_user).State = EntityState.Modified;
                try
                {
                    int successRet = _context.SaveChangesAsync().Result;
                    if (successRet == 1)
                        return _user;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e.InnerException;
                }
            }
            return user;
        }
    }
}
