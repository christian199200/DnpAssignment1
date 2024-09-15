
using RepositoryContracts;
using Entities;
namespace CLI.UI.ManageUsers;

public class ListUsersView
{
    private readonly IUserRepository _userRepository;

    public ListUsersView(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync()
    {
        // Retrieve all users asynchronously from the repository
        IEnumerable<User> users;
        try
        {
            users = (IEnumerable<User>)await _userRepository.GetAllUsersAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
            return;
        }

        // Check if there are any users
        if (!users.Any())
        {
            Console.WriteLine("No users found.");
            return;
        }

        // Display the list of users
        Console.WriteLine("\n-- List of Users --");
        foreach (var user in users)
        {
            // Ensure that the properties are accessible and correct
            Console.WriteLine($"ID: {user.Id}, Username: {user.UserName}");
        }
    }
}