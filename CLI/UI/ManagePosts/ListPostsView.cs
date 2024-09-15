using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ListPostsView
{
    private readonly IPostRepository _postRepository;

    public ListPostsView(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public void Execute()
    {
        var posts = _postRepository.GetMany().ToList();
        if (!posts.Any())
        {
            Console.WriteLine("No posts available.");
            return;
        }

        foreach (var post in posts)
        {
            Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, Body: {post.Body}");
        }
    }
}