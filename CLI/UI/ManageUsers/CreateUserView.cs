using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class CreateUserView
{
    private readonly IUserRepository _userRepository;

    public CreateUserView(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Enter Username:");
        string username = Console.ReadLine();

        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();

        var user = new User(0, username, password);
        await _userRepository.AddAsync(user);
        Console.WriteLine($"User {username} created with ID: {user.Id}");
    }
}