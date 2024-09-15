using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    private readonly ListUsersView _listUsersView;
    private readonly CreateUserView _createUserView;

    public ManageUsersView(IUserRepository userRepository)
    {
        _listUsersView = new ListUsersView(userRepository);
        _createUserView = new CreateUserView(userRepository);
    }

    public async Task ExecuteAsync()
    {
        while (true)
        {
            Console.WriteLine("User Management:");
            Console.WriteLine("1. List Users");
            Console.WriteLine("2. Create User");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await _listUsersView.ExecuteAsync();
                    break;
                case "2":
                    await _createUserView.ExecuteAsync();
                    break;
                case "3":
                    return; // Exit the loop and end the method
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}