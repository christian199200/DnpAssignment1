using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostView
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentRepository _commentRepository;

    public SinglePostView(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        _postRepository = postRepository;
        _commentRepository = commentRepository;
    }

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Enter Post ID:");
        if (!int.TryParse(Console.ReadLine(), out var postId))
        {
            Console.WriteLine("Invalid post ID");
            return;
        }

        var post = await _postRepository.GetSingleAsync(postId);
        if (post == null)
        {
            Console.WriteLine("Post not found.");
            return;
        }

        Console.WriteLine($"Post ID: {post.Id}\nTitle: {post.Title}\nBody: {post.Body}");

        var comments = _commentRepository.GetMany().Where(c => c.PostId == postId).ToList();
        Console.WriteLine("\nComments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"User {comment.UserId}: {comment.Body}");
        }
    }
}