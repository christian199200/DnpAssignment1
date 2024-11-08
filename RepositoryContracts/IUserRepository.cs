using System.Collections;
using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int userId);
    Task AddAsync(User user);
    Task<IEnumerable> GetAllUsersAsync();
    object GetMany();
    Task<User> GetSingleAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(User existing);
}