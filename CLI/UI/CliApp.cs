using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp
{
    private readonly IUserRepository _userRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public async Task StartAsync()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Create User\n2. Create Post\n3. List Posts\n4. View Post\n5. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new CreateUserView(_userRepository).ExecuteAsync();
                    break;
                case "2":
                    await new CreatePostView(_postRepository, _userRepository).ExecuteAsync();
                    break;
                case "3":
                    new ListPostsView(_postRepository).Execute();
                    break;
                case "4":
                    await new SinglePostView(_postRepository, _commentRepository).ExecuteAsync();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
