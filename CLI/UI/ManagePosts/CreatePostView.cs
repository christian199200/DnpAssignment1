using System.Diagnostics;
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class CreatePostView
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public CreatePostView(IPostRepository postRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync()
    {
        // Prompt for post title
        Console.WriteLine("Enter Post Title:");
        string title = Console.ReadLine();

        // Prompt for post body
        Console.WriteLine("Enter Post Body:");
        string body = Console.ReadLine();

        // Prompt for user ID
        Console.WriteLine("Enter User ID:");
        if (!int.TryParse(Console.ReadLine(), out var userId))
        {
            Console.WriteLine("Invalid user ID");
            return;
        }

        // Validate user existence
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        // Create the post
        var post = new Post(title, body, userId);
        await _postRepository.AddAsync(post);

        // Notify user of success
        Console.WriteLine($"Post '{title}' created with ID: {post.Id}");
    }
}