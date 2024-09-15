using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView
{
     private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public ManagePostsView(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.WriteLine("\n-- Manage Posts Menu --");
                Console.WriteLine("1. List Posts");
                Console.WriteLine("2. Create Post");
                Console.WriteLine("3. Update Post");
                Console.WriteLine("4. Delete Post");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option (1-5): ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await ListPostsAsync();
                        break;
                    case "2":
                        await CreatePostAsync();
                        break;
                    case "3":
                        await UpdatePostAsync();
                        break;
                    case "4":
                        await DeletePostAsync();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private async Task ListPostsAsync()
        {
            var posts = _postRepository.GetMany().ToList();
            if (!posts.Any())
            {
                Console.WriteLine("No posts found.");
                return;
            }

            Console.WriteLine("\n-- List of Posts --");
            foreach (var post in posts)
            {
                Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, User ID: {post.UserId}");
            }
        }

        private async Task CreatePostAsync()
        {
            var createPostView = new CreatePostView(_postRepository, _userRepository);
            await createPostView.ExecuteAsync();
        }

        private async Task UpdatePostAsync()
        {
            Console.WriteLine("Enter Post ID to update:");
            if (!int.TryParse(Console.ReadLine(), out var postId))
            {
                Console.WriteLine("Invalid Post ID.");
                return;
            }

            var post = await _postRepository.GetSingleAsync(postId);
            if (post == null)
            {
                Console.WriteLine("Post not found.");
                return;
            }

            Console.WriteLine("Enter new Post Title:");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter new Post Body:");
            string newBody = Console.ReadLine();

            post.Title = newTitle;
            post.Body = newBody;
            await _postRepository.UpdateAsync(post);

            Console.WriteLine($"Post '{post.Title}' updated successfully.");
        }

        private async Task DeletePostAsync()
        {
            Console.WriteLine("Enter Post ID to delete:");
            if (!int.TryParse(Console.ReadLine(), out var postId))
            {
                Console.WriteLine("Invalid Post ID.");
                return;
            }

            var post = await _postRepository.GetSingleAsync(postId);
            if (post == null)
            {
                Console.WriteLine("Post not found.");
                return;
            }

            await _postRepository.DeleteAsync(postId);
            Console.WriteLine($"Post with ID '{postId}' deleted successfully.");
        }
    }