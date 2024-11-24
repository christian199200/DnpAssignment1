using System.Collections;
using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FIleRepositories;

public class UserFileRepository : IUserRepository
{
    private readonly string filePath = "users.json";

    public UserFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }

    public async Task<User> AddAsync(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson) ?? new List<User>();
        int maxId = users.Count > 0 ? users.Max(u => u.Id) : 1;
        user.Id = maxId + 1;
        users.Add(user);
        usersAsJson = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, usersAsJson);
        return user;
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetSingleAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetMany()
    {
        throw new NotImplementedException();
    }

    // public async Task<IEnumerable> GetAllUsersAsync()
    // {
    //     string usersAsJson = await File.ReadAllTextAsync(filePath);
    //     List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson) ?? new List<User>();
    //     return users; // Return the users as IEnumerable<User>
    // }


    public async Task<User> GetByIdAsync(int userId)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson) ?? new List<User>();
        return users.SingleOrDefault(u => u.Id == userId);
    }
    
    public IQueryable<User> GetAll()
    {
        string usersAsJson = File.ReadAllTextAsync(filePath).Result;
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson) ?? new List<User>();
        return users.AsQueryable();
    }

    Task<User> IUserRepository.AddAsync(User user)
    {
        return AddAsync(user);
    }
}