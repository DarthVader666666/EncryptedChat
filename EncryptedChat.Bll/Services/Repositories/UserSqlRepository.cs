using EncryptedChat.Bll.Interfaces;
using EncryptedChat.Data.Entities;

namespace EncryptedChat.Bll.Services.Repositories
{
    public class UserSqlRepository : IRepository<User>
    {
        public Task<User?> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteAsync(object? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(object? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User?>> GetListAsync(object? id = null)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
