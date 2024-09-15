using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int userId);
    Task AddAsync(User user);
}