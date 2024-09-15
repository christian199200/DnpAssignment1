using System.Collections;
using Entities;
using RepositoryContracts;

namespace InMomoryRepository;

public class UserInMemoryRepository : IUserRepository
{
    private readonly List<User> users = new();

    public UserInMemoryRepository()
    {
        // Adding some dummy data
        users.Add(new User(1, "Alice", "password123"));
        users.Add(new User(2, "Bob", "password456"));
    }

    public Task AddAsync(User user)
    {
        user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
        users.Add(user);
        return Task.FromResult(user);
    }

    public Task<IEnumerable> GetAllUsersAsync()
    {
        return Task.FromResult<IEnumerable>(users.AsEnumerable());
    }

    public Task<User> GetByIdAsync(int userId)
    {
        var user = users.SingleOrDefault(u => u.Id == userId);
        if (user == null)
            throw new InvalidOperationException($"User with ID {userId} not found");

        return Task.FromResult(user);
    }

    public IQueryable<User> GetAll()
    {
        return users.AsQueryable();
    }
}
